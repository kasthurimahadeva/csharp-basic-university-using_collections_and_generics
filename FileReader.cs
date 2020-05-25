using System;
using System.IO;
using PandaKaradyUniversity.Models;

namespace PandaKaradyUniversity
{
    class FileReader<T>
    {
        private readonly IParser<T> _parser;

        public FileReader(IParser<T> parser)
        {
            _parser = parser;
        }
        
        public void Process(string fileName)
        {
            using (var reader = File.OpenText(Path.Combine("resources", fileName)))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(_parser.Parse(line));
                    line = reader.ReadLine();
                }
            }
        }
    }
}