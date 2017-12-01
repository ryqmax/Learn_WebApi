using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuntApi.Com.Entity
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sex { get; set; }
        public bool IsDel { get; set; }
        public string Remark { get; set; }
    }
}
