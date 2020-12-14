using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> _persons;

        public Finder(List<Person> persons)
        {
            _persons = persons;
        }

        public PersonsPairWithAgeDifference Find(SearchCriteria searchCriteria)
        {
            var personPairs = GetPersonPairsWithAgeDifference();

            var targetPair = new PersonsPairWithAgeDifference();
            if (personPairs.Any())
            {
                targetPair = GetPairByCriteria(personPairs, searchCriteria);
            }

            return targetPair;
        }

        private PersonsPairWithAgeDifference GetPairByCriteria(
            IEnumerable<PersonsPairWithAgeDifference> pairs,
            SearchCriteria criteria)
        {
            var sortedPairs = pairs.OrderBy(pp => pp.AgeDifference).ToList();

            var targetPair = criteria == SearchCriteria.ClosestByAge
                ? GetPairClosestByAge(sortedPairs)
                : GetPairFurthestByAge(sortedPairs);

            return targetPair;
        }

        private PersonsPairWithAgeDifference GetPairClosestByAge(IEnumerable<PersonsPairWithAgeDifference> pairs) => pairs.FirstOrDefault();

        private PersonsPairWithAgeDifference GetPairFurthestByAge(IEnumerable<PersonsPairWithAgeDifference> pairs) => pairs.LastOrDefault();

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
    }
}