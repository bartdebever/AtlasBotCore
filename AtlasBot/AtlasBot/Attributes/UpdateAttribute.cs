using System;
using System.Collections.Generic;
using System.Text;

namespace AtlasBot.Attributes
{
    public class UpdateAttribute : AttributeWithValue
    {
        public UpdateAttribute()
        {
            
        }

        public UpdateAttribute(string value)
        {
            this.Value = value;
            this.Prefix = "**Last Updated:**";
        }
    }
}
