using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;


namespace PremiumCalculator.Model
{
    public class PremiumCalculatorDBContext : DbContext
    {
        public DbSet<AgeGroup> AgeGroups { get; set; }
        public DbSet<SumAssured> SumAssureds { get; set; }
        
    }

    public class AgeGroup
    {
        public int AgeGroupId { get; set; }
        public int FromAge { get; set; }
        public int ToAge { get; set; }        
    }

    public class SumAssured
    {
        public int SumAssuredId { get; set; }
        public int FromSumValue { get; set; }
        public int ToSumValue { get; set; }        
    }

    public class AgeSumRate
    {
        public int AgeSumMappingId { get; set; }
        public AgeGroup AgeRange { get; set; }
        public SumAssured SumRange { get; set; }
        public double RiskRate { get; set; }
    }    
}
