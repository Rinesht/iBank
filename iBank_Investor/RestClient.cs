using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Text;

public enum HttpVerb
{
    GET,
    POST,
    PUT,
    DELETE
}

/* Sample Comment21 */
namespace iBank_Investor
{
    public class RestClient
    {
        
        public string EndPoint { get; set; }
        public HttpVerb Method { get; set; }
        public string ContentType { get; set; }
        public string PostData { get; set; }

        public RestClient()
        {
            EndPoint = "";
            Method = HttpVerb.GET;
            ContentType = "text/xml";
            PostData = "";
        }
        public RestClient(string endpoint)
        {
            EndPoint = endpoint;
            Method = HttpVerb.GET;
            ContentType = "text/xml";
            PostData = "";
        }
        public RestClient(string endpoint, HttpVerb method)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "text/xml";
            PostData = "";
        }

        public RestClient(string endpoint, HttpVerb method, string postData)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "text/xml";
            PostData = postData;
        }


        public string MakeRequest(ref string statuscode)
        {
            return MakeRequest("", ref statuscode);
        }

        public string MakeRequest(string parameters, ref string statuscode)
        {
            var request = (HttpWebRequest)WebRequest.Create(EndPoint + parameters);
            statuscode = "500";

            request.Method = Method.ToString();
            request.ContentLength = 0;
            request.ContentType = ContentType;

            if (!string.IsNullOrEmpty(PostData) && Method == HttpVerb.POST)
            {
                var encoding = new UTF8Encoding();
                var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(PostData);
                request.ContentLength = bytes.Length;

                using (var writeStream = request.GetRequestStream())
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }
            }

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                var responseValue = string.Empty;


                statuscode = ((int)response.StatusCode).ToString();
                // if (response.StatusCode != HttpStatusCode.OK)
                if (!(response.StatusCode == HttpStatusCode.OK || (int)response.StatusCode == 451 || (int)response.StatusCode == 452))
                {
                    var message = String.Format("Request failed. Received HTTP {0}", response.StatusCode);
                    return "";
                    //throw new ApplicationException(message);

                }


                // grab the response
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                }
                return responseValue;

                //return response.GetResponseStream();
            }
            catch (Exception ex)
            {
                return "";
            }

                
            }
        
    }
}