using System;
using System.Collections.Generic;
using System.IO;

namespace MongoTest
{
    class DataGenerator
    {
        private readonly List<double> _frequencyList;
        private readonly List<ulong> _lineIds;
        private readonly Random _rnd;

        public DataGenerator(List<double> freqList, List<ulong> lineIds)
        {
            _frequencyList = freqList;
            _lineIds = lineIds;
            _rnd = new Random();
        }

        public void Generate(string fileName)
        {
            using (var writer = new StreamWriter(fileName))
                foreach (var line in _lineIds)
                    foreach (var f in _frequencyList)
                    {
                        for (var i = 0; i < 100; ++i)
                        {
                            var amp = _rnd.Next(1, 10)/1e15;
                            var phase = _rnd.Next(1, 10)/100.0;
                            writer.WriteLine(f + " " + amp + " " + phase + " " + line);
                        }
                    }
        }
    }
}
