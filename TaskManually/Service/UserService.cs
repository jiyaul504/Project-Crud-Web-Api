
using Task.Models;
using TaskManually.Context;
using TaskManually.Data;
using TaskManually.ViewModels;

namespace TaskManually.Services
{
    public interface IUserService
    {
        List<UserDto> GetUserList();
        User GetUserDetailsById(int Id);
        ResponseModel SaveUser(UserDto user);
        ResponseModel Deleteuser(int Id);


    }
    public class UserService : IUserService
    {
        private TaskContext _context;
        public UserService(TaskContext context)
        {
            _context = context;
        }

        public ResponseModel DeleteMerchant(int Id)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                User _temp = GetUserDetailsById(Id);
                if (_temp != null)
                {
                    _context.Remove<User>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "User Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "User Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public ResponseModel DeleteUser(int Id)
        {
            throw new NotImplementedException();
        }

        public ResponseModel Deleteuser(int Id)
        {
            throw new NotImplementedException();
        }

        public User GetUserDetailsById(int Id)
        {
            User user;
            try
            {
                user = _context.Find<User>(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return user;
        }

        public List<UserDto> GetUserList()
        {
            // List<User> List;
            var list = new List<UserDto>();

            // var UserDTO=new UserDto();
            try
            {
                list = _context.Users.Select(c => new UserDto
                {
                    Id = c.Id,
                    Full_Name = c.Full_Name,
                    Email = c.Email,
                    Gender = c.Gender,
                    DOB = c.DOB,
                    CountryCode = c.CountryCode,
                    Created_at = c.Created_at,

                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public User GetUsersDetailsById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<UserDto> GetUsersList()
        {
            throw new NotImplementedException();
        }

        public ResponseModel SaveMerchant(UserDto user)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                User _temp = GetUserDetailsById(user.Id);
                if (_temp != null)
                {
                    _temp.Id = user.Id;
                    _temp.Full_Name = user.Full_Name;
                    _temp.CountryCode = user.CountryCode;
                    _temp.Created_at = user.Created_at;
                    _temp.DOB = user.DOB;
                    _temp.Email= user.Email;
                    _temp.Gender = user.Gender; 
                    
                    _context.Update<User>(_temp);
                    model.Messsage = "User Update Successfully";
                }
                else
                {
                    var userinput = new User()
                    {
                        Id = user.Id,
                        Full_Name = user.Full_Name,
                        Email = user.Email,
                        Gender = user.Gender,
                        DOB = user.DOB,
                        Created_at = user.Created_at,
                        CountryCode = user.CountryCode,
                        
                    };
                    _context.Users.Add(userinput);
                    model.Messsage = "User Inserted Successfully";
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

        public ResponseModel SaveUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        User IUserService.GetUserDetailsById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}