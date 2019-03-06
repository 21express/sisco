using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpBarcodePrinting
{
    public class ReportDataSource
    {
        public List<ReportModel> ListReportModels { get; set; }

        public static List<ReportModel> GetDataSource()
        {
            var listReportModel = new List<ReportModel>();
            listReportModel.AddRange(new[]
            {
                new ReportModel
                {
                    Address = "Address 01",
                    Name = "Tiffany Taylor",
                    NumberOfEmployee = 54656656,
                    WebSites = "www.google.com"
                },
                new ReportModel
                {
                    Address = "Address 02",
                    Name = "Ashnel",
                    NumberOfEmployee = 135735675,
                    WebSites = "www.yahoo.com"
                },
                new ReportModel
                {
                    Address = "Address 03",
                    Name = "Asari Kyo",
                    NumberOfEmployee = 34553434,
                    WebSites = "www.bing.com"
                },
                new ReportModel
                {
                    Address = "Address 04",
                    Name = "Sunny Leone",
                    NumberOfEmployee = 78979778,
                    WebSites = "www.twitter.com"
                },
                new ReportModel
                {
                    Address = "Address 05",
                    Name = "Monica Ableh",
                    NumberOfEmployee = 1123207756,
                    WebSites = "www.path.com"
                }
            });

            return listReportModel;
        }
    }
}
