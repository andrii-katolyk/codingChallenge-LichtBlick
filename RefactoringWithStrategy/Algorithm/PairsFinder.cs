using System.Collections.Generic;
using Algorithm.Models;
using Algorithm.Strategies;

namespace Algorithm
{
    public class PairsFinder
    {
        private readonly IList<Person> _persons;

        public PairsFinder(IList<Person> persons)
        {
            _persons = persons;
        }

        public IPersonsPair FindBy(PairingCriteria pairingCriteria)
        {
            var findingStrategy = GetFindingStrategy(pairingCriteria);
            return findingStrategy.Find(_persons);
        }

        private IPairsFindingStrategy GetFindingStrategy(PairingCriteria pairingCriteria) =>
            pairingCriteria switch
            {
                PairingCriteria.ClosestByAge => new PairsClosestByAgeFindingStrategy(),
                PairingCriteria.FurthestByAge => new PairsFurthestByAgeFindingStrategy(),
            };
    }
}