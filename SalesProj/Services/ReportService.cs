using SalesProj.Data;
using SalesProj.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProj.Services
{
    class ReportService
    {
        private readonly IReportRepository<Product, string> reportRepository;
        public ReportService(IReportRepository<Product, string> reportRepository)
        {
            this.reportRepository = reportRepository;
        }


        internal string TotalYearRead(string totalYearSum, string year)
        {
            string sum = totalYearSum;
            string passYear = year;
            return reportRepository.TotalYearRead(totalYearSum, passYear);
        }

        internal string TotalYearMonthRead(string totalYearMonthSum, string year, string month)
        {
            string sum = totalYearMonthSum;
            string passYear = year;
            string passMonth = month;
            return reportRepository.TotalYearMonthRead(totalYearMonthSum, passYear, passMonth);
        }
        internal IEnumerable<Product> TotalSalesYear(string year)
        {
            string passYear = year;
            return reportRepository.TotalSalesYear(passYear);
        }
        internal IEnumerable<Product> TotalSalesYearMonth(string year, string month)
        {
            string passYear = year;
            string passMonth = month;
            return reportRepository.TotalSalesYearMonth(passYear, passMonth);
        }
        internal IEnumerable<Product> SalesBetweenYear(string yearFrom, string yearToo)
        {
            yearFrom = yearFrom;
            yearToo = yearToo;
            return reportRepository.SalesBetweenYear(yearFrom, yearToo);
        }

    }
}
