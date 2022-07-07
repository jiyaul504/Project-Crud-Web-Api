
using Task.Models;
using TaskManually.Context;
using TaskManually.Data;
using TaskManually.ViewModels;

namespace TaskManually.Services
{
    public interface IOrderService
    {
        List<OrderDto> GetOrdersList();
        Orders GetOrdersDetailsById(int Id);
        ResponseModel SaveOrder(OrderDto order);
        ResponseModel DeleteOrder(int Id);


    }
    public class OrderService : IOrderService
    {
        private TaskContext _context;
        public OrderService(TaskContext context)
        {
            _context = context;
        }

        public ResponseModel DeleteOrder(int Id)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Orders _temp = GetOrderDetailsById(Id);
                if (_temp != null)
                {
                    _context.Remove<Orders>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Order Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Order Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public ResponseModel DeleteOrders(int Id)
        {
            throw new NotImplementedException();
        }

        public Orders GetOrderDetailsById(int Id)
        {
            Orders order;
            try
            {
                order = _context.Find<Orders>(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return order;
        }

        public List<OrderDto> GetOrdersList()
        {
            // List<Products> List;
            var list = new List<OrderDto>();

            // var ProductDTO=new ProductDto();
            try
            {
                list = _context.Orders.Select(c => new OrderDto
                {
                    Id = c.Id,
                    UserId = c.UserId,
                    Created_at = c.Created_at,
                    Status = c.Status


                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public ResponseModel SaveOrder(OrderDto order)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Orders _temp = GetOrderDetailsById(order.Id);
                if (_temp != null)
                {
                    _temp.Id = order.Id;
                    _temp.UserId = order.UserId;
                    _temp.Created_at = order.Created_at;
                    _temp.Status = order.Status;
                    _context.Update<Orders>(_temp);
                    model.Messsage = "OrderItem Update Successfully";
                }
                else
                {
                    var input = new Orders()
                    {
                        UserId = order.UserId,
                        Id = order.Id,
                        Status = order.Status,
                        Created_at = order.Created_at

                    };
                    _context.Orders.Add(input);
                    model.Messsage = "OrderItem Inserted Successfully";
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

        public ResponseModel SaveOrders(OrderDto order)
        {
            throw new NotImplementedException();
        }

        Orders IOrderService.GetOrdersDetailsById(int Id)
        {
            throw new NotImplementedException();
        }
        List<OrderDto> IOrderService.GetOrdersList()
        {
            throw new NotImplementedException();
        }

        public ResponseModel DeleteOrdersById(int Id)
        {
            throw new NotImplementedException();
        }

        public Orders GetOrdersDetailsById(int Id)
        {
            throw new NotImplementedException();
        }

        public ResponseModel SaveOrderItem(OrderDto order)
        {
            throw new NotImplementedException();
        }
    }
}