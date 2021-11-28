using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
 using System.Threading.Tasks;
using TheTopProject.Models;

namespace TheTopProject.Reports
{
    public class SalarySlip
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly TheTopDatabaseContext context;
        const string EAName = "EAname";

        const string AEName = "AEname";
        public SalarySlip(IWebHostEnvironment webHostEnvironment, TheTopDatabaseContext context)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;

        }


        #region Declaration
        int maxColumn = 3;
        Document _document;
        Font fontStyle;
        PdfPCell pdfCell;

        PdfPTable pdfTable = new PdfPTable(3);
        MemoryStream memoryStream = new MemoryStream();
        string name;
        int id;
       
        #endregion
        public byte[] Report(string name, int id)
        {
            this.name = name;
            this.id = id;
            _document = new Document();
            _document.SetPageSize(PageSize.A6);
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
            this.ReportHeader( name);

            this.EmptyRow(4);
            //this.ReportBody();
            this.EmptyRow(7);
            this.DetailsRow();

            pdfTable.HeaderRows = 10;

            _document.Add(pdfTable);
            _document.Close();
            return memoryStream.ToArray();
        }

        public void ReportHeader(string name)
        {


            pdfCell = new PdfPCell(this.SetPageTitle(name));
            pdfCell.Colspan = maxColumn;
            pdfCell.Border = 0;
            pdfTable.AddCell(pdfCell);

            pdfTable.CompleteRow();
        }


        public PdfPTable SetPageTitle(string name)
        {
            int maxColumn = 3;
            PdfPTable pdfPTable = new PdfPTable(maxColumn);
           

            fontStyle = FontFactory.GetFont("Tahoma", 18f, 1);
            pdfCell = new PdfPCell(new Phrase("SalarySlip " + name, fontStyle));
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(pdfCell);
            pdfPTable.CompleteRow();

            fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            pdfCell = new PdfPCell(new Phrase("Of Month: " + DateTime.Now.Month + "/" + DateTime.Now.Year, fontStyle));
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

            fontStyle = FontFactory.GetFont("Tahoma", 9f, 4);
            pdfCell = new PdfPCell(new Phrase("Employee Name: " + context.Employee.Where(x => x.Id == id).Select(x => x.Fname).FirstOrDefault() + " " +context.Employee.Where(x => x.Id == id).Select(x => x.Lname).FirstOrDefault() +  ".", fontStyle));
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfTable.AddCell(pdfCell);
            pdfTable.CompleteRow();
            EmptyRow(5);

            fontStyle = FontFactory.GetFont("Tahoma", 9f, 4);
            pdfCell = new PdfPCell(new Phrase("Phone Number: 0" + context.Employee.Where(x => x.Id == id).Select(x => x.PhoneNumber).FirstOrDefault() + ".", fontStyle));
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfTable.AddCell(pdfCell);
            pdfTable.CompleteRow();
            EmptyRow(5);

            fontStyle = FontFactory.GetFont("Tahoma", 7f, 4);
            pdfCell = new PdfPCell(new Phrase("The number of working hours required in this month:  " + 300 + " Hours. " , fontStyle));
            pdfCell.Colspan = maxColumn;
            
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfTable.AddCell(pdfCell);
            EmptyRow(5);

            pdfTable.CompleteRow();fontStyle.Color = BaseColor.Blue;
            fontStyle = FontFactory.GetFont("Tahoma", 7f, 4);
            pdfCell = new PdfPCell(new Phrase( "Working hours:  " + context.EmployeeAttendence.Where(x => x.Employee.Id == id && x.LoginTime.Year == DateTime.Now.Year && x.LoginTime.Month == DateTime.Now.Month).Sum(x => x.NumberOfHours) + "  hours.", fontStyle));
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfTable.AddCell(pdfCell);
            pdfTable.CompleteRow();
            EmptyRow(5);

            fontStyle = FontFactory.GetFont("Tahoma", 7f, 4);
            pdfCell = new PdfPCell(new Phrase("Hourly Salary:  " + context.Employee.Where(x=>x.Id == id).Select(x=>x.Salary).FirstOrDefault() + " $.", fontStyle));
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfTable.AddCell(pdfCell);
            pdfTable.CompleteRow();
            EmptyRow(5);

            pdfTable.CompleteRow();
            fontStyle = FontFactory.GetFont("Tahoma", 7f, 4);
            fontStyle.Color = BaseColor.Red;
            pdfCell = new PdfPCell(new Phrase("Total Salary:  " + context.EmployeeAttendence.Where(x => x.Employee.Id == id && x.LoginTime.Year == DateTime.Now.Year && x.LoginTime.Month == DateTime.Now.Month).Sum(x => x.NumberOfHours)* context.Employee.Where(x => x.Id == id).Select(x => x.Salary).FirstOrDefault() +"  hours.", fontStyle));
            pdfCell.Colspan = maxColumn;
            pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell.Border = 0;
            pdfCell.ExtraParagraphSpace = 0;
            pdfTable.AddCell(pdfCell);
            pdfTable.CompleteRow();


        }

    }
}
