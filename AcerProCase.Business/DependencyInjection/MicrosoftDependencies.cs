using AcerProCase.Business.Abstract;
using AcerProCase.Business.Concrete;
using AcerProCase.Repository.Abstract;
using AcerProCase.Repository.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ServiceModel;

namespace AcerProCase.Business.DependencyInjection
{
    public static class MicrosoftDependencies
    {
        public static void AddCustomDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(o => o.UseSqlServer(configuration["ConnectionStrings:SqlConnection"]));

            services.AddSingleton<CountryInfoService.CountryInfoServiceSoapType>(provider =>
            {
                CountryInfoService.CountryInfoServiceSoapTypeClient client = new CountryInfoService.CountryInfoServiceSoapTypeClient(GetBindingHttp(), GetEndPoint("Services:CountryInfoService", configuration));
                return client;
            });

            services.AddScoped<ICountryInfoService, CountryInfoManager>();
            services.AddScoped<ICountryInfoDal, EfCountryInfoDal>();
        }

        public static EndpointAddress GetEndPoint(string confKey, IConfiguration configuration)
        {
            return new EndpointAddress(configuration[confKey]);
        }

        public static BasicHttpBinding GetBindingHttp()
        {
            BasicHttpBinding binding = new BasicHttpBinding
            {
                MaxBufferSize = int.MaxValue,
                ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max,
                MaxReceivedMessageSize = int.MaxValue,
                AllowCookies = true
            };
            binding.Security.Mode = BasicHttpSecurityMode.None;
            return binding;
        }


    }
}
