using BenchmarkDotNet.Running;
using System;

namespace Brotli.Benchmark.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<NugetvsNative>();
        }
    }
}
