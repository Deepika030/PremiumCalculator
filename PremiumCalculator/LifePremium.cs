using PremiumCalculator.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculator
{
    public class PremiumResponse
    {
        public int Age { get; set; }
        public int SumAssured { get; set; }
        public double Premium { get; set; }
        public bool SumAssuredAdjusted { get; set; }
    }
    public class LifePremium
    {
        public readonly int MINIMUM_PREMIUM_AMOUNT = 2;
        public readonly int SUM_ASSURED_INCREMENT = 5000;

        CalculationInitialise _initialiseCalc;
        Validation _validator ;
        public LifePremium()
        {
            _initialiseCalc = new CalculationInitialise();
            _validator = new Validation(_initialiseCalc.AgeGroups, _initialiseCalc.SumAssureds);
        }

        public PremiumResponse GetPremium(int age, int sumAssured)
        {   
            PremiumResponse ageSumEV = new PremiumResponse();            
            ageSumEV.Age = age;
            ageSumEV.SumAssured = sumAssured;
            CalculatePremium(ageSumEV);                
            return ageSumEV;      
        }

        private void CalculatePremium(PremiumResponse premiumResponse)
        {
            if (_validator.Validate(premiumResponse.Age, premiumResponse.SumAssured))
            {
                PremiumCalculate pc = new PremiumCalculate(premiumResponse.Age, premiumResponse.SumAssured, _initialiseCalc.Rates);
                premiumResponse.Premium = pc.CalculatePremium();

                if (premiumResponse.Premium >= MINIMUM_PREMIUM_AMOUNT)
                    return;
                else
                {
                    premiumResponse.SumAssured = premiumResponse.SumAssured + SUM_ASSURED_INCREMENT;
                    premiumResponse.SumAssuredAdjusted = true;
                    CalculatePremium(premiumResponse);
                }
            }
        }
    }
}
