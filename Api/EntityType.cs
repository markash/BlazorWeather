using System;

namespace Weather.Function
{
    [System.AttributeUsage(System.AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    class NameAttribute : Attribute
    {
        private readonly string _name;

        public NameAttribute(string name)
        {
            this._name = name;
        }

        public string Name { get => _name; }
    }

    [System.AttributeUsage(System.AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    class DescriptionAttribute : Attribute
    {
        private readonly string _description;

        public DescriptionAttribute(string description)
        {
            this._description = description;
        }

        public string Description { get => _description; }
    }

    public enum EntityType
    {
        [Name("Country"), Description("Country name")]
        Country,

        [Name("CountrySecondarySubdivision"), Description("County")]
        CountrySecondarySubdivision,

        [Name("CountrySubdivision"), Description("State or Province")]
        CountrySubdivision,

        [Name("CountryTertiarySubdivision"), Description("Named Area")]
        CountryTertiarySubdivision,

        [Name("Municipality"), Description("City / Town")]
        Municipality,

        [Name("MunicipalitySubdivision"), Description("Sub / Super City")]
        MunicipalitySubdivision,

        [Name("Neighbourhood"), Description("Neighbourhood")]
        Neighbourhood,

        [Name("PostalCodeArea"), Description("Postal Code / Zip Code")]
        PostalCodeArea
    }

    public static class EntityTypeExtensions
    {
        public static string ToName(this EntityType val)
        {
            NameAttribute[] attributes = (NameAttribute[])val
                .GetType()
                .GetField(val.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Name : string.Empty;
        }

        public static string ToDescription(this EntityType val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
                .GetType()
                .GetField(val.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}