﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xBSMeditation.MVVM.Models
{
    public class MahakaliMantraModel
    {
        public int NumberOfMantraCount { get; set; } //10 mala /day
        public int NumberOfBedInMala { get; set; } //108
        public int TotalNumberOfJapa { get; set; } // 10*108 = 1080
        public DateTime CreatedAt { get; set; }
    }
}
