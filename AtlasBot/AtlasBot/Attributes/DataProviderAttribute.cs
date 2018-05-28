using System;
using System.Collections.Generic;
using System.Text;

namespace AtlasBot.Attributes
{
    public class DataProviderAttribute : AttributeWithValue
    {
        public DataProviderAttribute() { }

        public DataProviderAttribute(string value)
        {
            this.Value = value;
            this.Prefix = "**Data Provided By:**";
        }
    }
}
