using APBDcw4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBDcw4.Services
{
    interface IStudentsDal
    {
        //Data Acces Layer

        public IEnumerable<Student> GetStudents();
        public Enrollment GetEnrollment(string idStudenta);
    }
}
