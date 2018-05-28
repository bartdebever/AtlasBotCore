using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MeleeHandler
{
    public class MeleeClient
    {
        public ContentWrapper ContentWrapper { get; set; }

        public MeleeClient()
        {
            this.ContentWrapper = new ContentWrapper();
        }
    }
}
