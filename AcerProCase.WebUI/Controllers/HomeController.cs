using AcerProCase.Business.Abstract;
using AcerProCase.Entities.Concrete;
using AcerProCase.Entities.Concrete.DTOs.Request;
using AcerProCase.WebUI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcerProCase.WebUI.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly ICountryInfoService _countryInfoService;

        public HomeController(ILogger<HomeController> logger, ICountryInfoService countryInfoService, IMapper mapper)
        {
            _logger = logger;
            _countryInfoService = countryInfoService;
            _mapper = mapper;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            
            var countryList = await _countryInfoService.ListOfCountryNamesByCodeAsync();
            var dbCountryList = await _countryInfoService.GetAllAsync();
            var model = new CountryViewModel
            {
                CountryList = _mapper.Map<List<CountryModel>>(countryList.Data),
                DbCountryList = _mapper.Map<List<CountryInfoModel>>(dbCountryList.Data)
            };
            return View(model);
        }

        [HttpPost("CountryInfo")]
        public IActionResult CountryInfo(CountryInfoRequest input)
        {
            return ViewComponent("CountryInfoComponent", input);
        }


        [HttpPost("GetCountryShortNameAsync")]
        public async Task<IActionResult> GetCountryShortNameAsync([FromBody] CountryRequest input)
        {
            var result = await _countryInfoService.GetCountryShortNameAsync(input);
            if (!result.Success)
                ViewBag.Error = result.Message;
            return Json(result.Data);
        }


        [HttpPost("GetCapitalCityAsync")]
        public async Task<IActionResult> GetCapitalCityAsync([FromBody] CountryRequest input)
        {
            var result = await _countryInfoService.GetCapitalCityAsync(input);
            if (!result.Success)
                ViewBag.Error = result.Message;
            return Json(result.Data);
        }

        [HttpPost("GetCountryCurrencyAsync")]
        public async Task<IActionResult> GetCountryCurrencyAsync([FromBody] CountryRequest input)
        {
            var result = await _countryInfoService.GetCountryCurrencyAsync(input);
            if (!result.Success)
                ViewBag.Error = result.Message;
            return Json(result.Data);
        }


        [HttpPost("CountryInfoAddAsync")]
        public async Task<JsonResult> CountryInfoAddAsync([FromBody] CountryInfoModel input)
        {
            var result = await _countryInfoService.AddAsync(_mapper.Map<CountryInfo>(input));
            return Json(result);
        }
    }
}
