using PremiumCalculator.Model;
using System;
using System.Collections.Generic;

namespace PremiumCalculator
{
    public class PremiumCalculate
    {
        #region Members
            
        private int _age;
        private int _sumAssured;
        private double _premium;
        private List<AgeSumRate> _ageSumMappingList;
        private readonly int RENEWAL_COMMISSION_PERCENTAGE = 3;
        private readonly int INITIAL_COMMISSION_PERCENTAGE = 205;

        #endregion
        
        public PremiumCalculate(int age, int sumAssured, List<AgeSumRate> rates)
        {
            _age = age;
            _sumAssured = sumAssured;
            _ageSumMappingList = rates;
        }

        #region Public Methods

        public double CalculatePremium()
        {
            Calculate();
            return _premium;
        }
        #endregion

        #region Private Methods
        private void Calculate()
        {
            RateCalculator rateCalc = new RateCalculator(_age, _sumAssured, _ageSumMappingList);

            double riskRate = rateCalc.GetRate();
            double riskPremium = GetRiskPremium(riskRate);
            double renewableCommission = GetRenewableCommission(riskPremium);
            double netPremium = riskPremium + renewableCommission;
            double initialCommission = GetInitialCommission(netPremium);
            _premium = Math.Round(netPremium + initialCommission, 2);
        }

        private double GetRiskPremium(double riskRate)
        {
            return riskRate * (_sumAssured / 1000);
        }

        private double GetRenewableCommission(double riskPremium)
        {
            return (RENEWAL_COMMISSION_PERCENTAGE * riskPremium) / 100;
        }
        
        private double GetInitialCommission(double netPremium)
        {
            return (netPremium * INITIAL_COMMISSION_PERCENTAGE) / 100;
        }
        #endregion
    }
}
