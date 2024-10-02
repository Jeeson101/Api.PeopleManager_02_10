using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleManager.Dto.Requests;
using PeopleManager.Dto.Results;
using Vives.Services.model;
using Vives.Services.model.Extensions;

namespace PeopleManager.Services.Extensions.Validation
{
	public static class PersonValidator
	{
		public static void Validate(this ServiceResult<PersonResult> serviceResult, PersonRequest request)
		{
			if (string.IsNullOrWhiteSpace(request.FirstName))
			{
				serviceResult.NotEmpty(nameof(request.FirstName));
			}

			if (string.IsNullOrWhiteSpace(request.LastName))
			{
				serviceResult.NotEmpty(nameof(request.LastName));
			}

			if (string.IsNullOrWhiteSpace(request.Email))
			{
				serviceResult.NotEmpty(nameof(request.Email));
			}
		}
	}
}
