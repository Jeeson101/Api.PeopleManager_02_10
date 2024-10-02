using PeopleManager.Dto.Requests;
using PeopleManager.Dto.Results;
using Vives.Services.model;
using Vives.Services.model.Extensions;

namespace PeopleManager.Services.Extensions.Validation
{
	public static class OrganizationValidator
	{
		public static void Validate(this ServiceResult<OrganizationResult> serviceResult, OrganizationRequest request)
		{

			if (string.IsNullOrWhiteSpace((request.Name)))
			{
				serviceResult.NotEmpty(nameof(request.Name));
			}

			//if (string.IsNullOrWhiteSpace((request.Description)))
			//{
			//	serviceResult.NotEmpty(nameof(request.Description));
			//}
		}
	}
}
