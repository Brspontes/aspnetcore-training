using DevFreela.Payments.API.Models;
using System.Threading.Tasks;

namespace DevFreela.Payments.API.Services
{
    public class PaymentService : IPaymentService
    {
        public async Task<bool> Process(PaymentInfoInputModel paymentInfoInputModel)
        {
            return true;
        }
    }
}
