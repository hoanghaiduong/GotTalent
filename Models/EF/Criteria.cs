using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EF
{
    public class Criteria
    {
        int criteriaID, subID;
        string criteriaName, criteriaChineseName;
        double maxMark;
        bool isDelete = false;

        public int CriteriaID { get => criteriaID; set => criteriaID = value; }
        public int SubID { get => subID; set => subID = value; }
        public string CriteriaName { get => criteriaName; set => criteriaName = value; }
        public string CriteriaChineseName { get => criteriaChineseName; set => criteriaChineseName = value; }
        public double MaxMark { get => maxMark; set => maxMark = value; }
        public bool IsDelete { get => isDelete; set => isDelete = value; }
    }
}
