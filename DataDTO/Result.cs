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
            success = false;
            msg = "操作失败";
            result = "0";
        }
        public bool success { get; set; }
        public string msg { get; set; }
        public object data { get; set; }
        public string result { get; set; }
    }
    public class PageResult
    {
        public PageResult()
        {
            success = false;
            msg = "操作失败";
            result = "0";
        }
        public bool success { get; set; }
        public string msg { get; set; }
        public object data { get; set; }
        public string result { get; set; }
        public int count { get; set; }
    }
}
