using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Brotli.Benchmark.Native.Lib
{
    public class BrotliNativeDN3
    {
        public  void Compress(string inputFileName)
        {
            string outputFileName = $@"c:\File\{inputFileName}-native-compressed.txt";
            inputFileName = $@"c:\File\{inputFileName}.txt";
            using FileStream input = File.OpenRead(inputFileName);
            using FileStream output = File.Create(outputFileName);
            using BrotliStream compressor = new BrotliStream(output, CompressionMode.Compress);
            input.CopyTo(compressor);
        }

        public void Decompress(string inputFileName)
        {
            string outputFileName = $@"c:\File\{inputFileName}-native-decompressed.txt";
            inputFileName = $@"c:\File\{inputFileName}-native-compressed.txt";
            using FileStream input = File.OpenRead(inputFileName);
            using FileStream output = File.Create(outputFileName);
            using BrotliStream decompressor = new BrotliStream(input, CompressionMode.Decompress);
            decompressor.CopyTo(output);
        }

        public void DecompressFromNuget(string inputFileName, int quality)
        {
            string outputFileName = $@"c:\File\{inputFileName}-native-from-nuget-decompressed.txt";
            inputFileName = $@"c:\File\{inputFileName}-nuget-lvl{quality}-compressed.txt";
            using FileStream input = File.OpenRead(inputFileName);
            using FileStream output = File.Create(outputFileName);
            using BrotliStream decompressor = new BrotliStream(input, CompressionMode.Decompress);
            decompressor.CopyTo(output);
        }
    }
}
