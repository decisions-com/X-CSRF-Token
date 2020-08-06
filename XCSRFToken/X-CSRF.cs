using DecisionsFramework.Design.Flow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace XCSRFToken
{
    [AutoRegisterMethodsOnClass(true, "Integration/REST Services/Advanced")]
    public class X_CSRF
    {

        

        public async Task<SapParam> GetCSRF(string userName, string SAPpassword, string URI)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(
                                                                                                                        System.Text.Encoding.ASCII.GetBytes(
                                                                                                                                string.Format("{0}:{1}", userName.ToUpper(), SAPpassword))));
                httpClient.DefaultRequestHeaders.Add("X-CSRF-TOKEN", "fetch");
                HttpResponseMessage response = await httpClient.GetAsync(new Uri(URI));
                response.EnsureSuccessStatusCode();
                if (response.Content == null)
                    return null;
                String csrfToken = response.Headers.GetValues("X-CSRF-TOKEN").FirstOrDefault();
                string[] Cookie = response.Headers.GetValues("Set-Cookie").ToArray();

                var StringCookie = "";
                foreach (var s in Cookie)
                {
                    StringCookie = StringCookie + s.ToString();
                }


                var result = new SapParam() { Cookie = StringCookie, csrfToken = csrfToken, Cookies = Cookie };



                return result;

            }
            
        }

       


        public class SapParam
        {
            public string csrfToken { get; set; }
            public string Cookie { get; set; }

            public string[] Cookies { get; set; }
        }
    }
}
