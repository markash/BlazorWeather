using System;


namespace Enums
{
    [System.AttributeUsage(System.AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    class ServiceUriAttribute : Attribute
    {
        private readonly string _uri;

        public ServiceUriAttribute(string uri)
        {
            this._uri = uri;
        }

        public string Uri { get => _uri; }
    }

    public enum Service{
        [ServiceUri("weather")]
        Weather,

        [ServiceUri("search")]
        Search
    }
}