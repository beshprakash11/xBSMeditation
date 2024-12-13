﻿namespace meditation.Core.Models.Dto.CreateDto
{
    public class AdditionalMantraModelCreateDto:BaseModel
    {
        public string MantraName { get; set; }
        public int NumberOfMantraCount { get; set; } //10 mala /day
        public int NumberOfBedInMala { get; set; } //108
        public int TotalNumberOfJapa { get; set; } // 10*108 = 1080
        public DateTime CreatedAt { get; set; }
    }
}
