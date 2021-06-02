using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperTest.NameSpaceB
{
    public class SchoolB
    {
        public string Name { get; set; }
        public int PersionCount { get; set; }
        public StudentB SingleStudent { get; set; }
        public List<StudentB> studentList { get; set; }
        public Dictionary<string, StudentB> studentDic { get; set; }
    }
    public class StudentB
    {
        public string Name { get; set; }
        public int Aget { get; set; }
    }
}
