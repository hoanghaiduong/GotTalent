using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EF
{
    public class DetailMark
    {
        int jubgeID, orgID, culId, criteriaID;
        double mark; string comments;

        public int JubgeID { get => jubgeID; set => jubgeID = value; }
        public int OrgID { get => orgID; set => orgID = value; }
        public int CulId { get => culId; set => culId = value; }
        public int CriteriaID { get => criteriaID; set => criteriaID = value; }
        public double Mark { get => mark; set => mark = value; }
        public string Comments { get => comments; set => comments = value; }
    }
}
