using AcerProCase.Business.Abstract.Base;
using AcerProCase.Entities.Concrete;
using AcerProCase.Entities.Concrete.DTOs.Request;
using AcerProCase.Entities.Concrete.DTOs.Response;
using Core.Utilities.Results.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcerProCase.Business.Abstract
{
    public interface ICountryInfoService : IBaseService<CountryInfo>
    {
        Task<IDataResult<List<CountryInfoResponse>>> ListOfCountryNamesByCodeAsync();
        Task<IDataResult<CountryNameResponse>> GetCountryShortNameAsync(CountryRequest entity);
        Task<IDataResult<CountryNameResponse>> GetCapitalCityAsync(CountryRequest entity);
        Task<IDataResult<CountryInfoResponse>> GetCountryCurrencyAsync(CountryRequest entity);
        Task<IDataResult<CountryInfo>> GetCountryInfoAsync(CountryInfoRequest entity);
    }
}
