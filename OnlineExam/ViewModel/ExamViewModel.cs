using OnlineExam.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExam.ViewModel
{
    public class ExamViewModel
    {

        public GetAllExamById_Result GetAllExam { get; set; }

        public List<GetAllQusByExamId_Result> getAllQus { get; set; }
    }
}