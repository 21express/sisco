using SISCO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace RND
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("024-00010118".Substring(0, 4));
            Console.WriteLine("024-00010118".Substring(4, 4));
            Console.WriteLine("024-00010118".Substring(8, 4));
            decimal L = 68;
            decimal W = 22;
            decimal H = 11;
            decimal lwh = L + W + H + 18;
            Console.WriteLine(lwh);
            decimal vol = Math.Round(lwh / 3, MidpointRounding.AwayFromZero);
            Console.WriteLine(vol);

            Console.WriteLine("Test : " + Math.Truncate(300.20));
            
            //Console.WriteLine("AP009023".Substring(0, 2));
            //Console.WriteLine(DateTime.Now.Month);
            Console.WriteLine(Math.Round(833.46, 1, MidpointRounding.AwayFromZero).ToString("#,#"));

            //Console.WriteLine(Math.Floor(2.9).ToString("#,0.00"));
            //Console.WriteLine(Math.Round(66538 * (2.5/100), 1).ToString("#,#"));
            //Console.WriteLine(Math.Round(66530 * (2.5 / 100), 1).ToString("#,#"));
            //Console.WriteLine(Math.Round(66539 * (2.5 / 100), 1).ToString("#,#"));
            //Console.WriteLine(Math.Round(665543 * (2.5 / 100), 1).ToString("#,#"));

            //Console.WriteLine(Math.Round(66538 * (2.5 / 100), MidpointRounding.AwayFromZero).ToString("#,#"));
            //Console.WriteLine(Math.Round(66530 * (2.5 / 100), MidpointRounding.AwayFromZero).ToString("#,#"));
            //Console.WriteLine(Math.Round(66539 * (2.5 / 100), MidpointRounding.AwayFromZero).ToString("#,#"));
            //Console.WriteLine(Math.Round(665543 * (2.5 / 100), MidpointRounding.AwayFromZero).ToString("#,#"));

            //short trackingId = 9;
            //if (10 != trackingId && 19 != trackingId && 22 != trackingId) Console.WriteLine("test");

            //var client = new HttpClient();
            //client.BaseAddress = new Uri("http://pgchome/");
            //var uri = "express/api/v1/provinces";

            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("Token", "HESK+4TX33SN9F32RXCGKI/0X/YVXPSU+BJWURCQQLW01SIF10JV1OGADTXAB2HX");

            //var task = client.GetAsync(uri).ContinueWith((s) =>
            //{
            //    var response = s.Result;
            //    var jsonResponse = response.Content.ReadAsStringAsync();
            //    jsonResponse.Wait();

            //    var jsonConvert = new JavaScriptSerializer();
            //    var actionResult = jsonConvert.Deserialize<ProvinceModel>(jsonResponse.Result);
            //});

            //task.Wait();
            System.Threading.Thread.Sleep(1000000);
        }
    }
}