using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculator
{
    public class NegativeAgeException : Exception
    {
        public override string Message => String.Format("Age cannot be negative.");
    }

    public class AgeOutofRangeException : Exception
    {
        public override string Message => String.Format("Age must be between 18 and 65."); 
    }

    public class NegativeSumAssuredException : Exception
    {
        public override string Message => String.Format("Sum assured cannot be negative");
    }
    public class SumAssuredOutOfRange : Exception
    {
        public override string Message => String.Format("Sum assured must be between £25,000 and £500,000.");
    }
}
