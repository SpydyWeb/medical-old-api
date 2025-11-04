using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.TablesObjects
{
    public class t_Yakeen_AddressInfo
    {
        public int ID { get; set; }
        public long CR_NUMBER { get; set; }
        public int? ADDITIONAL_NUMBER { get; set; }
        public int? BUILDING_NUMBER { get; set; }
        public string CITY { get; set; }
        public string DISTRICT { get; set; }
        public int? POST_CODE { get; set; }
        public string STREET_NAME { get; set; }
        public string LATITUDE { get; set; }
        public string LONGITUDE { get; set; }
        public bool? IsPrimaryAddress { get; set; }
    }
}
