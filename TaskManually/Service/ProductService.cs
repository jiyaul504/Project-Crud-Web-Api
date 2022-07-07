using Task.Models;
using TaskManually.Context;
using TaskManually.Data;
using TaskManually.ViewModels;

namespace TaskManually.Services
{
    public interface IProductService
    {
        List<ProductDto> GetOProductsList();
        Product GetProductDetailsById(int Id);
        ResponseModel SaveProduct(Product product);
        ResponseModel DeleteProduct(int Id);


    }
    public class ProductService : IProductService
    {
        private TaskContext _context;
        public ProductService(TaskContext context)
        {
            _context = context;
        }

        public ResponseModel DeleteProduct(int Id)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Product _temp = GetProductDetailsById(Id);
                if (_temp != null)
                {
                    _context.Remove<Product>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Product Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Product Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public Product GetProductDetailsById(int Id)
        {
            Product product;
            try
            {
                product = _context.Find<Product>(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return product;
        }

        public List<ProductDto> GetProductList()
        {
            // List<Products> List;
            var list = new List<ProductDto>();

            // var ProductDTO=new ProductDto();
            try
            {
                list = _context.Products.Select(c => new ProductDto
                {
                   
                    Name = c.Name,
                    Created_at=c.Created_at,
                    Price = c.Price,
                    MerchantId=c.MerchantId,
                    Status=c.Status,
                    
                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public ResponseModel SaveProduct(Product product)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Product _temp = GetProductDetailsById(product.Id);
                if (_temp != null)
                {
                    _temp.Name = product.Name;
                    _temp.Price =product .Price;
                    _temp.MerchantId = product.MerchantId;
                    _temp.Status = product.Status;
                    _temp.Created_at= product.Created_at;
                    
                    _context.Update<Product>(_temp);
                    model.Messsage = "Product Update Successfully";
                }
                else
                {
                    _context.Add<Product>(product);
                    model.Messsage = "Product Inserted Successfully";
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

        public ResponseModel DeleteProducts(int Id)
        {
            throw new NotImplementedException();
        }

        public List<CountryDto> GetCountriesList()
        {
            throw new NotImplementedException();
        }

        public Country GetCountryDetailsById(int Id)
        {
            throw new NotImplementedException();
        }

        public ResponseModel SaveCountry(Country country)
        {
            throw new NotImplementedException();
        }

        public ResponseModel DeleteCountry(int Id)
        {
            throw new NotImplementedException();
        }

        public List<ProductDto> GetOProductsList()
        {
            throw new NotImplementedException();
        }
    }
}