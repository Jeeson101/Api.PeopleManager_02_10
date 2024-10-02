using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace PeopleManager.Sdk.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddApi(this IServiceCollection services, string apiUrl)
		{
			services.AddHttpClient("PeopleManagerApi", options => { options.BaseAddress = new Uri(apiUrl); });

			services.AddScoped<OrganizationSdk>();

			return services;
		}
	}
}
