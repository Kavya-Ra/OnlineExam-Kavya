//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineExam.DbContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Group_Teacher = new HashSet<Group_Teacher>();
            this.Student_AcademicPerformance = new HashSet<Student_AcademicPerformance>();
            this.Student_HomeCountryDetails = new HashSet<Student_HomeCountryDetails>();
            this.Student_Parent = new HashSet<Student_Parent>();
            this.Student_PreviousEntrance = new HashSet<Student_PreviousEntrance>();
            this.Student_Registration = new HashSet<Student_Registration>();
            this.Teachers_QuestionBank = new HashSet<Teachers_QuestionBank>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int RoleId { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public int DeletedBy { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime DeletedDate { get; set; }
        public string UniqueID { get; set; }
        public string MobileNo { get; set; }
        public string ActivationCode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Group_Teacher> Group_Teacher { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student_AcademicPerformance> Student_AcademicPerformance { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student_HomeCountryDetails> Student_HomeCountryDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student_Parent> Student_Parent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student_PreviousEntrance> Student_PreviousEntrance { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student_Registration> Student_Registration { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teachers_QuestionBank> Teachers_QuestionBank { get; set; }
        public virtual UserRole UserRole { get; set; }
    }
}
