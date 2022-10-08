using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcerProCase.WebUI.Models
{
    public class CountryViewModel
    {
        public List<CountryModel> CountryList { get; set; }
        public List<CountryInfoModel> DbCountryList { get; set; }
    }
}
