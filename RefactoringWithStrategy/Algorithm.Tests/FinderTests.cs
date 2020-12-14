using System;
using System.Collections.Generic;
using Algorithm.Models;
using Xunit;

namespace Algorithm.Test
{
    public class FinderTests
    {
        readonly Person Sue = new Person { Name = "Sue", BirthDate = new DateTime(1950, 1, 1) };
        readonly Person Greg = new Person { Name = "Greg", BirthDate = new DateTime(1952, 6, 1) };
        readonly Person Sarah = new Person { Name = "Sarah", BirthDate = new DateTime(1982, 1, 1) };
        readonly Person Mike = new Person { Name = "Mike", BirthDate = new DateTime(1979, 1, 1) };

        [Fact]
        public void Returns_Empty_Results_When_Given_Empty_List()
        {
            var persons = new List<Person>();
            var pairsFinder = new PairsFinder(persons);

            var result = pairsFinder.FindBy(PairingCriteria.ClosestByAge);

            Assert.Null(result.Person1);
            Assert.Null(result.Person2);
        }

        [Fact]
        public void Returns_Empty_Results_When_Given_One_Person()
        {
            var persons = new List<Person> { Sue };
            var pairsFinder = new PairsFinder(persons);

            var result = pairsFinder.FindBy(PairingCriteria.ClosestByAge);

            Assert.Null(result.Person1);
            Assert.Null(result.Person2);
        }

        [Fact]
        public void Returns_Closest_Two_For_Two_People()
        {
            var persons = new List<Person> { Sue, Greg };
            var pairsFinder = new PairsFinder(persons);

            var result = pairsFinder.FindBy(PairingCriteria.ClosestByAge);

            Assert.Same(Sue, result.Person1);
            Assert.Same(Greg, result.Person2);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Two_People()
        {
            var persons = new List<Person> { Greg, Mike };
            var pairsFinder = new PairsFinder(persons);

            var result = pairsFinder.FindBy(PairingCriteria.FurthestByAge);

            Assert.Same(Greg, result.Person1);
            Assert.Same(Mike, result.Person2);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Four_People()
        {
            var persons = new List<Person> { Greg, Mike, Sarah, Sue };
            var pairsFinder = new PairsFinder(persons);

            var result = pairsFinder.FindBy(PairingCriteria.FurthestByAge);

            Assert.Same(Sue, result.Person1);
            Assert.Same(Sarah, result.Person2);
        }

        [Fact]
        public void Returns_Closest_Two_For_Four_People()
        {
            var persons = new List<Person> { Greg, Mike, Sarah, Sue };
            var pairsFinder = new PairsFinder(persons);

            var result = pairsFinder.FindBy(PairingCriteria.ClosestByAge);

            Assert.Same(Sue, result.Person1);
            Assert.Same(Greg, result.Person2);
        }
    }
}