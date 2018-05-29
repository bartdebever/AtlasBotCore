using System;
using System.Collections.Generic;
using System.Text;

namespace AtlasBot.Attributes
{
    public class ContributionAttribute : AttributeWithValue
    {
        public ContributionAttribute()
        {
            
        }

        public ContributionAttribute(string value)
        {
            this.Value = value;
            this.Prefix = "**Contributor(s):**";
        }
    }
}
