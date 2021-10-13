using Laborator2_DATC_Dan_Mircea_Aurelian.Models;
using System.Collections.Generic;

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
