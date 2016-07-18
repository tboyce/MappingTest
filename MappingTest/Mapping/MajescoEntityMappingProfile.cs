using System;
using AutoMapper;
using MappingTest.MmgModels;

namespace MappingTest.Mapping
{
    public class MajescoEntityMappingProfile<TDest> : Profile
    {
        public MajescoEntityMappingProfile()
        {
            CreateMap<Person, TDest>().ConvertUsing<TypeConverter>();
        }

        public override string ProfileName => "MajescoEntityMappingProfile";

        internal class TypeConverter : ITypeConverter<Person, TDest>
        {
            public TDest Convert(Person source, TDest destination, ResolutionContext context)
            {
                if (destination == null) destination = Activator.CreateInstance<TDest>();

                var destination1 = destination as dynamic;

                destination1.FirstName = source.Name.First;
                destination1.LastName = source.Name.Last;

                return destination;
            }
        }
    }
}