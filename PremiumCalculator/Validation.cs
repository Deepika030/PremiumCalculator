using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculator
{
    public class Validation
    {
        private int _age;
        private int _sumAssured;
        public Validation(int age, int sumAssured)
        {
            _age = age;
            _sumAssured = sumAssured;
        }

        public bool Validate()
        {
            if (_age < 0)
                throw new NegativeAgeException();            

            if (_age < 18 || _age > 65)
                throw new AgeOutofRangeException();

            if (_sumAssured < 0)
                throw new NegativeSumAssuredException();

            if (_sumAssured < 25000 || _sumAssured > 500000)
                throw new SumAssuredOutOfRange();            

            return true;
        }
    }
}
