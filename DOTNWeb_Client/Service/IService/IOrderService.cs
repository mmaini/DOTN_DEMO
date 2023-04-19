using DOTN_Models;

namespace DOTNWeb_Client.Service.IService
{
    public interface IOrderService
    {
        public Task<IEnumerable<OrderDTO>> GetAll(string? userId);
        public Task<OrderDTO> Get(int orderId);
        public Task<OrderDTO> Create(StripePaymentDTO paymentDTO);
        Task<OrderHeaderDTO> MarkPaymentSuccessful(OrderHeaderDTO orderHeader);
    }
}
