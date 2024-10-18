namespace Gym_Fees.Model.RequestDTO
{
    public class PendingProgramRequestDTO
    {
        
        public Guid TrainingId { get; set; }
        public Guid MemberId { get; set; }

        public string Cardio { get; set; }
        public string Weighttraining { get; set; }
    }
}
