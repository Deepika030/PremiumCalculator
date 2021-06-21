using PremiumCalculator.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PremiumCalculator
{
    public class Validation
    {
        private List<AgeGroup> _ageGroups;
        private List<SumAssured> _sumAssureds;
        public Validation(List<AgeGroup> ageGroups, List<SumAssured> sumAssureds)
        {
            _ageGroups = ageGroups;
            _sumAssureds = sumAssureds;            
        }

        public bool Validate(int age, int sumAssured)
        {
            if (age < 0)
                throw new NegativeAgeException();            

            if (age < _ageGroups.Min(x => x.FromAge) || age > _ageGroups.Max(x => x.ToAge))
                throw new AgeOutofRangeException();

            if (sumAssured < 0)
                throw new NegativeSumAssuredException();

            if (sumAssured < _sumAssureds.Min(x => x.FromSumValue) || sumAssured > _sumAssureds.Max(x => x.ToSumValue))
                throw new SumAssuredOutOfRange();            

            return true;
        }
    }
}
