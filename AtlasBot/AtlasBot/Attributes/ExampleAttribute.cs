using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace AtlasBot.Attributes
{
    public class ExampleAttribute : AttributeWithValue
    {
        public ExampleAttribute() { }

        public ExampleAttribute(string value)
        {
            this.Value = value;
            this.Prefix = "**Example:**";
        }
    }
}
