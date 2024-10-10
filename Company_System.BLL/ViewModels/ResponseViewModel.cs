using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_System.BLL.ViewModels
{
    public class ResponseViewModel
    {
        public bool Successed { get; set; } = false;
        public List<string> Errors { get; set; }
    }
}
