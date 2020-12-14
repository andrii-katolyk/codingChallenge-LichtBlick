using System.Collections.Generic;
using Algorithm.Models;

namespace Algorithm.Strategies
{
    public abstract class PairsWithAgeDifferenceFindingStrategy : IPairsFindingStrategy
    {
        public abstract IPersonsPair Find(IList<Person> persons);

        protected List<PersonsPairWithAgeDifference> GetPersonPairsWithAgeDifference(IList<Person> persons)
        {
            var personPairs = new List<PersonsPairWithAgeDifference>();

            for (var i = 0; i < persons.Count - 1; i++)
            {
                for (var j = i + 1; j < persons.Count; j++)
                {
                    var pair = new PersonsPairWithAgeDifference
                    {
                        Person1 = persons[i].BirthDate < persons[j].BirthDate ? persons[i] : persons[j],
                        Person2 = persons[i].BirthDate < persons[j].BirthDate ? persons[j] : persons[i]
                    };
                    
                    pair.AgeDifference = pair.Person2.BirthDate - pair.Person1.BirthDate;

                    personPairs.Add(pair);
                }
            }

            return personPairs;
        }
    }
}