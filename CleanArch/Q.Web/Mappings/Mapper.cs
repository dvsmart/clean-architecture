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
                AssessmentScopeId = assessmentRequestModel.ScopeId,
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
                PublishedDate = assessmentDto.PublishedDate,
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

        public static Domain.CustomEntity.CustomEntity MapToCustomEntityDto(CreateCustomTemplateRequest createCustomTemplateRequest)
        {
            return new Domain.CustomEntity.CustomEntity
            {
                TemplateName = createCustomTemplateRequest.TemplateName,
                AddedBy = 1,
                AddedDate = DateTime.Now,
                Id = createCustomTemplateRequest.Id,
                IsArchived = false,
                IsDeleted = false,
                EntityGroupId = createCustomTemplateRequest.GroupId
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

        public static CustomTemplateModel MapToCustomTemplates(Domain.CustomEntity.CustomEntityGroup group)
        {
            if (group == null) return new CustomTemplateModel();

            return new CustomTemplateModel
            {
                GroupId = group.Id,
                GroupName = group.Name,
                Templates = group.CustomEntities.Select(x => new CustomEntityTemplateModel
                {
                    TemplateName = x.TemplateName,
                    Id = x.Id,
                }).ToList()
            };
        }

        public static List<CustomEntityTemplateModel> MaptoCustomTemplates(IEnumerable<Domain.CustomEntity.CustomEntity> templates)
        {
            return templates.Select(x => new CustomEntityTemplateModel
            {
                Id = x.Id,
                TemplateName = x.TemplateName,
            }).ToList();
        }


        public static List<CustomEntityInstanceGridModel> MapToCustomEntityValueGridModel(IList<Domain.CustomEntity.CustomEntityInstance> customEntityInstances)
        {
            var recordModel = new List<CustomEntityInstanceGridModel>();
            if (customEntityInstances != null)
            {
                foreach (var item in customEntityInstances)
                {
                    recordModel.Add(new CustomEntityInstanceGridModel
                    {
                        Id = item.Id,
                        AddedOn = item.AddedDate,
                        DataId = item.DataId,
                        DueDate = item.DueDate ?? DateTime.Now.AddDays(5),
                        Status = item.Status == 1 ? "Draft" : "Published"
                    });
                }
            }
            return recordModel;
        }
    }
}
