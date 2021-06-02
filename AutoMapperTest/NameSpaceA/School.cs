using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperTest.NameSpaceA
{
    public class SchoolA
    {
        public string Name { get; set; }
        public int PersionCount { get; set; }

        public StudentA SingleStudent { get; set; }
        public List<StudentA> studentList { get; set; }
        public Dictionary<string, StudentA> studentDic { get; set; }
    }
    public class StudentA
    {
        public string Name { get; set; }
        public int Aget { get; set; }
    }
}
