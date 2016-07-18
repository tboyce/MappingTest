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

            TestModel1(mapper);
            TestModel2(mapper);
        }

        private static void TestModel1(IMapper mapper)
        {
            var model = new Model1
            {
                FirstName = "John",
                LastName = "Smith",
                SomeValue = "Test"
            };

            var person = mapper.Map<Person>(model);

            Console.WriteLine($"{person.Name.First} {person.Name.Last}");

            var model1 = mapper.Map<Model1>(person);

            Console.WriteLine($"{model1.FirstName} {model1.LastName}");
        }

        private static void TestModel2(IMapper mapper)
        {
            var model = new Model2
            {
                FirstName = "John",
                LastName = "Smith",
                SomeOtherValue = "Test"
            };

            var person = mapper.Map<Person>(model);

            Console.WriteLine($"{person.Name.First} {person.Name.Last}");

            var model1 = mapper.Map<Model1>(person);

            Console.WriteLine($"{model1.FirstName} {model1.LastName}");
        }

        private static IMapper ConfigureMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PersonMappingProfile<Model1>>();
                cfg.AddProfile<PersonMappingProfile<Model2>>();
                cfg.AddProfile<MajescoEntityMappingProfile<Model1>>();
                cfg.AddProfile<MajescoEntityMappingProfile<Model2>>();
            });
            return config.CreateMapper();
        }
    }
}