using Q.Domain;
using Q.Domain.CustomEntity;
using Q.Services.Interfaces.CustomEntity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q.Services.Service.CustomEntity
{
    public class FormControlTypeService : IFormControlTypeService
    {
        private readonly IGenericRepository<CustomFieldType> _customFieldTypeRepository;

        public FormControlTypeService(IGenericRepository<CustomFieldType> customFieldTypeRepository)
        {
            _customFieldTypeRepository = customFieldTypeRepository;
        }

        public async Task<ICollection<CustomFieldType>> GetCustomFieldTypes()
        {
            return await _customFieldTypeRepository.GetAllAsync();
        }
    }
}
