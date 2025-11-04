using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.TablesObjects
{
    public class UserBlockID
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public bool IsBlocked { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
