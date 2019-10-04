using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using BrotliSharpLib;

namespace Brotli.Benchmark.Lib
{
    public class BrotliNuget
    {
        public void Compress(string inputFileName, int quality)
        {
            string outputFileName = $@"c:\File\{inputFileName}-nuget-lvl{quality}-compressed.txt";
            inputFileName = $@"c:\File\{inputFileName}.txt";            
            using (FileStream input = File.OpenRead(inputFileName))
            using (FileStream output = File.Create(outputFileName))
            using (BrotliSharpLib.BrotliStream compressor = new BrotliSharpLib.BrotliStream(output, CompressionMode.Compress))
            {
                compressor.SetQuality(quality);
                input.CopyTo(compressor);
            }
        }

        public void Decompress(string inputFileName, int quality)
        {
            string outputFileName = $@"c:\File\{inputFileName}-nuget-decompressed.txt";
            inputFileName = $@"c:\File\{inputFileName}-nuget-lvl{quality}-compressed.txt";            
            using (FileStream input = File.OpenRead(inputFileName))
            using (FileStream output = File.Create(outputFileName))
            using (BrotliSharpLib.BrotliStream decompressor = new BrotliSharpLib.BrotliStream(input, CompressionMode.Decompress))
            {
                decompressor.CopyTo(output);
            }
        }

        public void DecompressFromNative(string inputFileName)
        {
            string outputFileName = $@"c:\File\{inputFileName}-nuget-from-native-decompressed.txt";
            inputFileName = $@"c:\File\{inputFileName}-native-compressed.txt";
            using (FileStream input = File.OpenRead(inputFileName))
            using (FileStream output = File.Create(outputFileName))
            using (BrotliSharpLib.BrotliStream decompressor = new BrotliSharpLib.BrotliStream(input, CompressionMode.Decompress))
            {
                decompressor.CopyTo(output);
            }
        }
    }
}
