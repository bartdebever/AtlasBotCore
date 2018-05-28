using System;
using System.Collections.Generic;
using System.Text;

namespace AtlasBot.Attributes
{
    public abstract class AttributeWithValue : Attribute
    {
        public AttributeWithValue() { }

        public AttributeWithValue(string value)
        {
            this.Value = value;
        }
        public string Value { get; set; }
        public string Prefix { get; set; }
    }
}
