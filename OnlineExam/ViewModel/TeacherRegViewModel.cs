﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using OnlineExam.DbContext;

namespace OnlineExam.ViewModel
{
    public class TeacherRegViewModel
    {

        public int? Id { get; set; }

        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "WhatsApp")]
        public string WhatsApp { get; set; }
        [Required]
        [Display(Name = "PrimarySubject")]
        public int PrimarySubject { get; set; }
        [Required]
        [Display(Name = "SecondarySubject")]
        public int SecondarySubject { get; set; }
        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }
        [Required]
        [Display(Name = "Street")]
        public string Street { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "PO")]
        public string PO { get; set; }
        [Required]
        [Display(Name = "District")]
        public string District { get; set; }
        [Required]
        [Display(Name = "State")]
        public string State { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }

}