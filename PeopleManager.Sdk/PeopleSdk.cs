using System.Net.Http.Json;
using PeopleManager.Dto.Requests;
using PeopleManager.Dto.Results;
using Vives.Services.model;
using Vives.Services.model.Extensions;

namespace PeopleManager.Sdk
{
	public class PeopleSdk(IHttpClientFactory httpClientFactory)
	{
		private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

		public async Task<IList<PersonResult>> Find()
		{
			var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
			
			var route = "People";
			var response = await httpClient.GetAsync(route);

			response.EnsureSuccessStatusCode();

			var result = await response.Content.ReadFromJsonAsync<IList<PersonResult>>();

			if (result is null)
			{
				return new List<PersonResult>();
			}

			return result;
		}

		public async Task<ServiceResult<PersonResult>> Get(int id)
		{
			var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
			var route = $"People/{id}";
			var response = await httpClient.GetAsync(route);
			response.EnsureSuccessStatusCode();
			var result = await response.Content.ReadFromJsonAsync<ServiceResult<PersonResult>>();

			if (result is null)
			{
				result = new ServiceResult<PersonResult>();
				result.NotFound(nameof(PersonResult), id);
			}

			return result;
		}

		public async Task<ServiceResult<PersonResult>> Create(PersonRequest request)
		{
			var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
			var route = "People";
			var response = await httpClient.PostAsJsonAsync(route, request);
			response.EnsureSuccessStatusCode();
			var result = await response.Content.ReadFromJsonAsync<ServiceResult<PersonResult>>();

			if (result is null)
			{
				return new ServiceResult<PersonResult>() { Data = new PersonResult { FirstName = string.Empty, LastName = string.Empty} };
			}

			return result;
		}

		public async Task<ServiceResult<PersonResult>> Update(int id, PersonRequest request)
		{
			var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
			var route = $"People/{id}";
			var response = await httpClient.PutAsJsonAsync(route, request);
			response.EnsureSuccessStatusCode();
			var result = await response.Content.ReadFromJsonAsync<ServiceResult<PersonResult>>();

			if (result is null)
			{
				return new ServiceResult<PersonResult>() { Data = new PersonResult { FirstName = string.Empty, LastName = string.Empty } };
			}
			
			return result;
			
		}

		public async Task<ServiceResult<PersonResult>> Delete(int id)
		{
			var httpClient = _httpClientFactory.CreateClient("PeopleManagerApi");
			var route = $"People/{id}";
			var response = await httpClient.DeleteAsync(route);
			response.EnsureSuccessStatusCode();
			var result = await response.Content.ReadFromJsonAsync<ServiceResult<PersonResult>>();

			if (result is null)
			{
				result = new ServiceResult<PersonResult>();
				result.NotFound(nameof(PersonResult), id);
			}

			return result;
		}
	}
}
