using System;
using System.Collections.Generic;
using System.Text;

namespace AtlasBot.Attributes
{
    public class CreatorAttribute : AttributeWithValue
    {
        public CreatorAttribute() { }

        public CreatorAttribute(string value)
        {
            this.Value = value;
            this.Prefix = "**Creator:**";
        }
    }
}
