﻿namespace Gym_Fees.Entity
{
    public class Trainingprogram
    {
        public Guid  TrainingId { get; set; }
        public Guid MemberId { get; set; }
        public List<string> Cardio { get; set; }
        public List<string> Weighttraining { get; set; }
    }
}
