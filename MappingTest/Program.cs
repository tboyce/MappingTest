using System;
using AutoMapper;
using MappingTest.MajescoModels;
using MappingTest.Mapping;
using MappingTest.MmgModels;

namespace MappingTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var mapper = ConfigureMapping();

            var model1 = new Model1
            {
                FirstName = "John",
                LastName = "Smith",
                SomeValue = "Test"
            };

            var dict1 = model1.ToDictionary();
            var mapped1 = mapper.Map<PersonName>(dict1);

            Console.WriteLine($"{mapped1.First} {mapped1.Last}");

            var model2 = new Model2
            {
                FirstName = "John",
                LastName = "Smith",
                SomeOtherValue = "Test"
            };

            var dict2 = model2.ToDictionary();
            var mapped2 = mapper.Map<PersonName>(dict2);

            Console.WriteLine($"{mapped2.First} {mapped2.Last}");
        }

        private static IMapper ConfigureMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PersonNameMappingProfile>();
            });
            return config.CreateMapper();
        }
    }
}