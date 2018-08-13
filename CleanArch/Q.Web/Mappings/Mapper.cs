using Q.Web.Models.Assessment;
using Q.Web.Models.Event;
using System;

namespace Q.Web.Mappings
{
    public static class Mapper
    {
        public static Domain.Assessment.Assessment MapToAssessmentDto(CreateAssessmentRequest assessmentRequestModel)
        {
            var assessmentDto = new Domain.Assessment.Assessment
            {
                AssessmentDate = assessmentRequestModel.AssessmentDate,
                RecurrenceTypeId = assessmentRequestModel.FrequencyId,
                AssessmentScopeId = assessmentRequestModel.ScopeId.Value,
                AssessmentTypeId = assessmentRequestModel.AssessmentTypeId,
                Reference = assessmentRequestModel.Reference,
                Title = assessmentRequestModel.Title,
                PublishedDate = assessmentRequestModel.PublishedDate,
                PublishedBy = assessmentRequestModel.PublishedByUserId,
                IsArchived = false,
                IsDeleted = false,
                IsSuperseded = false,
                AssessorUserId = 1,
                Id = assessmentRequestModel.Id,
                DataId = assessmentRequestModel.DataId
            };
            if (assessmentDto.Id == default(int))
            {
                assessmentDto.AddedDate = DateTime.Now;
                assessmentDto.AddedBy = 1;
            }
            else
            {
                assessmentDto.ModifiedBy = 1;
                assessmentDto.ModifiedDate = DateTime.Now;
            }
            return assessmentDto;
        }

        public static CreateAssessmentRequest MapToAssessmentModel(Domain.Assessment.Assessment assessmentDto)
        {
            return new CreateAssessmentRequest
            {
                AssessmentDate = assessmentDto.AssessmentDate,
                FrequencyId = assessmentDto.RecurrenceTypeId ?? 0,
                ScopeId = assessmentDto.AssessmentScopeId,
                AssessmentTypeId = assessmentDto.AssessmentTypeId ?? 0,
                Reference = assessmentDto.Reference,
                Title = assessmentDto.Title,
                PublishedDate = assessmentDto.PublishedDate ?? null,
                PublishedByUserId = assessmentDto.PublishedBy ?? default(int),
                ModifiedDate = DateTime.Now,
                IsSuperseded = false,
                DataId = assessmentDto.DataId,
                Published = assessmentDto.PublishedBy.HasValue && assessmentDto.PublishedDate.HasValue,
                Id = assessmentDto.Id
            };
        }

        public static EventModel MapToEventModel(Domain.Event.Event eventDto)
        {
            return new EventModel
            {
                AllDayEvent = eventDto.AllDayEvent,
                Description = eventDto.Description,
                DueDate = eventDto.DueDate,
                StartDate = eventDto.StartDate,
                IsCompleted = eventDto.IsCompleted,
                RecurrenceType = eventDto.RecurrenceType.Name,
                Id = eventDto.Id,
                Title = eventDto.Title,
                AddedDate = eventDto.AddedDate,
            };
        }

        public static Domain.Event.Event MapToEventDto(EventModel eventModel)
        {
            return new Domain.Event.Event
            {
                AllDayEvent = eventModel.AllDayEvent,
                Description = eventModel.Description,
                DueDate = eventModel.DueDate,
                StartDate = eventModel.StartDate,
                IsCompleted = eventModel.IsCompleted,
                RecurrenceTypeId = eventModel.RecurrenceTypeId,
                Id = eventModel.Id,
                Title = eventModel.Title,
                AddedDate = eventModel.AddedDate,
            };
        }
    }
}
