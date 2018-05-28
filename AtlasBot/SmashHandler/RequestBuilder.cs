using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Static_Data;
using SmashHandler.Constant_data;

namespace SmashHandler
{
    public static class RequestBuilder
    {   
        private static CookieContainer AuthCookieContainer
        {
            get
            {
                var cookieContainer = new CookieContainer();
                cookieContainer.Add(Adresses.BaseUri, new Cookie("lad_sock_hash", OptionManager.SmashHash, "/", Adresses.Baseurl));
                cookieContainer.Add(Adresses.BaseUri, new Cookie("lad_sock_user_id", "78787", "/", Adresses.Baseurl));
                cookieContainer.Add(Adresses.BaseUri, new Cookie("lad_sock_remember_me", "bartdebever112%40outlook.com", "/", Adresses.Baseurl));
                return cookieContainer;
            }
        }

        public static HttpWebRequest GetRequest(string fullpath)
        {
            HttpWebRequest webRequest =
                (HttpWebRequest)WebRequest.Create(fullpath);

            webRequest.CookieContainer = AuthCookieContainer;
            webRequest.Method = "GET";
            return webRequest;
        }
        
    }
}
