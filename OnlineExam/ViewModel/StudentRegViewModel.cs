﻿using OnlineExam.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExam.ViewModel
{
    public class StudentRegViewModel
    {
        public int Id { get; set; }
        public string RegId { get; set; }
        public string ExamAttendingYear { get; set; }
        public string PreferredDay { get; set; }
        public string ApplnDate { get; set; }
        public string AcademicYear { get; set; }
        public string AdmissionTestDate { get; set; }
        public string StudentName { get; set; }
        public string PreferredTime { get; set; }
        public string WhatsappNo { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string Caste { get; set; }
        public string Community { get; set; }
        public string BloodGroup { get; set; }
        public string Nationalty { get; set; }
        public string PresentAddress { get; set; }
        public string Area { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Pincode { get; set; }
        public string QuickContNo { get; set; }
        public string Photo { get; set; }
        public string QuickWhatsApp { get; set; }
        public int PgmId { get; set; }
        public int ClassId { get; set; }
        public int CourseId { get; set; }
        public int SubPgmId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int IsDeleted { get; set; }
        public int Pid { get; set; }
        public string PRegId { get; set; }
        public System.DateTime PCreatedDate { get; set; }
        public int PIsDeleted { get; set; }
        public string FrName { get; set; }
        public string FrOcc { get; set; }
        public string FrMobNo { get; set; }
        public string FrMailid { get; set; }
        public string FrDistrict { get; set; }
        public string FrSign { get; set; }
        public string FrState { get; set; }
        public string FrWhatsapp { get; set; }
        public string MrName { get; set; }
        public string MrOcc { get; set; }
        public string MrMobNo { get; set; }
        public string MrMailid { get; set; }
        public string MrDistrict { get; set; }
        public string MrSign { get; set; }
        public string MrState { get; set; }
        public string MrWhatsapp { get; set; }
        public string AddressHome1 { get; set; }
        public string AddressHome2 { get; set; }
        public string AreaHome { get; set; }
        public string EmaiIdHome { get; set; }
        public System.DateTime HCreatedDate { get; set; }
        public int Hid { get; set; }
        public int HIsDeleted { get; set; }
        public string DistrictHome { get; set; }
        public string LocationHome { get; set; }
        public string PincodeHome { get; set; }
        public string QuickHomeContact { get; set; }
        public string QuickHomeWhatsapp { get; set; }
        public string StateHome { get; set; }
        public string HregId { get; set; }
        public string SpName { get; set; }
        public string SubpName { get; set; }
        public string ClassName { get; set; }
        public string CorseName { get; set; }
        //public List<Student_AcademicPerformance> student_Academics { get; set; }
        //public List<Student_PreviousEntrance> student_Previous { get; set; }
    }
}