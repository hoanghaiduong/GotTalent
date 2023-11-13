using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EF
{
    public class Judges
    {
        int jubgeID;
        string title, jubgeName, phone, address, images;
        bool isDelete;

        public int JubgeID { get => jubgeID; set => jubgeID = value; }
        public string Title { get => title; set => title = value; }
        public string JubgeName { get => jubgeName; set => jubgeName = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public string Images { get => images; set => images = value; }
        public bool IsDelete { get => isDelete; set => isDelete = value; }
    }
}
