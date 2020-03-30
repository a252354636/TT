using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDTO
{
    public class Result
    {
        public Result()
        {
            success = true;
            msg = "操作成功！";
            code = "0";
        }
        public bool success { get; set; }
        public string msg { get; set; }
        public object data { get; set; }
        public string code { get; set; }
    }
    public class PageResult
    {
        public PageResult()
        {
            success = true;
            msg = "操作成功！";
            code = "0";
        }
        public bool success { get; set; }
        public string msg { get; set; }
        public object data { get; set; }
        public string code { get; set; }
        public int count { get; set; }
    }
}
