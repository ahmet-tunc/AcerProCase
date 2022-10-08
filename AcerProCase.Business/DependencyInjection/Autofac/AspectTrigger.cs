using AcerProCase.Business.Abstract;
using AcerProCase.Business.Concrete;
using AcerProCase.Repository.Abstract;
using AcerProCase.Repository.Concrete;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace AcerProCase.Business.DependencyInjection.Autofac
{
    public class AspectTrigger:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<CountryInfoManager>().As<ICountryInfoService>();
            //builder.RegisterType<EfCountryInfoDal>().As<ICountryInfoDal>();
            //builder.RegisterType<CountryInfoService.CountryInfoServiceSoapTypeClient>().As<CountryInfoService.CountryInfoServiceSoapType>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
