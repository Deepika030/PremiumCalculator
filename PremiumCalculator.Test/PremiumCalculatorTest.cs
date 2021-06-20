using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculator.Test
{
    [TestFixture]
    public class PremiumCalculatorTest
    {
        [Test]
        public void PositiveAge()
        {
            LifePremium pc = new LifePremium();            
            Assert.Throws<NegativeAgeException>(() => pc.GetPremium(-4, 25000));            
        }

        [Test]
        public void AgeRange()
        {
            LifePremium pc = new LifePremium();
            Assert.Throws<AgeOutofRangeException>(() => pc.GetPremium(5, 25000));
        }

        [Test]
        public void NegativeSumAssured()
        {
            LifePremium pc = new LifePremium();
            Assert.Throws<NegativeSumAssuredException>(() => pc.GetPremium(25, -100000));
        }

        [Test]
        public void SumAssuredRange()
        {
            LifePremium pc = new LifePremium();
            Assert.Throws<SumAssuredOutOfRange>(() => pc.GetPremium(25, 1000));
        }

        [Test]
        //[TestCase(18, 25000, 2.11)]
        [TestCase(30, 50000, 2.59)]
        //[TestCase(49, 60000, 0)]
        public void PremiumValue(int age, int sumAssured, double result)
        {
            LifePremium pc = new LifePremium();
            AgeSumEV ageSumEV = pc.GetPremium(age, sumAssured);
            Assert.AreEqual(result, ageSumEV.Premium);
        }

    }
}
