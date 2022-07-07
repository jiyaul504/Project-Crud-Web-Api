using Task.Models;
using TaskManually.Context;
using TaskManually.Data;
using TaskManually.ViewModels;

namespace TaskManually.Services
{
    public interface ICountryService
    {
        List<CountryDto> GetCountriesList();
        Country GetCountryDetailsById(int Id);
        ResponseModel SaveCountry(Country country);
        ResponseModel DeleteCountry(int Id);


    }
    public class CountryService : ICountryService
    {
        private TaskContext _context;
        public CountryService(TaskContext context)
        {
            _context = context;
        }

        public ResponseModel DeleteCountry(int Id)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Country _temp = GetCountryDetailsById(Id);
                if (_temp != null)
                {
                    _context.Remove<Country>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Country Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Country Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public Country GetCountryDetailsById(int Id)
        {
            Country country;
            try
            {
                country = _context.Find<Country>(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return country;
        }

        public List<CountryDto> GetCountriesList()
        {
            // List<Products> List;
            var list = new List<CountryDto>();

            // var ProductDTO=new ProductDto();
            try
            {
                list = _context.Country.Select(c => new CountryDto
                {
                    Code = c.Code,
                    Name = c.Name,
                    Continent_name = c.Continent_name
                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public ResponseModel SaveCountry(Country country)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Country _temp = GetCountryDetailsById(country.Code);
                if (_temp != null)
                {
                    _temp.Code = country.Code;
                    _temp.Name = country.Name;
                    _temp.Continent_name = country.Continent_name;
                    _context.Update<Country>(_temp);
                    model.Messsage = "Country Update Successfully";
                }
                else
                {
                    _context.Add<Country>(country);
                    model.Messsage = "Country Inserted Successfully";
                }
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;

        }
    }
}