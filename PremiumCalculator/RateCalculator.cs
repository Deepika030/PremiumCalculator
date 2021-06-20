using PremiumCalculator.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculator
{
    public class RateCalculator
    {
        private int _age;
        private int _sumAssured;
        private List<AgeSumRate> _ageSumMappingList;
        private List<SumAssured> _sumAssureds;        

        public RateCalculator(int age, int sumAssured, List<AgeSumRate> ageSumMapping)
        {
            _age = age;
            _sumAssured = sumAssured;
            _ageSumMappingList = ageSumMapping;            
        }        

        public double GetRate()
        {
            double rate = 0;
            rate = GetSumAssuredMatchingRate();

            if (rate > 0)
                return rate;
            else
                return CalculateRate();
        }

        private double GetSumAssuredMatchingRate()
        {
            if (_ageSumMappingList.Exists(x => x.SumRange is null))
            {
                return 0; //matching sum assured not found
            }

            AgeSumRate ageSumRate = _ageSumMappingList.Find(x => x.AgeRange.FromAge <= _age && _age <= x.AgeRange.ToAge
                                             && x.SumRange.FromSumValue == _sumAssured);

            if (ageSumRate != null)
                return ageSumRate.RiskRate;
            else return 0;
        }

        private double CalculateRate()
        {
            //((Sum assured – Lower band sum assured)/ (Upper band sum assured – Lower band sum assured)
            //*Upper band risk rate + (Upper band sum assured – Sum assured)/ (Upper band sum assured – Lower band sum assured) *Lower band risk rate)

            AgeSumRate ageSumRate = _ageSumMappingList.Find(x => x.AgeRange.FromAge <= _age && _age <= x.AgeRange.ToAge
                                             && x.SumRange.FromSumValue <= _sumAssured && _sumAssured < x.SumRange.ToSumValue);
            int lowerBandSumAssured = 0, upperBandSumAssured = 0;
            double lowerRiskRate = 0, upperRiskRate = 0;
            if (ageSumRate != null)
            {
                lowerBandSumAssured = ageSumRate.SumRange.FromSumValue;
                upperBandSumAssured = ageSumRate.SumRange.ToSumValue;

                lowerRiskRate = ageSumRate.RiskRate;
                upperRiskRate = _ageSumMappingList.Find(x => x.AgeRange.FromAge <= _age && _age <= x.AgeRange.ToAge
                                             && x.SumRange.FromSumValue == upperBandSumAssured).RiskRate;
            }

            return (Math.Round(Convert.ToDouble(Convert.ToDouble(_sumAssured - lowerBandSumAssured) / Convert.ToDouble(upperBandSumAssured - lowerBandSumAssured)), 4) * upperRiskRate)
                 + (Math.Round(Convert.ToDouble(Convert.ToDouble(upperBandSumAssured - _sumAssured) / Convert.ToDouble(upperBandSumAssured - lowerBandSumAssured)), 4) * lowerRiskRate);
            
        }
    }
}
