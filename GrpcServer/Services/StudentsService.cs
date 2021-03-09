using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    public class StudentsService : Student.StudentBase
    {
        private readonly ILogger<StudentsService> _logger;
        private readonly List<StudentModel> _students;

        public StudentsService(ILogger<StudentsService> logger)
        {
            _logger = logger;
            _students = InitializeList();
        }

        public override Task<StudentModel> GetStudentInfo(StudentModelLookup request, ServerCallContext context)
        {
            foreach (var student in _students)
            {
                if (student.StudentIdNumber == request.StudentId)
                {
                    return Task.FromResult(student);
                }
            }
            return Task.FromResult(new StudentModel());
        }

        private static List<StudentModel> InitializeList()
        {
            var students = new List<StudentModel>
            {
                new StudentModel
                {
                    FirstName = "Jasper",
                    LastName = "Andersen",
                    EmailAddress = "jasp0359@stud.kea.dk",
                    IsActive = true,
                    StudentIdNumber = 123456
                },
                new StudentModel
                {
                    FirstName = "Andrian",
                    LastName = "Vangelov",
                    EmailAddress = "andr28f2@stud.kea.dk",
                    IsActive = true,
                    StudentIdNumber = 123457
                },
                new StudentModel
                {
                    FirstName = "Immanuel",
                    LastName = "Lokzinsky",
                    EmailAddress = "imma0013@stud.kea.dk",
                    IsActive = true,
                    StudentIdNumber = 123458
                },
                new StudentModel
                {
                    FirstName = "Jeppe",
                    LastName = "Dyekjær",
                    EmailAddress = "jepp564d@stud.kea.dk",
                    IsActive = true,
                    StudentIdNumber = 123459
                },
                new StudentModel
                {
                    FirstName = "Osvald",
                    LastName = "Minddal",
                    EmailAddress = "osva0015@stud.kea.dk",
                    IsActive = true,
                    StudentIdNumber = 123460
                }
            };
            return students;
        }

    }
}
