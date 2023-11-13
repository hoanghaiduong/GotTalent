using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EF
{
    public class Subject
    {
        int subID;
        string subName, subChineseName;
        bool isDelete;

        public int SubID { get => subID; set => subID = value; }
        public string SubName { get => subName; set => subName = value; }
        public string SubChineseName { get => subChineseName; set => subChineseName = value; }
        public bool IsDelete { get => isDelete; set => isDelete = value; }
    }
}
