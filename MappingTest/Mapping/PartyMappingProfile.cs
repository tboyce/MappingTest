using AutoMapper;
using MappingTest.MmgModels;

namespace MappingTest.Mapping
{
    public class PersonMappingProfile<TSource> : Profile
    {
        public PersonMappingProfile() : base("PersonMappingProfile")
        {
            CreateMap<TSource, Person>().ConvertUsing<TypeConverter>();
        }

        internal class TypeConverter : ITypeConverter<TSource, Person>
        {
            public Person Convert(TSource source, Person destination, ResolutionContext context)
            {
                if (destination == null) destination = new Person();
                if (destination.Name == null) destination.Name = new PersonName();

                var source1 = source as dynamic;
                destination.Name.First = source1.FirstName;
                destination.Name.Last = source1.LastName;

                return destination;
            }
        }
    }
}