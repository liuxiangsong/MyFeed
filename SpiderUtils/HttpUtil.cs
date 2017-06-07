using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SpiderUtils
{
   public static class HttpUtil
    {
       public static JObject Get(string url)
       {
           HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:38.0) Gecko/20100101 Firefox/38.0"; 
            string source;
           using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
           {
               #region 
               if (response.ContentEncoding.ToLower().Contains("gzip")) //解压
               {
                   using (GZipStream stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
                   {
                       using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                       {
                           source = reader.ReadToEnd();
                       }
                   }
               }
               else if (response.ContentEncoding.ToLower().Contains("deflate")) //解压
               {
                   using (var stream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress))
                   {
                       using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                       {
                           source = reader.ReadToEnd();
                       }

                   }
               }
               else
               {
                   using (Stream stream = response.GetResponseStream())
                   {
                       using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                       {
                           source = reader.ReadToEnd();
                       }
                   }
               } 
               #endregion
               return JObject.Parse(source);
           }
       }

       public static bool DownLoadFile(string url,string path)
       {
           try
           {
               url = url.Trim();
               HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
               request.Method = "GET";
               request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:38.0) Gecko/20100101 Firefox/38.0";
               using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
               {
                   using (Stream responseStream = response.GetResponseStream())
                   {
                       Stream stream = new FileStream(path, FileMode.Create);
                       byte[] bArr = new byte[1024];
                       int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                       while (size > 0)
                       {
                           stream.Write(bArr, 0, size);
                           size = responseStream.Read(bArr, 0, (int)bArr.Length);
                       }
                       stream.Close();
                   }
               }
               return true;
           }
           catch (Exception ex)
           {
               return false;
           }
       }
    }
}
