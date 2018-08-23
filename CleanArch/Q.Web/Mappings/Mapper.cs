using Q.Web.Models.Assessment;
using Q.Web.Models.CustomEntity;
using Q.Web.Models.Event;
using System;
using System.Collections.Generic;
using System.Linq;

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
                AddedBy = 1,
                Location = eventModel.Location,
                ModifiedBy = eventModel.Id == default(int) ? (int?)null : 1,
                ModifiedDate = eventModel.Id == default(int) ? (DateTime?)null : DateTime.Now,
            };
        }


        public static Domain.CustomEntity.CustomEntityGroup MapToCustomEntityGroupDto(CustomEntityGroupModel customEntityGroupModel)
        {
            return new Domain.CustomEntity.CustomEntityGroup
            {
                Name = customEntityGroupModel.CategoryName,
                AddedBy = 1,
                AddedDate = DateTime.Now,
                Id = customEntityGroupModel.Id,
                IsArchived = false,
                IsDeleted = false
            };
        }

        public static Domain.CustomEntity.CustomEntity MapToCustomEntityDto(CustomEntityTemplateModel customEntityTemplateModel)
        {
            return new Domain.CustomEntity.CustomEntity
            {
                TemplateName = customEntityTemplateModel.TemplateName,
                AddedBy = 1,
                AddedDate = DateTime.Now,
                Id = customEntityTemplateModel.Id,
                IsArchived = false,
                IsDeleted = false,
                EntityGroupId = customEntityTemplateModel.GroupId
            };
        }

        public static CustomEntityGroupModel MapToCustomEntityGroupModel(Domain.CustomEntity.CustomEntityGroup groupDto)
        {
            return new CustomEntityGroupModel
            {
                CategoryName = groupDto.Name,
                Id = groupDto.Id
            };
        }

        public static CustomEntityTemplateModel MapToCustomEntityTemplateModel(Domain.CustomEntity.CustomEntity templateDto)
        {
            return new CustomEntityTemplateModel
            {
                TemplateName = templateDto.TemplateName,
                Id = templateDto.Id,
                GroupId = templateDto.EntityGroupId,
                GroupName = templateDto.CustomEntityGroup.Name
            };
        }

        public static List<CustomEntityGroupModel> MapToCustomEntityGroups(IEnumerable<Domain.CustomEntity.CustomEntityGroup> groups)
        {
            if (groups == null) return new List<CustomEntityGroupModel>();

            return groups.Select(x => new CustomEntityGroupModel
            {
                CategoryName = x.Name,
                Id = x.Id
            }).ToList();
        }

        public static List<CustomEntityTemplateModel> MapToCustomEntityTemplates(IEnumerable<Domain.CustomEntity.CustomEntity> templates)
        {
            if (templates == null) return new List<CustomEntityTemplateModel>();

            return templates.Select(x => new CustomEntityTemplateModel
            {
                TemplateName = x.TemplateName,
                Id = x.Id,
                GroupId = x.EntityGroupId,
                GroupName = x.CustomEntityGroup.Name
            }).ToList();
        }
    }
}
