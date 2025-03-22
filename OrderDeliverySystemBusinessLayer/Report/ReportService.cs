using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDeliverySystemBusinessLayer.Person;
using OrderDeliverySystemDataAccessLayer.People;
using ReportDeliverySystemDataAccessLayer.Report;

namespace OrderDeliverySystemBusinessLayer.Report
{
    public class ReportService
    {
        public ReportService(ReportDTO Report)
        {
            this.ReportReportID = Report.ReportID;
            this.ReportDate = Report.ReportDate;
            this.TotalOrders = Report.TotalOrders;
            this.Revenue = Report.Revenue;
            this.Expenses = Report.Expenses;
            this.NetProfit = Report.NetProfit;
            this.CreatedAt = Report.CreatedAt;
            this.UpdatedAt = Report.UpdatedAt;
            this.IsDeleted = Report.IsDeleted;
        }
        public ReportService() { }
        public int ReportReportID { get; set; }
        public string ReportDate { get; set; }
        public int TotalOrders { get; set; }
        public decimal Revenue { get; set; }
        public decimal Expenses { get; set; }
        public decimal NetProfit { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }


        public static ReportService Find(int ReportID)
        {
            ReportDTO Report = ReportData.Find(ReportID);
            return Report != null ? new ReportService(Report) : null;
        }

        public static List<ReportService> FindAll()
        {
            var ReportsList = ReportData.FindAll() ?? new List<ReportDTO>();
            return ReportsList.Select(Report => new ReportService(Report)).ToList();
        }

        public static int Delete(int ReportID)
        {
            return ReportData.Delete(ReportID);
        }

        public static int Add()
        {
            return ReportData.Add();
        }
    }
}
