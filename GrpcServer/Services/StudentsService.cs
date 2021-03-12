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

        public override async Task GetAllStudents(ListStudents request, IServerStreamWriter<StudentModel> responseStream, ServerCallContext context)
        {
            foreach (var student in _students)
            {
                await responseStream.WriteAsync(student);
            }
        }

        private static List<StudentModel> InitializeList()
        {
            var students = new List<StudentModel>
            {
                new StudentModel
                {
                    FirstName = "Jxxxxx",
                    LastName = "Axxxxxxx",
                    EmailAddress = "jxxxxxxx@stud.kea.dk",
                    IsActive = true,
                    StudentIdNumber = 123456
                },
                new StudentModel
                {
                    FirstName = "Axxxxxx",
                    LastName = "Vxxxxxxx",
                    EmailAddress = "axxxxxxx@stud.kea.dk",
                    IsActive = true,
                    StudentIdNumber = 123457
                },
                new StudentModel
                {
                    FirstName = "Ixxxxxxx",
                    LastName = "Lxxxxxxxx",
                    EmailAddress = "ixxxxxxx@stud.kea.dk",
                    IsActive = true,
                    StudentIdNumber = 123458
                },
                new StudentModel
                {
                    FirstName = "Jxxxxx",
                    LastName = "Dxxxxxxx",
                    EmailAddress = "jxxxxxxx@stud.kea.dk",
                    IsActive = true,
                    StudentIdNumber = 123459
                },
                new StudentModel
                {
                    FirstName = "Oxxxxx",
                    LastName = "Mxxxxxx",
                    EmailAddress = "oxxxxxxx@stud.kea.dk",
                    IsActive = true,
                    StudentIdNumber = 123460
                }
            };
            return students;
        }

    }
}
