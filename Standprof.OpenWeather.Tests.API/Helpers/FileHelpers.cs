using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace QA.MyProduct.Tests.API.Helpers
{
    class FileHelpers
    {
        public static IEnumerable<string[]> ReadFromCsv(string filename, bool hasHeader = true)
        {
            var contents = File.ReadAllText(filename).Split('\n');
            var csv = from line in contents
                select line.Split(',').ToArray();

            if (hasHeader)
                return csv.Skip(1);
            else 
                return csv;
        }
    }
}
