using AcerProCase.Entities.Concrete;
using AcerProCase.Repository.Abstract;
using Core.DataAccess.EntityFramework;

namespace AcerProCase.Repository.Concrete
{
    public class EfCountryInfoDal : EfEntityRepositoryBase<CountryInfo, AppDbContext>, ICountryInfoDal
    {
        public EfCountryInfoDal(AppDbContext context) : base(context)
        {
        }
    }
}
