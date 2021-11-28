using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
 using System.Threading.Tasks;
using TheTopProject.Models;

namespace TheTopProject.Reports
{
    public class FinancialAnnualReport
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly TheTopDatabaseContext context;
        public FinancialAnnualReport(IWebHostEnvironment webHostEnvironment, TheTopDatabaseContext context)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;

        }


        #region Declaration
        int maxColumn = 4;
        Document _document;
        Font fontStyle;
        PdfPCell pdfCell;

        PdfPTable pdfTable = new PdfPTable(4);
        MemoryStream memoryStream = new MemoryStream();
        List<Customer> oSaless = new List<Customer>();

        #endregion
        public byte[] Report(List<Customer> oSaless)
        {
            this.oSaless = oSaless;

            _document = new Document();
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(10f, 20f, 10f, 20f);

            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

            fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter pdfWriter = PdfWriter.GetInstance(_document, memoryStream);
            _document.Open();
            float[] size = new float[maxColumn];
            for (var i = 0; i < maxColumn; i++)
            {
                if (i == 0)
                    size[i] = 20;
                else
                    size[i] = 100;
            }

            pdfTable.SetWidths(size);
            this.EmptyRow(7);
            this.ReportHeader();

            this.EmptyRow(40);
            this.ReportBody();
            this.EmptyRow(7);
            this.DetailsRow();

            pdfTable.HeaderRows = 10;

            _document.Add(pdfTable);
            _document.Close();
            return memoryStream.ToArray();
        }

        public void ReportHeader()
        {


            pdfCell = new PdfPCell(this.SetPageTitle());
            pdfCell.Colspan = maxColumn;
            pdfCell.Border = 0;
            pdfTable.AddCell(pdfCell);

            pdfTable.CompleteRow();
        }


        public PdfPTable SetPageTitle()
        {
            int maxColumn = 3;
            PdfPTable pdfPTable = new PdfPTable(maxColumn);


            fontStyle = FontFactory.GetFont("Tahoma", 18f, 1);
            pdfCell = new PdfPCell(new Phrase("Financial Annual Information", fontStyle));
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(pdfCell);
            pdfPTable.CompleteRow();

            fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            pdfCell = new PdfPCell(new Phrase("Of Year: " + DateTime.Now.Year.ToString(), fontStyle));
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(pdfCell);
            pdfPTable.CompleteRow();
            fontStyle = FontFactory.GetFont("Tahoma", 18f, 1);
            pdfCell = new PdfPCell(new Phrase("", fontStyle));
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(pdfCell);
            pdfPTable.CompleteRow();

            fontStyle = FontFactory.GetFont("Tahoma", 18f, 1);
            pdfCell = new PdfPCell(new Phrase("", fontStyle));
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(pdfCell);
            pdfPTable.CompleteRow();
            fontStyle = FontFactory.GetFont("Tahoma", 18f, 1);
            pdfCell = new PdfPCell(new Phrase("", fontStyle));
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(pdfCell);
            pdfPTable.CompleteRow();

            fontStyle = FontFactory.GetFont("Tahoma", 18f, 1);
            pdfCell = new PdfPCell(new Phrase("", fontStyle));
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(pdfCell);
            pdfPTable.CompleteRow();

            fontStyle = FontFactory.GetFont("Tahoma", 18f, 1);
            pdfCell = new PdfPCell(new Phrase("", fontStyle));
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(pdfCell);
            pdfPTable.CompleteRow();



            return pdfPTable;

        }


        private void EmptyRow(int nCount)
        {
            for (int i = 0; i < nCount; i++)
            {
                pdfCell = new PdfPCell(new Phrase("", fontStyle));
                pdfCell.Colspan = maxColumn;
                pdfCell.Border = 0;
                pdfCell.ExtraParagraphSpace = 0;
                pdfTable.AddCell(pdfCell);
                pdfTable.CompleteRow();
            }
        }
        private void DetailsRow()
        {
            fontStyle = FontFactory.GetFont("Tahoma", 13f, 4);
            pdfCell = new PdfPCell(new Phrase("Total Employee Sallary this Year: " + context.EmployeeAttendence.Where(x => x.LoginTime.Year == DateTime.Now.Year).Sum(x => x.Employee.Salary * x.NumberOfHours).ToString() + ".", fontStyle));
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfTable.AddCell(pdfCell);
            pdfTable.CompleteRow();

            fontStyle = FontFactory.GetFont("Tahoma", 13f, 4);
            pdfCell = new PdfPCell(new Phrase("Total Sells this year: " + context.Sales.Sum(x => x.Design.Cost) + ".", fontStyle));
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfTable.AddCell(pdfCell);
            pdfTable.CompleteRow();


            fontStyle = FontFactory.GetFont("Tahoma", 13f, 4);
            pdfCell = new PdfPCell(new Phrase("Total profits this year:  " + (0.1 * context.Sales.Sum(x => x.Design.Cost)) + ".", fontStyle));
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfTable.AddCell(pdfCell);
            pdfTable.CompleteRow();


        }
        public void ReportBody()
        {

            var fontStyleBold = FontFactory.GetFont("Tahoma", 10f, 1);
            fontStyle = FontFactory.GetFont("Tahoma", 7.5f, 0);

            #region Detail Table Header

            pdfCell = new PdfPCell(new Phrase("Month", fontStyleBold));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfTable.AddCell(pdfCell);


            pdfCell = new PdfPCell(new Phrase("Employee salary", fontStyleBold));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfTable.AddCell(pdfCell);


            pdfCell = new PdfPCell(new Phrase("Profits", fontStyleBold));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase("Losses", fontStyleBold));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell.BackgroundColor = BaseColor.LightGray;
            pdfTable.AddCell(pdfCell); 
            pdfTable.CompleteRow();

            #endregion

            #region Detail Table Body
            List<string> months = new List<string>
            {
               "January","February","March","April","May","June",
               "July","August","September","October","November","December"
            };
            for (int i = 1; i <= 12; i++)
            {
                pdfCell = new PdfPCell(new Phrase(months[i - 1], fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                if (i % 2 != 0)
                    pdfCell.BackgroundColor = BaseColor.White;
                else
                    pdfCell.BackgroundColor = BaseColor.LightGray;

                pdfTable.AddCell(pdfCell);


                pdfCell = new PdfPCell(new Phrase(context.EmployeeAttendence.Where(x => x.LoginTime.Date.Month == i && x.LoginTime.Date.Year == DateTime.Now.Year).Sum(x => (x.Employee.Salary*x.NumberOfHours)).ToString(), fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                if (i % 2 != 0)
                    pdfCell.BackgroundColor = BaseColor.White;
                else
                    pdfCell.BackgroundColor = BaseColor.LightGray;

                pdfTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase((0.1 * context.Sales.Where(x => x.Date.Month == i && x.Date.Year == DateTime.Now.Year).Sum(x => (x.Design.Cost.ToString() == null ? 0 : x.Design.Cost))).ToString(), fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                if (i % 2 != 0)
                    pdfCell.BackgroundColor = BaseColor.White;
                else
                    pdfCell.BackgroundColor = BaseColor.LightGray;

                pdfTable.AddCell(pdfCell);

                pdfCell = new PdfPCell(new Phrase(Math.Abs(i * .103 - i).ToString(), fontStyle));
                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                if (i % 2 != 0)
                    pdfCell.BackgroundColor = BaseColor.White;
                else
                    pdfCell.BackgroundColor = BaseColor.LightGray;

                pdfTable.AddCell(pdfCell);

                pdfTable.CompleteRow();

            }

            #endregion

        }
    }
}