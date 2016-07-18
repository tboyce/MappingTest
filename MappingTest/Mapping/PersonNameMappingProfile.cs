using System.Collections.Generic;
using AutoMapper;
using MappingTest.MmgModels;

namespace MappingTest.Mapping
{
    public class PersonNameMappingProfile : Profile
    {
        public override string ProfileName => "PersonNameMappingProfile";

        public PersonNameMappingProfile()
        {
            CreateMap<Dictionary<string, object>, PersonName>().ConvertUsing<DictionaryTypeConverter>();
        }

        internal class DictionaryTypeConverter : ITypeConverter<Dictionary<string, object>, PersonName>
        {
            public PersonName Convert(Dictionary<string, object> source, PersonName destination, ResolutionContext context)
            {
                if (destination == null) destination = new PersonName();

                destination.First = source["FirstName"] as string;
                destination.Last = source["LastName"] as string;

                return destination;
            }
        }
    }
}