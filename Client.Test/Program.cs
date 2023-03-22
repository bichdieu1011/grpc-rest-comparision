// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;
using Client.Test;

Console.WriteLine("Hello, World!");


//var resultRest = await new ClientTest().GetNewGuid_REST();
//Console.WriteLine(resultRest.ToString());

await new ClientTest().gRPC_GetListStudentAsList();


//var config = DefaultConfig.Instance
//    .AddJob(Job
//         .MediumRun
//         .WithLaunchCount(1)
//         .WithToolchain(InProcessNoEmitToolchain.Instance));
//var summary = BenchmarkRunner.Run(typeof(ClientTest), config);