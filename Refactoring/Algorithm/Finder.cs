using System.Collections.Generic;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> _persons;

        public Finder(List<Person> persons)
        {
            _persons = persons;
        }

        public SearchResult Find(SearchCriteria searchCriteria)
        {
            var tr = new List<SearchResult>();

            for(var i = 0; i < _persons.Count - 1; i++)
            {
                for(var j = i + 1; j < _persons.Count; j++)
                {
                    var r = new SearchResult();
                    if(_persons[i].BirthDate < _persons[j].BirthDate)
                    {
                        r.YoungerPerson = _persons[i];
                        r.OlderPerson = _persons[j];
                    }
                    else
                    {
                        r.YoungerPerson = _persons[j];
                        r.OlderPerson = _persons[i];
                    }
                    r.AgeDifference = r.OlderPerson.BirthDate - r.YoungerPerson.BirthDate;
                    tr.Add(r);
                }
            }

            if(tr.Count < 1)
            {
                return new SearchResult();
            }

            SearchResult answer = tr[0];
            foreach(var result in tr)
            {
                switch(searchCriteria)
                {
                    case SearchCriteria.ClosestByAge:
                        if(result.AgeDifference < answer.AgeDifference)
                        {
                            answer = result;
                        }
                        break;

                    case SearchCriteria.FurthestByAge:
                        if(result.AgeDifference > answer.AgeDifference)
                        {
                            answer = result;
                        }
                        break;
                }
            }

            return answer;
        }
    }
}