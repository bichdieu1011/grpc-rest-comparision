using Newtonsoft.Json;
using Service.gRPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public static class StudentData
    {
        static string studentJson;
        public static string StudentsJson
        {
            get
            {
                if (string.IsNullOrEmpty(studentJson))
                {
                    var filePath =Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "StudentData.json");
                    studentJson = File.ReadAllText(filePath);
                }
                return studentJson;
            }
        }

        static ListStudents listStudents;
        public static ListStudents ListStudents
        {
            get
            {
                if (listStudents is null)
                {
                    listStudents = new ListStudents();
                    listStudents.Students.AddRange(JsonConvert.DeserializeObject<Google.Protobuf.Collections.RepeatedField<Student>>(StudentsJson));
                }
                return listStudents;
            }
        }

        static List<TestingData> _listStudents;
        public static List<TestingData> ListStudentForRest
        {
            get
            {
                if (_listStudents is null)
                {
                    _listStudents = JsonConvert.DeserializeObject<List<TestingData>>(StudentsJson);
                }
                return _listStudents;
            }
        }
    }
}
