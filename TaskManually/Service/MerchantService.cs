
using Task.Models;
using TaskManually.Context;
using TaskManually.Data;
using TaskManually.ViewModels;

namespace TaskManually.Services
{
    public interface IMerchantService
    {
        List<MerchantDto> GetMerchantList();
        Merchants GetMerchantDetailsById(int Id);
        ResponseModel SaveMerchant(MerchantDto merchant);
        ResponseModel DeleteMerchant(int Id);


    }
    public class MerchantService : IMerchantService
    {
        private TaskContext _context;
        public MerchantService(TaskContext context)
        {
            _context = context;
        }

        public ResponseModel DeleteMerchant(int Id)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Merchants _temp = GetMerchantDetailsById(Id);
                if (_temp != null)
                {
                    _context.Remove<Merchants>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Merchant Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Merchant Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public Merchants GetMerchantDetailsById(int Id)
        {
            Merchants merchant;
            try
            {
                merchant = _context.Find<Merchants>(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return merchant;
        }

        public List<MerchantDto> GetMerchantList()
        {
            // List<Products> List;
            var list = new List<MerchantDto>();

            // var ProductDTO=new ProductDto();
            try
            {
                list = _context.Merchants.Select(c => new MerchantDto
                {
                    Id = c.Id,
                    Merchant_name = c.Merchant_name,
                    CountryCode = c.CountryCode,
                    Created_at = c.Created_at,
                    UserId = c.UserId

                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public ResponseModel SaveMerchant(MerchantDto merchant)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Merchants _temp = GetMerchantDetailsById(merchant.Id);
                if (_temp != null)
                {
                    _temp.Id = merchant.Id;
                    _temp.Merchant_name = merchant.Merchant_name;
                    _temp.CountryCode = merchant.CountryCode;
                    _temp.Created_at = merchant.Created_at;
                    _temp.UserId = merchant.UserId;
                    _context.Update<Merchants>(_temp);
                    model.Messsage = "Merchant Update Successfully";
                }
                else
                {
                    var merchantinput = new Merchants()
                    {
                        Merchant_name = merchant.Merchant_name,
                        Created_at = merchant.Created_at,
                        CountryCode = merchant.CountryCode,
                        UserId = merchant.UserId
                    };
                    _context.Merchants.Add(merchantinput);
                    model.Messsage = "Merchant Inserted Successfully";
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

        Merchants IMerchantService.GetMerchantDetailsById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}