using System;
using System.Collections.Generic;
using System.Text;

namespace MeleeHandler
{
    public class ContentWrapper
    {
        public RequestHandler SmashLoungeHandler { get; set; }
        public MediaContent MediaContent { get; set; }

        public ContentWrapper()
        {
            this.MediaContent = new MediaContent();
            this.SmashLoungeHandler = new RequestHandler();
        }
    }
}
