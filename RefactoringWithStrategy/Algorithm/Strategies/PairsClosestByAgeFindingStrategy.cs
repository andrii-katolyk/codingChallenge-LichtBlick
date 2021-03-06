﻿using System.Collections.Generic;
using System.Linq;
using Algorithm.Models;

namespace Algorithm.Strategies
{
    public class PairsClosestByAgeFindingStrategy : PairsWithAgeDifferenceFindingStrategy
    {
        public override IPersonsPair Find(IList<Person> persons)
        {
            var personPairs = GetPersonPairsWithAgeDifference(persons);

            var targetPair = new PersonsPairWithAgeDifference();
            if (personPairs.Any())
            {
                targetPair = personPairs.OrderBy(pp => pp.AgeDifference).ToList().First();
            }

            return targetPair;
        }
    }
}