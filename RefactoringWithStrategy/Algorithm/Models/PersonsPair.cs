namespace Algorithm.Models
{
    public interface IPersonsPair
    {
        Person Person1 { get; set; }

        Person Person2 { get; set; }
    }

    public class PersonsPair : IPersonsPair
    {
        public Person Person1 { get; set; }

        public Person Person2 { get; set; }
    }
}