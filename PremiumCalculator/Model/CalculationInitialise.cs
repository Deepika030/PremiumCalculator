using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculator.Model
{
    public class CalculationInitialise
    {
        List<AgeSumRate> _ageSumMappingList = new List<AgeSumRate>();
        List<AgeGroup> _ages = new List<AgeGroup>();
        List<SumAssured> _sumAssureds = new List<SumAssured>();

        public List<AgeSumRate> Rates { get { return _ageSumMappingList; } }
        public List<SumAssured> SumAssureds { get { return _sumAssureds; } }
        public List<AgeGroup> AgeGroups { get { return _ages; } }
        public CalculationInitialise()
        {
            InitialiseAgeGroup();
            InitialiseSumAssured();
            InitialiseRate();
        }

        private void InitialiseAgeGroup()
        {
            _ages = new List<AgeGroup>
            {
                new AgeGroup() { AgeGroupId = 1, FromAge = 18, ToAge = 30 },
                new AgeGroup() { AgeGroupId = 2, FromAge = 31, ToAge = 50 },
                new AgeGroup() { AgeGroupId = 3, FromAge = 51, ToAge = 65 }
            };
        }

        private void InitialiseSumAssured()
        {
            _sumAssureds = new List<SumAssured>
            {
                new SumAssured() { SumAssuredId = 1, FromSumValue = 25000, ToSumValue = 50000},
                new SumAssured() { SumAssuredId = 2, FromSumValue = 50000, ToSumValue = 100000},
                new SumAssured() { SumAssuredId = 3, FromSumValue = 100000, ToSumValue = 200000},
                new SumAssured() { SumAssuredId = 4, FromSumValue = 200000, ToSumValue = 300000},
                new SumAssured() { SumAssuredId = 5, FromSumValue = 300000, ToSumValue = 500000},
                new SumAssured() { SumAssuredId = 5, FromSumValue = 500000, ToSumValue = 500000}
            };
        }

        private void InitialiseRate()
        {
            AgeSumRate ageSum = new AgeSumRate()
            {
                AgeRange = _ages.Find(x => x.FromAge == 18),
                SumRange = _sumAssureds.Find(x => x.FromSumValue == 25000),
                RiskRate = 0.0172
            };

            _ageSumMappingList.Add(ageSum);

            ageSum = new AgeSumRate()
            {
                AgeRange = _ages.Find(x => x.FromAge == 18),
                SumRange = _sumAssureds.Find(x => x.FromSumValue == 50000),
                RiskRate = 0.0165
            };

            _ageSumMappingList.Add(ageSum);

            ageSum = new AgeSumRate()
            {
                AgeRange = _ages.Find(x => x.FromAge == 18),
                SumRange = _sumAssureds.Find(x => x.FromSumValue == 100000),
                RiskRate = 0.0154
            };

            _ageSumMappingList.Add(ageSum);

            ageSum = new AgeSumRate()
            {
                AgeRange = _ages.Find(x => x.FromAge == 18),
                SumRange = _sumAssureds.Find(x => x.FromSumValue == 200000),
                RiskRate = 0.0147
            };

            _ageSumMappingList.Add(ageSum);

            ageSum = new AgeSumRate()
            {
                AgeRange = _ages.Find(x => x.FromAge == 18),
                SumRange = _sumAssureds.Find(x => x.FromSumValue == 300000),
                RiskRate = 0.0144
            };

            _ageSumMappingList.Add(ageSum);

            ageSum = new AgeSumRate()
            {
                AgeRange = _ages.Find(x => x.FromAge == 18),
                SumRange = _sumAssureds.Find(x => x.FromSumValue == 500000),
                RiskRate = 0.0146
            };

            _ageSumMappingList.Add(ageSum);

            ageSum = new AgeSumRate()
            {
                AgeRange = _ages.Find(x => x.FromAge == 31),
                SumRange = _sumAssureds.Find(x => x.FromSumValue == 25000),
                RiskRate = 0.1043
            };

            _ageSumMappingList.Add(ageSum);

            ageSum = new AgeSumRate()
            {
                AgeRange = _ages.Find(x => x.FromAge == 31),
                SumRange = _sumAssureds.Find(x => x.FromSumValue == 50000),
                RiskRate = 0.0999
            };

            _ageSumMappingList.Add(ageSum);

            ageSum = new AgeSumRate()
            {
                AgeRange = _ages.Find(x => x.FromAge == 31),
                SumRange = _sumAssureds.Find(x => x.FromSumValue == 100000),
                RiskRate = 0.0932
            };

            _ageSumMappingList.Add(ageSum);

            ageSum = new AgeSumRate()
            {
                AgeRange = _ages.Find(x => x.FromAge == 31),
                SumRange = _sumAssureds.Find(x => x.FromSumValue == 200000),
                RiskRate = 0.0887
            };

            _ageSumMappingList.Add(ageSum);
            ageSum = new AgeSumRate()
            {
                AgeRange = _ages.Find(x => x.FromAge == 31),
                SumRange = _sumAssureds.Find(x => x.FromSumValue == 300000),
                RiskRate = 0.0872
            };

            _ageSumMappingList.Add(ageSum);
            ageSum = new AgeSumRate()
            {
                AgeRange = _ages.Find(x => x.FromAge == 31),
                SumRange = _sumAssureds.Find(x => x.FromSumValue == 500000),
                RiskRate = 0
            };

            _ageSumMappingList.Add(ageSum);
            ageSum = new AgeSumRate()
            {
                AgeRange = _ages.Find(x => x.FromAge == 51),
                SumRange = _sumAssureds.Find(x => x.FromSumValue == 25000),
                RiskRate = 0.2677
            };

            _ageSumMappingList.Add(ageSum);
            ageSum = new AgeSumRate()
            {
                AgeRange = _ages.Find(x => x.FromAge == 51),
                SumRange = _sumAssureds.Find(x => x.FromSumValue == 50000),
                RiskRate = 0.2565
            };

            _ageSumMappingList.Add(ageSum);
            ageSum = new AgeSumRate()
            {
                AgeRange = _ages.Find(x => x.FromAge == 51),
                SumRange = _sumAssureds.Find(x => x.FromSumValue == 100000),
                RiskRate = 0.2393
            };

            _ageSumMappingList.Add(ageSum);
            ageSum = new AgeSumRate()
            {
                AgeRange = _ages.Find(x => x.FromAge == 51),
                SumRange = _sumAssureds.Find(x => x.FromSumValue == 200000),
                RiskRate = 0.2285
            };

            _ageSumMappingList.Add(ageSum);
            ageSum = new AgeSumRate()
            {
                AgeRange = _ages.Find(x => x.FromAge == 51),
                SumRange = _sumAssureds.Find(x => x.FromSumValue == 300000),
                RiskRate = 0
            };

            _ageSumMappingList.Add(ageSum);
            ageSum = new AgeSumRate()
            {
                AgeRange = _ages.Find(x => x.FromAge == 51),
                SumRange = _sumAssureds.Find(x => x.FromSumValue == 500000),
                RiskRate = 0
            };

            _ageSumMappingList.Add(ageSum);
        }

        
    }

    }
