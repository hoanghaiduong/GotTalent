using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EF
{
    public class MarkByCul
    {
        int jubgeID, culId;
        string jubgeName, imagesJub, culName, culChineseName, imagescul, subName, subChineseName;
        double total;

        public int JubgeID { get => jubgeID; set => jubgeID = value; }
        public int CulId { get => culId; set => culId = value; }
        public string JubgeName { get => jubgeName; set => jubgeName = value; }
        public string ImagesJub { get => imagesJub; set => imagesJub = value; }
        public string CulName { get => culName; set => culName = value; }
        public string CulChineseName { get => culChineseName; set => culChineseName = value; }
        public string Imagescul { get => imagescul; set => imagescul = value; }
        public string SubName { get => subName; set => subName = value; }
        public string SubChineseName { get => subChineseName; set => subChineseName = value; }
        public double Total { get => total; set => total = value; }
    }
}
