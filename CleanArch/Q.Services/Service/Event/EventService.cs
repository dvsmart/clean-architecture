using Q.Domain;
using Q.Domain.Event;
using Q.Domain.Response;
using Q.Infrastructure;
using Q.Services.Interfaces.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q.Services.Service.Event
{
    public class EventService : IEventService
    {
        private readonly IRepository<Domain.Event.Event> _eventRepository;

        public EventService(IRepository<Domain.Event.Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async System.Threading.Tasks.Task Delete(int id)
        {
            var eventDto = _eventRepository.Get(id);
            await _eventRepository.Remove(eventDto.Result);
        }

        public async System.Threading.Tasks.Task DeleteAll(List<int> ids)
        {
            var entities = await _eventRepository.GetAll();
            await _eventRepository.DeleteAll(entities.ToList());
        }

        public Task<PagedResult<Domain.Event.Event>> GetAll(int page, int? pageSize)
        {
            return _eventRepository.GetAll(page, pageSize);
        }

        public async Task<Domain.Event.Event> GetById(int id)
        {
            return await _eventRepository.Get(id);
        }

        public async Task<SaveResponseDto> Insert(Domain.Event.Event entity)
        {
            var res = await _eventRepository.Insert(entity);
            return new SaveResponseDto
            {
                SaveSuccessful = res,
                SavedEntityId = entity.Id
            };
        }

        public async Task<SaveResponseDto> Update(Domain.Event.Event entity)
        {
            var response = await _eventRepository.Update(entity);
            return new SaveResponseDto
            {
                SaveSuccessful = response,
                SavedEntityId = entity.Id
            };
        }
    }
}
