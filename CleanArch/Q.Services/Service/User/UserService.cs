using Q.Domain;
using Q.Domain.Response;
using Q.Infrastructure;
using Q.Services.Interfaces.User;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Q.Services.Service.User
{
    public class UserService : IUserService
    {
        private readonly IRepository<Domain.User.User> _userRepository;

        public UserService(IRepository<Domain.User.User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async void Add(Domain.User.User user)
        {
            await _userRepository.Insert(user);
        }


        public async Task<PagedResult<Domain.User.User>> GetAll(int page, int? pageSize)
        {
            return await _userRepository.GetAll(page, pageSize);
        }

        public async Task<SaveResponseDto> Update(Domain.User.User entity,string password = null)
        {
            var user = _userRepository.FindBy(x=>x.Id == entity.Id).FirstOrDefault();

            if (user == null)
                throw new Exception("User not found");

            if (entity.UserName != user.UserName)
            {
                // username has changed so check if the new username is already taken
                if (_userRepository.GetAll().Result.Any(x => x.UserName == entity.UserName))
                    throw new Exception("Username " + entity.UserName + " is already taken");
            }

            // update user properties
            user.UserProfile.FirstName = entity.UserProfile.FirstName;
            user.UserProfile.LastName = entity.UserProfile.LastName;
            user.UserName = entity.UserName;
            user.EmailAddress = entity.EmailAddress;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            var response = await _userRepository.Update(user);
            return new SaveResponseDto
            {
                SavedEntityId = user.Id,
                SaveSuccessful = response
            };
        }

        public Domain.User.User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _userRepository.FindBy(x => x.UserName == username || x.EmailAddress == username).FirstOrDefault();

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public Domain.User.User Create(Domain.User.User user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required");

            if (_userRepository.GetAll().Result.Any(x => x.UserName == user.UserName || x.EmailAddress == user.EmailAddress))
                throw new Exception("Username \"" + user.UserName + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _userRepository.Insert(user);

            return user;
        }

        public Domain.User.User CheckIfUserExists(int userId)
        {
            return _userRepository.FindBy(x => x.Id == userId).FirstOrDefault();
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

       
    }
}
