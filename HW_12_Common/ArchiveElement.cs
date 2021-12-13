using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12
{
    public class ArchiveElement
    {
        public TypeOfEntity EntityType { get; set; }
        public string Name { get; set; }
        public DateTime DateChange { get; set; }

        public override string ToString()
        {
            return $"{EntityType}\t{Name}\t{DateChange}";
        }
    }
}
