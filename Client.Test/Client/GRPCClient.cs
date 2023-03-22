using Grpc.Net.Client;
using Service.gRPC;
using static Service.gRPC.Testing;

namespace Client.Test.Client
{
    public class GRPCClient
    {
        private readonly TestingClient client;

        public GRPCClient()
        {
            var channel = GrpcChannel.ForAddress("http://localhost:5001", new GrpcChannelOptions { UnsafeUseInsecureChannelCallCredentials = true });
            client = new TestingClient(channel);
        }

        public async Task<string> GetNewId(int version)
        {
            return (await client.GetIdAsync(new GetIdRequest { Version = version })).Id;
        }

        public async Task<string> PostListStudent(ListStudents listStudent)
        {
            return (await client.PostStudentsInforAsync(listStudent)).Status;
        }

        public async Task<ListStudents> GetStudentAsList()
        {
            return (await client.GetStudentsInforAsListAsync(new EmptyRequest()));
        }

        public async Task<List<Student>> GetStudentAsStream()
        {
            List<Student> students = new List<Student>();
            using var response = client.GetStudentsInfor(new EmptyRequest());

            while (await response.ResponseStream.MoveNext(default))
            {
                students.AddRange(response.ResponseStream.Current.Students);
            }

            return students;
        }
    }
}