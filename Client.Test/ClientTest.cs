using BenchmarkDotNet.Attributes;
using Client.Test.Client;
using DataModel;
using Service.gRPC;

namespace Client.Test
{
    public class ClientTest
    {
        public int IdVersion { get; set; } = 1;

        [Params(100, 200)]
        public int Iteration { get; set; } = 100;
        public GRPCClient gPRClient = new GRPCClient();
        public RESTClient RESTClient = new RESTClient();

        
        [Benchmark]
        public async Task REST_GetListStudentAsList()
        {
            for (var i = 0; i < Iteration; i++)
            {
                await RESTClient.GetStudents();
            }
        }

        [Benchmark]
        public async Task gRPC_GetListStudentAsList()
        {
            for (var i = 0; i < Iteration; i++)
                await gPRClient.GetStudentAsList();
        }

        [Benchmark]
        public async Task REST_PostListStudent()
        {
            for (var i = 0; i < Iteration; i++)
                await RESTClient.PostStudents(StudentData.ListStudentForRest);
        }

        public async Task gRPC_GetListStudentAsStream()
        {
            for (var i = 0; i < Iteration; i++)
                await gPRClient.GetStudentAsStream();
        }

        [Benchmark]
        public async Task gRPC_PostListStudent()
        {
            for (var i = 0; i < Iteration; i++)
                await gPRClient.PostListStudent(StudentData.ListStudents);
        }
    }
}