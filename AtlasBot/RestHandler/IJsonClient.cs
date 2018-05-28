using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;

namespace RestHandler
{
    public interface IJsonClient
    {
        object Send(string endpoint, Method method, Type type);
    }
}
