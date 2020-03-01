using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDTO.Request.Merge
{
  public   class QueryMergePayInfo: BasePageReques
    {
        public string Name { get; set; }
        public string IdentityCardNo { get; set; }
        public List<int> StatusList { get; set; }
    }
}
