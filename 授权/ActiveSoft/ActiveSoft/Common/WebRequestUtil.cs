using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ActiveClient.Common
{
   public  class WebRequestUtil
    {
       public string  webquers2(string url,string data)
       {

           WebRequest request = WebRequest.Create(url);
           // Set the Method property of the request to POST.
           request.Method = "POST";
           // Create POST data and convert it to a byte array.

         //  System.Xml.XmlDocument xmlpostdata = new System.Xml.XmlDocument();
        //   xmlpostdata.Load(Server.MapPath("XML/20097.xml"));
           string postData = HttpUtility.HtmlEncode(data);


           //普通字符串内容
           //string postData = "你好，1232355 abdcde";


           byte[] byteArray = Encoding.UTF8.GetBytes(postData);
           // Set the ContentType property of the WebRequest.
          // request.ContentType = "application/x-www-form-urlencoded";
           // Set the ContentLength property of the WebRequest.
           request.ContentLength = byteArray.Length;
           // Get the request stream.
           Stream dataStream = request.GetRequestStream();

           // Write the data to the request stream.
           dataStream.Write(byteArray, 0, byteArray.Length);
           // Close the Stream object.
           dataStream.Close();
           // Get the response.
           WebResponse response = request.GetResponse();
           // Display the status.
           //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
           // Get the stream containing content returned by the server.
           dataStream = response.GetResponseStream();
           // Open the stream using a StreamReader for easy access.
           StreamReader reader = new StreamReader(dataStream);
           // Read the content.
           string responseFromServer = reader.ReadToEnd();
           // Display the content.
           //Console.WriteLine(responseFromServer);
           // Clean up the streams.
           reader.Close();
           dataStream.Close();
           response.Close();
           return responseFromServer;
       }

    }
}
