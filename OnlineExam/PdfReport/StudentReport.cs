 using iTextSharp.text;
using iTextSharp.text.pdf;
using OnlineExam.DbContext;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Web;

namespace OnlineExam.PdfReport
{
    public class StudentReport
    {
        #region Declaration
        int totalcolumn = 2;
        int totalcolumn1 = 10;
        Document document;
        Font font;
        PdfPTable pdfPTable = new PdfPTable(2);
        PdfPTable pdfheader = new PdfPTable(2);
        PdfPTable table = new PdfPTable(10);
        PdfPTable table1 = new PdfPTable(6);
        PdfPTable table2 = new PdfPTable(2);
        PdfPCell pdfPCell;
        MemoryStream memoryStream = new MemoryStream();
        string regid;
        private Exam_DBEntities db = new Exam_DBEntities();

        #endregion


        public byte[] PrepareReport(string regid)
        {
            var data = db.GetAllStudentRegistrationByRegId(regid).FirstOrDefault();
            var studacademic = db.Student_AcademicPerformancebyRegid(regid).ToList();
            var previousentrance = db.Student_PreviousEntrancebyRegid(regid).ToList();

            document = new Document(PageSize.A4, 0f, 0f,0f,0f);
            document.SetPageSize(PageSize.A4);
            document.SetMargins(20f, 20f, 20f, 20f);

            pdfheader.WidthPercentage = 100;
            pdfheader.HorizontalAlignment = Element.ALIGN_LEFT;

            table.WidthPercentage = 100;
            table.HorizontalAlignment = Element.ALIGN_LEFT;

            pdfPTable.WidthPercentage = 100;
            pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;

            font = FontFactory.GetFont("Tahoma",8f,1);
            PdfWriter pdfWriter = PdfWriter.GetInstance(document , memoryStream);
        
            document.Open();

            pdfheader.SetWidths(new float[] { 20f, 20f});

            pdfheader.HeaderRows = 2;

            PdfPTable pdfP = new PdfPTable(2);

            pdfP.HorizontalAlignment = 0;
            pdfP.TotalWidth = 350f;
            pdfP.LockedWidth = true;

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("ENTRANCE COACH.COM", font));
            pdfPCell.Colspan = totalcolumn;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.Border = 0;
            pdfPCell.BackgroundColor = BaseColor.WHITE;
            pdfPCell.ExtraParagraphSpace = 0;
            pdfP.AddCell(pdfPCell);
            pdfP.CompleteRow();

           
            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Student Registration", font));
            pdfPCell.Colspan = totalcolumn;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.Border = 0;
            pdfPCell.BackgroundColor = BaseColor.WHITE;
            pdfPCell.ExtraParagraphSpace = 30;
            pdfP.AddCell(pdfPCell);
            pdfP.CompleteRow();

            #region Table header
           

            PdfPCell cell = new PdfPCell(new Phrase("Full Name", font));
            pdfP.AddCell(cell);
            Chunk c = new Chunk(data.StudentName, font);
            Paragraph para1 = new Paragraph(c);
            cell = new PdfPCell(para1);
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfP.AddCell(cell);
          
            cell = new PdfPCell(new Phrase("Registration No", font));
            pdfP.AddCell(cell);
            Chunk c1 = new Chunk(data.RegId, font);
            Paragraph para2 = new Paragraph(c1);
            cell = new PdfPCell(para2);
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfP.AddCell(cell);

            cell = new PdfPCell(new Phrase("Application Date", font));
            pdfP.AddCell(cell);
            Chunk cd = new Chunk(data.ApplnDate, font);
            Paragraph parad = new Paragraph(cd);
            cell = new PdfPCell(para2);
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfP.AddCell(cell);

            cell = new PdfPCell(new Phrase("Selected Class", font));
            pdfP.AddCell(cell);
            Chunk c3 = new Chunk(data.ClassName, font);
            Paragraph para3 = new Paragraph(c3);
            cell = new PdfPCell(para3);
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfP.AddCell(cell);

            cell = new PdfPCell(new Phrase("Selected Programme", font));
            pdfP.AddCell(cell);
            Chunk c4 = new Chunk(data.SpName, font);
            Paragraph para4 = new Paragraph(c4);
            cell = new PdfPCell(para4);
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfP.AddCell(cell);

            cell = new PdfPCell(new Phrase("Selected SubProgram", font));
            pdfP.AddCell(cell);
            Chunk c5 = new Chunk(data.SubpName, font);
            Paragraph para5 = new Paragraph(c5);
            cell = new PdfPCell(para5);
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfP.AddCell(cell);

            cell = new PdfPCell(new Phrase("Selected Course", font));
            pdfP.AddCell(cell);
            Chunk c6 = new Chunk(data.CorseName, font);
            Paragraph para6 = new Paragraph(c6);
            cell = new PdfPCell(para6);
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfP.AddCell(cell);

