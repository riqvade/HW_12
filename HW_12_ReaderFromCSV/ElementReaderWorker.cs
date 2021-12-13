using HW_12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12_ReaderFromCSV
{
    public class ElementReaderWorker
    {
        public List<ArchiveElement> GetElementList(string csvFilePath)
        {
            List<ArchiveElement> archiveElements = new List<ArchiveElement>();
            string[] csvStrings = File.ReadAllLines(csvFilePath);
            foreach (string csvString in csvStrings)
            {
                string[] strings = csvString.Split('\t');
                if (strings.Length != 3)
                {
                    continue;
                }

                if (!Enum.TryParse(strings[0], out TypeOfEntity entityType))
                {
                    continue;
                }

                string name = strings[1];
                if (string.IsNullOrEmpty(name))
                {
                    continue;
                }

                if (!DateTime.TryParse(strings[2], out DateTime creationDate))
                {
                    continue;
                }

                archiveElements.Add(new ArchiveElement
                {
                    EntityType = entityType,
                    Name = name,
                    DateChange = creationDate,
                });
            }

            return archiveElements;
        }
    }
}
