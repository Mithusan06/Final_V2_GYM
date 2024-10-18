using Gym_Fees.Entity;

namespace Gym_Fees.Model.RequestDTO
{
    public class PaymentRequestDTO
    {
        public Guid MemberId { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public PaymentType PaymentType { get; set; }
    }
}
