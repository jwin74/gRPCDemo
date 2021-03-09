using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
// ReSharper disable UnusedParameter.Local

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var studentClient = new Student.StudentClient(channel);

            // Single Student
            Console.WriteLine("Single Record Demo");
            var input = new StudentModelLookup {StudentId = 123456};
            var student = await studentClient.GetStudentInfoAsync(input);

            Console.WriteLine($"Student Name: {student.FirstName} {student.LastName}, Student ID Number: {student.StudentIdNumber}");

            Console.ReadKey();
        }
    }
}
