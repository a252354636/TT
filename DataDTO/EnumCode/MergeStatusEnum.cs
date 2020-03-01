using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDTO.EnumCode
{
    public enum MergeStatusEnum
    {
        [Description("待支付")]
        AfterMerger = 1,
        [Description("支付成功")]
        Succeed = 2,
        [Description("打回")]
        NeedUpdated = 3,
        [Description("已更新")]
        HasUpdated = 4,
    }
}
