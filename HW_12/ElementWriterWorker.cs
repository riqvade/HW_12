using HW_12;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12_WriterInCSV
{
    public class ElementWriterWorker
    {
        public List<ArchiveElement> CreateElementList(string PathToUnzippedFolder)
        {
            List<ArchiveElement> archiveElement = new List<ArchiveElement>();
            DirectoryInfo directoryInfo = new DirectoryInfo(PathToUnzippedFolder);
            var directories = directoryInfo.GetDirectories();
            foreach (var dir in directories)
            {
                archiveElement.Add(new ArchiveElement
                {
                    EntityType = TypeOfEntity.Folder,
                    Name = dir.Name,
                    DateChange = dir.LastWriteTime,
                });
            }
            var files = directoryInfo.GetFiles();
            var fileInfos = files.Select(f => new ArchiveElement
            {
                EntityType = TypeOfEntity.Folder,
                Name = f.Name,
                DateChange = f.LastWriteTime,
            });
            archiveElement.AddRange(fileInfos);

            return archiveElement;
        }
    }
}
