using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generate Data
            //var fList = new List<double> {.5, .75,1,1.5};
            //var lList = new List<ulong> {1, 2};
            //var dGen = new DataGenerator(fList, lList);
            //dGen.Generate("J:\\Test.txt");

            var loader = new Loader();
            //loader.Load("J:\\Test.txt");
            loader.Find();
        }
    }
}
