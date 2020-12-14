using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class PairsFinder
    {
        private readonly List<Person> _persons;

        public PairsFinder(List<Person> persons)
        {
            _persons = persons;
        }

        public PersonsPairWithAgeDifference FindBy(PairingCriteria pairingCriteria)
        {
            var personPairs = GetPersonPairsWithAgeDifference();

            var targetPair = new PersonsPairWithAgeDifference();
            if (personPairs.Any())
            {
                targetPair = FindPairByCriteria(personPairs, pairingCriteria);
            }

            return targetPair;
        }

        private List<PersonsPairWithAgeDifference> GetPersonPairsWithAgeDifference()
        {
            var personPairs = new List<PersonsPairWithAgeDifference>();

            for (var i = 0; i < _persons.Count - 1; i++)
            {
                for (var j = i + 1; j < _persons.Count; j++)
                {
                    var pair = new PersonsPairWithAgeDifference();
                    if (_persons[i].BirthDate < _persons[j].BirthDate)
                    {
                        pair.YoungerPerson = _persons[i];
                        pair.OlderPerson = _persons[j];
                    }
                    else
                    {
                        pair.YoungerPerson = _persons[j];
                        pair.OlderPerson = _persons[i];
                    }

                    pair.AgeDifference = pair.OlderPerson.BirthDate - pair.YoungerPerson.BirthDate;

                    personPairs.Add(pair);
                }
            }

            return personPairs;
        }

        private PersonsPairWithAgeDifference FindPairByCriteria(
            IEnumerable<PersonsPairWithAgeDifference> pairs,
            PairingCriteria criteria)
        {
            var sortedPairs = pairs.OrderBy(pp => pp.AgeDifference).ToList();

            var targetPair = criteria == PairingCriteria.ClosestByAge
                ? GetPairClosestByAge(sortedPairs)
                : GetPairFurthestByAge(sortedPairs);

            return targetPair;
        }

        private PersonsPairWithAgeDifference GetPairClosestByAge(IEnumerable<PersonsPairWithAgeDifference> pairs) => pairs.FirstOrDefault();

        private PersonsPairWithAgeDifference GetPairFurthestByAge(IEnumerable<PersonsPairWithAgeDifference> pairs) => pairs.LastOrDefault();
    }
}