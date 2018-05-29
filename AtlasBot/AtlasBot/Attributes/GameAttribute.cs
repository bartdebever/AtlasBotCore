using System;
using System.Collections.Generic;
using System.Text;

namespace AtlasBot.Attributes
{
    public class GameAttribute : AttributeWithValue
    {
        public GameAttribute()
        {
            
        }

        public GameAttribute(string value)
        {
            this.Value = value;
            this.Prefix = "**Game:**";
        }
    }
}
