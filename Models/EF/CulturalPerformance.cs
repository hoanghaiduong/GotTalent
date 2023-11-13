using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EF
{
    public class CulturalPerformance
    {
        int culID, schoolID, subID;
        string culName, schoolName, culChineseName, description, images; bool isDelete;

        public int CulID { get => culID; set => culID = value; }
        public int SchoolID { get => schoolID; set => schoolID = value; }
        public int SubID { get => subID; set => subID = value; }
        public string CulName { get => culName; set => culName = value; }
        public string CulChineseName { get => culChineseName; set => culChineseName = value; }
        public string Description { get => description; set => description = value; }
        public string Images { get => images; set => images = value; }
        public bool IsDelete { get => isDelete; set => isDelete = value; }
        public string SchoolName { get => schoolName; set => schoolName = value; }
    }
}