            cell = new PdfPCell(new Phrase("Academic Year", font));
            pdfP.AddCell(cell);
            Chunk c7 = new Chunk(data.AcademicYear, font);
            Paragraph para7 = new Paragraph(c7);
            cell = new PdfPCell(para7);
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_LEFT;
            cell.FixedHeight = 0;
            pdfP.AddCell(cell);

            pdfP.WriteSelectedRows(0, -1, document.Left, document.Top, pdfWriter.DirectContent);


            pdfP = new PdfPTable(1);
            pdfP.HorizontalAlignment = 2;
            pdfP.TotalWidth = 175f;
            pdfP.LockedWidth = true;

            string imagePaths = "http://entrancecoachexam.azurewebsites.net/" + data.Photo;
            Image imges = Image.GetInstance(imagePaths);
            imges.ScaleAbsolute(129f, 119f);
            PdfPCell cell1 = new PdfPCell(imges);
            cell1.PaddingTop = 60f;
            cell1.PaddingRight = 10f;
            cell1.PaddingLeft = 10f;
            cell1.PaddingBottom = 10f;
            
            cell1.Border = 0;

            pdfP.AddCell(cell1);
          
            pdfP.WriteSelectedRows(10, -1, document.Left + 350, document.Top, pdfWriter.DirectContent);
          
            #endregion

            #region About Student

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("About the Student", font));
            pdfPCell.Colspan = totalcolumn;
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.Border = 0;
            pdfPCell.BackgroundColor = BaseColor.WHITE;
            pdfPCell.ExtraParagraphSpace = 30;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();


