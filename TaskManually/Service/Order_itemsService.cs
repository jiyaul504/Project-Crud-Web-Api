using Task.Models;
using TaskManually.Context;
using TaskManually.Data;
using TaskManually.ViewModels;

namespace TaskManually.Services
{
    public interface IOrderItemService
    {
        List<OrderItemDto> GetOrderItemList();
        Orderitems GetOrderItemDetailsById(int Id);
        ResponseModel SaveOrderItem(OrderItemDto order);
        ResponseModel DeleteOrderItem(int Id);


    }
    public class OrderItemService : IOrderItemService
    {
        private TaskContext _context;
        public OrderItemService(TaskContext context)
        {
            _context = context;
        }

        public ResponseModel DeleteOrderItem(int Id)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Orderitems _temp = GetOrderItemDetailsById(Id);
                if (_temp != null)
                {
                    _context.Remove<Orderitems>(_temp);
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

        public Orderitems GetOrderItemDetailsById(int Id)
        {
            Orderitems order;
            try
            {
                order = _context.Find<Orderitems>(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return order;
        }

        public List<OrderItemDto> GetOrderItemList()
        {
            // List<Products> List;
            var list = new List<OrderItemDto>();

            // var ProductDTO=new ProductDto();
            try
            {
                list = _context.Orderitems.Select(c => new OrderItemDto
                {
                    Id = c.Id,
                    OrdersId = c.OrdersId,
                    ProductId = c.ProductId,
                    Quantity = c.Quantity


                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public ResponseModel SaveOrderItem(OrderItemDto order)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Orderitems _temp = GetOrderItemDetailsById(order.Id);
                if (_temp != null)
                {
                    _temp.Id = order.Id;
                    _temp.OrdersId = order.OrdersId;
                    _temp.ProductId = order.ProductId;
                    _temp.Quantity = order.Quantity;
                    _context.Update<Orderitems>(_temp);
                    model.Messsage = "OrderItem Update Successfully";
                }
                else
                {
                    var input = new Orderitems()
                    {
                        OrdersId = order.OrdersId,
                        ProductId = order.ProductId,
                        Quantity = order.Quantity

                    };
                    _context.Orderitems.Add(input);
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

        Orderitems IOrderItemService.GetOrderItemDetailsById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}