using AutoMapper;
using MappingTest.MmgModels;

namespace MappingTest.Mapping
{
    public class MajescoEntityMappingProfile<TDest> : Profile
        where TDest : new()
    {
        public MajescoEntityMappingProfile() : base("MajescoEntityMappingProfile")
        {
            CreateMap<Person, TDest>().ConvertUsing<TypeConverter>();
        }

        internal class TypeConverter : ITypeConverter<Person, TDest>
        {
            public TDest Convert(Person source, TDest destination, ResolutionContext context)
            {
                if (destination == null) destination = new TDest();

                var destination1 = destination as dynamic;

                destination1.FirstName = source.Name.First;
                destination1.LastName = source.Name.Last;

                return destination;
            }
        }
    }
}