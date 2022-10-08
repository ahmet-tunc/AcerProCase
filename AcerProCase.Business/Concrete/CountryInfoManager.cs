using AcerProCase.Business.Abstract;
using AcerProCase.Business.Concrete.Base;
using AcerProCase.Business.Constants;
using AcerProCase.Business.FluentValidation;
using AcerProCase.Business.Mapping;
using AcerProCase.Entities.Concrete;
using AcerProCase.Entities.Concrete.DTOs.Request;
using AcerProCase.Entities.Concrete.DTOs.Response;
using AcerProCase.Repository.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using CountryInfoService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcerProCase.Business.Concrete
{
    public class CountryInfoManager : BaseManager<CountryInfo>, ICountryInfoService
    {
        private readonly CountryInfoServiceSoapType _countryInfoService;
        private readonly ICountryInfoDal _countryInfoDal;

        public CountryInfoManager(CountryInfoServiceSoapType countryInfoService, ICountryInfoDal countryInfoDal) : base(countryInfoDal)
        {
            _countryInfoService = countryInfoService;
            _countryInfoDal = countryInfoDal;
        }


        [CacheAspect(20)]
        public async Task<IDataResult<List<CountryInfoResponse>>> ListOfCountryNamesByCodeAsync()
        {
            var result = await _countryInfoService.ListOfCountryNamesByCodeAsync(new ListOfCountryNamesByCodeRequest(new ListOfCountryNamesByCodeRequestBody()));
            if (result != null)
            {
                var list = BusinessMapper.Mapper.Map<List<CountryInfoResponse>>(result.Body.ListOfCountryNamesByCodeResult);
                return new SuccessDataResult<List<CountryInfoResponse>>(list, Message.GetAll);
            }
            return new ErrorDataResult<List<CountryInfoResponse>>(Message.GetAllFailed);
        }


        public async Task<IDataResult<Entities.Concrete.DTOs.Response.CountryNameResponse>> GetCountryShortNameAsync(CountryRequest entity)
        {
            var result = await _countryInfoService.CountryISOCodeAsync(new CountryISOCodeRequest(new CountryISOCodeRequestBody(entity.Name)));
            if (result != null)
            {
                var model = new Entities.Concrete.DTOs.Response.CountryNameResponse 
                { 
                    Name = result.Body.CountryISOCodeResult
                };
                return new SuccessDataResult<Entities.Concrete.DTOs.Response.CountryNameResponse>(model, Message.Get);
            }
            return new ErrorDataResult<Entities.Concrete.DTOs.Response.CountryNameResponse>(Message.GetFailed);
        }

        public async Task<IDataResult<Entities.Concrete.DTOs.Response.CountryNameResponse>> GetCapitalCityAsync(CountryRequest entity)
        {
            var result = await _countryInfoService.CapitalCityAsync(new CapitalCityRequest(new CapitalCityRequestBody(entity.Name)));
            if (result != null)
            {
                var model = new Entities.Concrete.DTOs.Response.CountryNameResponse
                {
                    Name = result.Body.CapitalCityResult
                };
                return new SuccessDataResult<Entities.Concrete.DTOs.Response.CountryNameResponse>(model, Message.Get);
            }
            return new ErrorDataResult<Entities.Concrete.DTOs.Response.CountryNameResponse>(Message.GetFailed);
        }

        public async Task<IDataResult<CountryInfoResponse>> GetCountryCurrencyAsync(CountryRequest entity)
        {
            var result = await _countryInfoService.CountryCurrencyAsync(new CountryCurrencyRequest(new CountryCurrencyRequestBody(entity.Name)));
            if (result != null)
            {
                var model = BusinessMapper.Mapper.Map<CountryInfoResponse>(result.Body.CountryCurrencyResult);
                return new SuccessDataResult<CountryInfoResponse>(model, Message.GetAll);
            }
            return new ErrorDataResult<CountryInfoResponse>(Message.GetFailed);
        }



        // Burada, servis içerisinde bulunan FullCountryInfo metodunun kullanılması daha uygun olacaktır. Atılan dökümanda, o metodu kullanmam istenilmediği için kullanmadım.
        public async Task<IDataResult<CountryInfo>> GetCountryInfoAsync(CountryInfoRequest entity)
        {
            var capitalCity = await GetCapitalCityAsync(new CountryRequest { Name = entity.ShortName });
            var countryCurrency = await GetCountryCurrencyAsync(new CountryRequest { Name = entity.ShortName });

            var model = new CountryInfo
            {
                Name = entity.Name,
                ShortName = entity.ShortName,
                CapitalCity = capitalCity.Data.Name,
                CountryCurrency = $"{countryCurrency.Data.Name}({countryCurrency.Data.ShortName})"
            };

            return new SuccessDataResult<CountryInfo>(model, Message.Get);
        }


        [ValidationAspect(typeof(CountryValidator))]
        public override async Task<IResult> AddAsync(CountryInfo entity)
        {
            var checkExistingRecord = await _countryInfoDal.GetAsync(x => x.ShortName == entity.ShortName);
            if (checkExistingRecord.Success)
                return new ErrorResult(Message.ExistingRecord);

            return await base.AddAsync(entity);
        }


    }
}
