using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculator
{
    public class AgeSumEV
    {
        public int Age { get; set; }
        public int SumAssured { get; set; }
        public double Premium { get; set; }
    }
    public class LifePremium
    {
        public AgeSumEV GetPremium(int age, int sumAssured)
        {
            Validation val = new Validation(age, sumAssured);
            AgeSumEV ageSumEV = new AgeSumEV();
            if (val.Validate())
            {
                ageSumEV.Age = age;
                ageSumEV.SumAssured = sumAssured;

                PremiumCalculate pc = new PremiumCalculate(age, sumAssured);
                ageSumEV.Premium = pc.CalculatePremium();

                if (ageSumEV.Premium >= 2)
                    return ageSumEV;
                else
                {
                    ageSumEV.SumAssured = sumAssured + 5000;
                    return GetPremium(age, ageSumEV.SumAssured);
                }
            }
            return ageSumEV;      
        }
    }
}
