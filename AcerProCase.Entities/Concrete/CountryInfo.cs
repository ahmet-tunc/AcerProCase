using Core.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace AcerProCase.Entities.Concrete
{
    public class CountryInfo : Entity
    { 
        public string Name { get; set; }
        public string CapitalCity { get; set; }
        public string ShortName { get; set; }
        public string CountryCurrency { get; set; }
    }
}
//Property özellikleri (Required vb.) AppDbContext içerisinde verildi