namespace Application.Common.Mappings
{
    using AutoMapper;
    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
