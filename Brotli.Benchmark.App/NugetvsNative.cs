using BenchmarkDotNet.Attributes;
using Brotli.Benchmark.Lib;
using Brotli.Benchmark.Native.Lib;

namespace Brotli.Benchmark.App
{
    [CoreJob]
    //[MonoJob("Mono x64", @"C:\Program Files\Mono\bin\mono.exe")]
    public class NugetvsNative
    {
        private readonly BrotliNuget brotliNuget = new BrotliNuget();
        private readonly BrotliNativeDN3 brotliNative = new BrotliNativeDN3();

        private string inputFileName;

        [Params("lorem-10b", "lorem-100b", "lorem-1kb", "lorem-10kb", "pg10")]
        public string N;

        [GlobalSetup]
        public void Setup()
        {
            inputFileName = N;
            
        }

        [Benchmark]
        public void CompressNugetLvl6() => brotliNuget.Compress(inputFileName, 6);
        [Benchmark]
        public void CompressNugetLvl9() => brotliNuget.Compress(inputFileName, 9);

        [Benchmark]
        public void CompressNativeLvlOptimal() => brotliNative.Compress(inputFileName);

        [Benchmark]
        public void DecompressNugetLvl6() => brotliNuget.Decompress(inputFileName, 6);

        [Benchmark]
        public void DecompressNugetLvl9() => brotliNuget.Decompress(inputFileName, 9);

        [Benchmark]
        public void DecompressNative() => brotliNative.Decompress(inputFileName);

        [Benchmark]
        public void DecompressNugetFromNative() => brotliNuget.DecompressFromNative(inputFileName);

        [Benchmark]
        public void DecompressNativeFromNugetLvl6() => brotliNative.DecompressFromNuget(inputFileName, 6);
       
        [Benchmark]
        public void DecompressNativeFromNugetLvl9() => brotliNative.DecompressFromNuget(inputFileName, 9);

    }
}
