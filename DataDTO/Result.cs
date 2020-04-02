using EFFramework.DLog;
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


        public Result GetException(Exception exception)
        {
            this.msg = exception.Message;
            this.success = false;
            this.code = "-1";
            Log.Error(GetMsg(exception));
            return this;
        }

        private string GetMsg(Exception exception)
        {
            return "异常:Message=" + exception.Message + " || Source=" + exception.Source + " || TargetSite=" + exception.TargetSite+ " || InnerException=" + exception.InnerException.InnerException.Message;
        }
    }
    public class PageResult: Result
    {
        public int count { get; set; }
    }
}