            //pdfPTable = new PdfPTable(2);
            //pdfPTable.TotalWidth = 144f;
            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("WhatsApp No ", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0f;
            pdfPTable.AddCell(pdfPCell);

            Chunk wtp = new Chunk(data.WhatsappNo, font);
            Paragraph pwtp = new Paragraph(wtp);
            pdfPCell = new PdfPCell(pwtp);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0f;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Date of Birth ", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk dob = new Chunk(data.DOB, font);
            Paragraph pdob = new Paragraph(dob);
            pdfPCell = new PdfPCell(pdob);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Gender ", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk gen = new Chunk(data.Gender, font);
            Paragraph pgen = new Paragraph(gen);
            pdfPCell = new PdfPCell(pgen);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Caste ", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk caste = new Chunk(data.Caste, font);
            Paragraph pcaste = new Paragraph(caste);
            pdfPCell = new PdfPCell(pcaste);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Community", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk com = new Chunk(data.Community, font);
            Paragraph pcom = new Paragraph(com);
            pdfPCell = new PdfPCell(pcom);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();


            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Nationality ", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk nat = new Chunk(data.Nationalty, font);
            Paragraph pnat = new Paragraph(nat);
            pdfPCell = new PdfPCell(pnat);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Blood Group ", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk bld = new Chunk(data.BloodGroup, font);
            Paragraph pbld = new Paragraph(bld);
            pdfPCell = new PdfPCell(pbld);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();


            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Present Address ", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk addre = new Chunk(data.PresentAddress, font);
            Paragraph paddre = new Paragraph(addre);
            pdfPCell = new PdfPCell(paddre);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Area ", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk area = new Chunk(data.Area, font);
            Paragraph parea = new Paragraph(area);
            pdfPCell = new PdfPCell(parea);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Location/PostOffice ", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk loc = new Chunk(data.Location, font);
            Paragraph ploc = new Paragraph(loc);
            pdfPCell = new PdfPCell(ploc);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("District ", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk dis = new Chunk(data.District, font);
            Paragraph pdis = new Paragraph(dis);
            pdfPCell = new PdfPCell(pnat);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            
            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("State ", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk state = new Chunk(data.State, font);
            Paragraph pstate = new Paragraph(state);
            pdfPCell = new PdfPCell(pstate);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();


            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Pincode ", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk pin = new Chunk(data.Pincode, font);
            Paragraph ppin = new Paragraph(pin);
            pdfPCell = new PdfPCell(ppin);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Quick Contact No ", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk qcont = new Chunk(data.QuickContNo, font);
            Paragraph pqcont = new Paragraph(qcont);
            pdfPCell = new PdfPCell(pqcont);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Quick Whatsapp No ", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk qwat = new Chunk(data.QuickWhatsApp, font);
            Paragraph pqwat = new Paragraph(qwat);
            pdfPCell = new PdfPCell(pqwat);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();
            #endregion

            #region About the Parents

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("About the Parents", font));
            pdfPCell.Colspan = totalcolumn;
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.Border = 0;
            pdfPCell.BackgroundColor = BaseColor.WHITE;
            pdfPCell.PaddingTop = 30;
            pdfPCell.ExtraParagraphSpace = 30;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();


            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Father Name ", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0f;
            pdfPTable.AddCell(pdfPCell);

            Chunk fname = new Chunk(data.FrName, font);
            Paragraph pfname = new Paragraph(fname);
            pdfPCell = new PdfPCell(pfname);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0f;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Father Occupation ", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk foccup = new Chunk(data.FrOcc, font);
            Paragraph pfoccup = new Paragraph(foccup);
            pdfPCell = new PdfPCell(pfoccup);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Mobile No ", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk fmob = new Chunk(data.FrMobNo, font);
            Paragraph pfmob = new Paragraph(fmob);
            pdfPCell = new PdfPCell(pfmob);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("WhatsApp No ", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk fwat = new Chunk(data.FrWhatsapp, font);
            Paragraph pfwat = new Paragraph(fwat);
            pdfPCell = new PdfPCell(pfwat);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Email ", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk femail = new Chunk(data.FrMailid, font);
            Paragraph pfemail = new Paragraph(femail);
            pdfPCell = new PdfPCell(pfemail);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("District", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk fdis = new Chunk(data.District, font);
            Paragraph pfdis = new Paragraph(fdis);
            pdfPCell = new PdfPCell(pfdis);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();


            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("State ", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk fsat = new Chunk(data.State, font);
            Paragraph pfsat = new Paragraph(fsat);
            pdfPCell = new PdfPCell(pfsat);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Mother Name", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk fmoth = new Chunk(data.MrName, font);
            Paragraph pfmoth = new Paragraph(fmoth);
            pdfPCell = new PdfPCell(pfmoth);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();


            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Mother Occupation", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk moccup = new Chunk(data.MrOcc, font);
            Paragraph pmoccu = new Paragraph(moccup);
            pdfPCell = new PdfPCell(pmoccu);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Mobile No ", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk mmob = new Chunk(data.MrMobNo, font);
            Paragraph pmmob = new Paragraph(mmob);
            pdfPCell = new PdfPCell(pmmob);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("WhatsApp No ", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk mwat = new Chunk(data.MrWhatsapp, font);
            Paragraph pmwat  = new Paragraph(mwat);
            pdfPCell = new PdfPCell(pmwat);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();


            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Email ", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk memail = new Chunk(data.MrMailid, font);
            Paragraph pmemail = new Paragraph(memail);
            pdfPCell = new PdfPCell(pmemail);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();


            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("District", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk mdis = new Chunk(data.MrDistrict, font);
            Paragraph pmdis = new Paragraph(mdis);
            pdfPCell = new PdfPCell(pmdis);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();



            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("State", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk mstate = new Chunk(data.MrState, font);
            Paragraph pmstate = new Paragraph(mstate);
            pdfPCell = new PdfPCell(pmstate);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();


            #endregion

            #region Home Country Details


            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Home Country Details", font));
            pdfPCell.Colspan = totalcolumn;
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.Border = 0;
            pdfPCell.BackgroundColor = BaseColor.WHITE;
            pdfPCell.PaddingTop = 30;
            pdfPCell.ExtraParagraphSpace = 20;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Address 1 ", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0f;
            pdfPTable.AddCell(pdfPCell);

            Chunk hadd = new Chunk(data.AddressHome1, font);
            Paragraph phadd = new Paragraph(hadd);
            pdfPCell = new PdfPCell(phadd);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0f;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Address 2", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk hadd2 = new Chunk(data.AddressHome2, font);
            Paragraph phadd2 = new Paragraph(hadd2);
            pdfPCell = new PdfPCell(phadd2);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Area", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk harea = new Chunk(data.Area, font);
            Paragraph pharea = new Paragraph(harea);
            pdfPCell = new PdfPCell(pharea);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Location/Post Office", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk hloc = new Chunk(data.LocationHome, font);
            Paragraph phloc = new Paragraph(hloc);
            pdfPCell = new PdfPCell(phloc);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("District", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk hdis = new Chunk(data.DistrictHome, font);
            Paragraph phdis = new Paragraph(hdis);
            pdfPCell = new PdfPCell(phdis);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();


            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("State", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk hstate = new Chunk(data.StateHome, font);
            Paragraph phstate = new Paragraph(hstate);
            pdfPCell = new PdfPCell(phstate);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Pincode", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk hpin = new Chunk(data.PincodeHome, font);
            Paragraph phpin = new Paragraph(hpin);
            pdfPCell = new PdfPCell(phpin);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();


            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Email", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk hemail = new Chunk(data.EmaiIdHome, font);
            Paragraph phemail = new Paragraph(hemail);
            pdfPCell = new PdfPCell(phemail);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Quick Contact No", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk hqno = new Chunk(data.QuickHomeContact, font);
            Paragraph phqno = new Paragraph(hqno);
            pdfPCell = new PdfPCell(phqno);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Quick Whatspp No", font));
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPCell.FixedHeight = 0;
            pdfPTable.AddCell(pdfPCell);

            Chunk hqwat = new Chunk(data.QuickHomeWhatsapp, font);
            Paragraph phqwat = new Paragraph(hqwat);
            pdfPCell = new PdfPCell(phqwat);
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_LEFT;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();
            #endregion

            #region StudentAcademic

            table = new PdfPTable(10);
            table.WidthPercentage = 100;
            table.HorizontalAlignment = 0;
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Academic Details", font));
            pdfPCell.Colspan = 10;
            pdfPCell.Border = 0;
            pdfPCell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(pdfPCell);

          
            font = FontFactory.GetFont("Tahoma", 8f, 1);
            pdfPCell = new PdfPCell(new Phrase("Class", font));
            pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("Pass Year", font));
            pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("School Address", font));
            pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("Register No", font));
            pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("Board", font));
            pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("Physics Mark", font));
            pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("Chemistry Mark", font));
            pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("Biology Mark", font));
            pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("Mathematics Mark", font));
            pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("Percentage of Mark", font));
            pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(pdfPCell);


            foreach (var item in studacademic)
            {
                table.AddCell(item.Class);
                table.AddCell(item.PassYear);
                table.AddCell(item.SchoolAddress);
                table.AddCell(item.RegNo);
                table.AddCell(item.Board);
                table.AddCell(item.PhyMark);
                table.AddCell(item.ChemMark);
                table.AddCell(item.BiologyMark);
                table.AddCell(item.MathsMark);
                table.AddCell(item.PercOfMark);
            }


            #endregion

            #region Previous Entrance
            table1 = new PdfPTable(6);
            table1.WidthPercentage = 100;
            table1.HorizontalAlignment = 0;
            table1.SpacingBefore = 20f;
            table1.SpacingAfter = 30f;

            font = FontFactory.GetFont("Tahoma", 11f, 1);
            pdfPCell = new PdfPCell(new Phrase("Previous Entrance Details", font));
            pdfPCell.Colspan = 6;
            pdfPCell.Border = 0;
            pdfPCell.BackgroundColor = BaseColor.WHITE;
            table1.AddCell(pdfPCell);
           

          

            font = FontFactory.GetFont("Tahoma", 8f, 1);
            pdfPCell = new PdfPCell(new Phrase("Previous Entrance Exam", font));
            pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table1.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("Roll No", font));
            pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table1.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("Attempted Year", font));
            pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table1.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("Mark", font));
            pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table1.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("Rank", font));
            pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table1.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("No of Attempts", font));
            pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table1.AddCell(pdfPCell);


            foreach (var item in previousentrance)
            {
                table1.AddCell(item.PrevEntranceExamName);
                table1.AddCell(item.RollNo);
                table1.AddCell(item.AttemptedYear);
                table1.AddCell(item.Mark);
                table1.AddCell(item.Rank);
                table1.AddCell(item.NoOfAttempts);
            }
            #endregion

            #region Parents Signature

            table2 = new PdfPTable(2);
            table2.WidthPercentage = 50;
            table2.HorizontalAlignment = Element.ALIGN_RIGHT;


            font = FontFactory.GetFont("Tahoma", 8f, 1);
            pdfPCell = new PdfPCell(new Phrase("Father Signature", font));
            pdfPCell.Border = 0;
            table2.AddCell(pdfPCell);

            font = FontFactory.GetFont("Tahoma", 8f, 1);
            pdfPCell = new PdfPCell(new Phrase("Mother Signature", font));
            pdfPCell.Border = 0;
            table2.AddCell(pdfPCell);

            string imagePath = "http://entrancecoachexam.azurewebsites.net/" + data.FrSign;
            Image img = Image.GetInstance(imagePath);
           
            pdfPCell = new PdfPCell(img);
            pdfPCell.Border = 0;
            pdfPCell.FixedHeight = 50;
            table2.AddCell(pdfPCell);

           
            string imagePath2 = "http://entrancecoachexam.azurewebsites.net/" + data.MrSign;
            Image imga = Image.GetInstance(imagePath2);
           
            pdfPCell = new PdfPCell(imga);
            pdfPCell.Border = 0;
            pdfPCell.FixedHeight = 50;
            table2.AddCell(pdfPCell);
            #endregion

            document.Add(pdfheader);
            document.Add(pdfP);
            document.Add(pdfPTable);
            document.Add(table);
            document.Add(table1);
            document.Add(table2);
    
            document.Close();

            return memoryStream.ToArray();
        }

  

    }
}