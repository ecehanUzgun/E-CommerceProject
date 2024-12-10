using MODEL.Entities;
using MVC.Models.PaymentAPITools;

namespace MVC.Models.RequestModels
{
    public class OrderRequestPageVM
    {
        public PaymentRequestModel PaymentRequestModel { get; set; }
        public Order Order { get; set; }

    }
}
