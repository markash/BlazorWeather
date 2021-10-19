using System;

namespace Enums
{
    public static class ServiceExtensions
    {
        public static string ToUri(this Service val)
        {
            ServiceUriAttribute[] attributes = (ServiceUriAttribute[])val
                .GetType()
                .GetField(val.ToString())
                .GetCustomAttributes(typeof(ServiceUriAttribute), false);

            return attributes.Length > 0 ? attributes[0].Uri : string.Empty;
        }
    }  
}