using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace ArticleJsonFetch.Models
{
    internal class HttpJsonSerializer
    {
        public Object obj = new();
        public bool isJson = false;

        public HttpJsonSerializer()
        {
        }

        public void DeserializeToJson(ref string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return;
            }
            try
            {
                obj = JsonConvert.DeserializeObject<object>(str)!;
                if(obj != null)
                {
                    isJson = true;
                }
            }
            catch (ArgumentNullException e)
            {
                Debug.WriteLine("Exception Caught!");
                Debug.WriteLine("Message :{0}\n{1} ", e.Message, e.StackTrace);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception Caught!");
                Debug.WriteLine("Message :{0}\n{1} ", e.Message, e.StackTrace);
            }
        }
    }
}
