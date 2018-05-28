using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotWrapper.Services
{
    public abstract class Service
    {
        protected string ApiKey = "";

        public Service(string apiKey)
        {
            this.ApiKey = apiKey;
        }
    }
}
