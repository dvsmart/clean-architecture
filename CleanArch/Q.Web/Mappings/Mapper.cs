using Q.Web.Models.Assessment;
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
    }
}
