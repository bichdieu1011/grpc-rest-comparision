using DataModel;
using Grpc.Core;
using Service.gRPC;
using System;

namespace Service.gRPC.Services
{
    public class GreeterService : Testing.TestingBase
    {
        //private readonly ILogger<GreeterService> _logger;
        public GreeterService()
        {
            //_logger = logger;
        }

        public override async Task<GetIdReply> GetId(GetIdRequest request, ServerCallContext context)
        {
            return await Task.FromResult(new GetIdReply { Id = "This is service 2" });
        }

        public override async Task GetStudentsInfor(EmptyRequest request, IServerStreamWriter<ListStudents> responseStream, ServerCallContext context)
        {
            ListStudents responseData = new ListStudents();
            foreach (var data in StudentData.ListStudents.Students)
            {
                responseData.Students.Add(data);
                if (responseData.Students.Count == 100)
                {

                    await responseStream.WriteAsync(responseData);
                    responseData.Students.Clear();
                }
            }
            await responseStream.WriteAsync(responseData);
        }

        public override Task<ListStudents> GetStudentsInforAsList(EmptyRequest request, ServerCallContext context)
        {
            return Task.FromResult(StudentData.ListStudents);
        }

        public override Task<StatusResponse> PostStudentsInfor(ListStudents request, ServerCallContext context)
        {
            return Task.FromResult(new StatusResponse { Status = "Success" });
        }
    }
}