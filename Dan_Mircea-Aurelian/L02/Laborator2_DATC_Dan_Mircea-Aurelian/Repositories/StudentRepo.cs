using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laborator2_DATC_Dan_Mircea_Aurelian.Models;

namespace Laborator2_DATC_Dan_Mircea_Aurelian.Repositories
{
    public class StudentRepo
    {
        public static List<Student> Studenti = new List<Student>() { 
            new Student { id = 1, nume = "Matei", facultate = "AC", an = 3 },
            new Student { id = 2, nume = "Marius", facultate = "ETC", an = 4 }
        };
    }
}
