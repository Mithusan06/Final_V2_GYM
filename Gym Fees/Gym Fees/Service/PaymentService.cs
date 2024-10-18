using Gym_Fees.Entity;
using Gym_Fees.IRepo;
using Gym_Fees.IService;
using Gym_Fees.Model.RequestDTO;
using Gym_Fees.Model.ResponseDTO;
using Gym_Fees.Repository;

namespace Gym_Fees.Service
{
    public class PaymentService:IPaymentService
    {
       
            private readonly IPaymentRepo _paymentRepositary;

            public PaymentService(IPaymentRepo paymentRepositary)
            {
                _paymentRepositary = paymentRepositary;
            }

        public List<PaymentResponseDTO> GetAllPaymentDetails()
        {
            try
            {
                var data = _paymentRepositary.GetAllPaymentDetails();
                var list = new List<PaymentResponseDTO>();
                foreach (var item in data)
                {
                    var paymentRequestDTO = new PaymentResponseDTO()
                    {
                        MemberId = item.MemberId,
                        PaymentId = item.PaymentId,
                        Amount = item.Amount,
                        PaymentDate = item.PaymentDate,
                        NextpaymentDate = item.NextpaymentDate,
                        PaymentMethod = item.PaymentMethod,
                        PaymentStatus = item.PaymentStatus,
                        PaymentType = item.PaymentType
                    };

                    list.Add(paymentRequestDTO);
                }

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllPaymentDetails: {ex.Message}");
                throw; 
            }
        }

        public List<PaymentResponseDTO> GetAllByPaymentId(Guid paymentId)
        {
            try
            {
                var data = _paymentRepositary.GetAllByPaymentId(paymentId);
                var list = new List<PaymentResponseDTO>();
                foreach (var item in data)
                {
                    var paymentRequestDTO = new PaymentResponseDTO()
                    {
                        MemberId = item.MemberId,
                        Amount = item.Amount,
                        PaymentId = item.PaymentId,
                        PaymentDate = item.PaymentDate,
                        NextpaymentDate = item.NextpaymentDate,
                        PaymentMethod = item.PaymentMethod,
                        PaymentStatus = item.PaymentStatus,
                        PaymentType = item.PaymentType
                    };

                    list.Add(paymentRequestDTO);
                }

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllByPaymentId: {ex.Message}");
                throw; // Rethrow or handle as per your requirement
            }
        }

        public List<PaymentResponseDTO> GetAllByMemberId(Guid memberId)
        {
            try
            {
                var data = _paymentRepositary.GetAllByMemberId(memberId);
                var list = new List<PaymentResponseDTO>();
                foreach (var item in data)
                {
                    var paymentRequestDTO = new PaymentResponseDTO()
                    {
                        PaymentId = item.PaymentId,
                        MemberId = item.MemberId,
                        PaymentMethod = item.PaymentMethod,
                        Amount = item.Amount,
                        PaymentDate = item.PaymentDate,
                        NextpaymentDate = item.NextpaymentDate,
                        PaymentStatus = item.PaymentStatus,
                        PaymentType = item.PaymentType
                    };
                    list.Add(paymentRequestDTO);
                }

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllByMemberId: {ex.Message}");
                throw; // Rethrow or handle as per your requirement
            }
        }

        public PaymentResponseDTO AddPayment(PaymentRequestDTO payment)
        {
            try
            {
                var item = new Payment()
                {
                    MemberId = payment.MemberId,
                    Amount = payment.Amount,
                    PaymentMethod = payment.PaymentMethod,
                    PaymentType = payment.PaymentType,
                    PaymentDate = DateTime.Now,
                    NextpaymentDate = DateTime.Now.AddMonths(1)
                };

                var data = _paymentRepositary.AddPayment(item);
                DateTime currentDate = DateTime.Now;

                var paymentResponseDTO = new PaymentResponseDTO()
                {
                    Amount = data.Amount,
                    MemberId = data.MemberId,
                    PaymentStatus = data.PaymentStatus,
                    PaymentType = data.PaymentType,
                    PaymentMethod = data.PaymentMethod,
                    PaymentDate = currentDate,
                    NextpaymentDate = currentDate.AddMonths(1)
                };

                return paymentResponseDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddPayment: {ex.Message}");
                throw; // Rethrow or handle as per your requirement
            }
        }





        public List<PaymentResponseDTO> GetAllByPaymentStatus(PaymentStatus paymentStatus)
        {
            try
            {
                var data = _paymentRepositary.GetAllByPaymentStatus(paymentStatus);
                var list = new List<PaymentResponseDTO>();
                foreach (var item in data)
                {
                    var paymentRequestDTO = new PaymentResponseDTO()
                    {
                        PaymentId = item.PaymentId,
                        MemberId = item.MemberId,
                        Amount = item.Amount,
                        PaymentDate = item.PaymentDate,
                        NextpaymentDate = item.NextpaymentDate,
                        PaymentMethod = item.PaymentMethod,
                        PaymentStatus = item.PaymentStatus,
                        PaymentType = item.PaymentType
                    };
                    list.Add(paymentRequestDTO);
                }

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllByPaymentStatus: {ex.Message}");
                throw; // Rethrow or handle as per your requirement
            }
        }


    }

}

  
