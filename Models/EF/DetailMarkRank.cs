using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EF
{
    public class DetailMarkRank
    {
        string culName, culChineseName, images;
        double agvMark;

        public string CulName { get => culName; set => culName = value; }
        public string CulChineseName { get => culChineseName; set => culChineseName = value; }
        public string Images { get => images; set => images = value; }
        public double AgvMark { get => agvMark; set => agvMark = value; }
    }
}
