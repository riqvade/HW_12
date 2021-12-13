using HW_12;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12_WriterInCSV
{
    class CSVWorker
    {
        public bool CreateCSVFile(List<ArchiveElement> archiveElements, string PathToCSVFile)
        {
            try
            {
                string csvText = string.Join('\n', archiveElements);

                using StreamWriter streamWriter = new StreamWriter(PathToCSVFile);

                streamWriter.Write(csvText);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }
    }
}
