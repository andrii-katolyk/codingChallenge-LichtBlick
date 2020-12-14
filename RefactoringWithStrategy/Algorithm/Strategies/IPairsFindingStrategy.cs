using System.Collections.Generic;
using Algorithm.Models;

namespace Algorithm.Strategies
{
    public interface IPairsFindingStrategy
    {
        IPersonsPair Find(IList<Person> persons);
    }
}