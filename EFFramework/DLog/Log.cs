using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace EFFramework.DLog
{ 
    public static class Log
    {

        /// <summary>
        /// 一般错误
        /// </summary>
        /// <param name="message">消息</param>
        public static void Error(object message)
        {
            ILog log = LogManager.GetLogger(GetCurrentMethodFullName());
            log.Error(message);

        }

        /// <summary>
        /// 一般错误
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="exception">异常</param>
        public static void Error(object message, System.Exception exception)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(GetCurrentMethodFullName());
            log.Error(message, exception);
        }


        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="message">消息</param>
        public static void Info(object message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(GetCurrentMethodFullName());
            log.Info(message);
        }

        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="exception">异常</param>
        public static void Info(object message, System.Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(GetCurrentMethodFullName());
            log.Info(message, ex);
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message">消息</param>
        public static void Warn(object message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(GetCurrentMethodFullName());
            log.Warn(message);
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="exception">异常</param>
        public static void Warn(object message, System.Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(GetCurrentMethodFullName());
            log.Warn(message, ex);
        }

        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="message">消息</param>
        public static void Debug(object message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(GetCurrentMethodFullName());
            log.Debug(message);
        }

        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="exception">异常</param>
        public static void Debug(object message, System.Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(GetCurrentMethodFullName());
            log.Debug(message, ex);
        }

        static string GetCurrentMethodFullName()
        {
            try
            {
                int depth = 2;
                StackTrace st = new StackTrace();
                int maxFrames = st.GetFrames().Length;
                StackFrame sf;
                string methodName, className;
                Type classType;
                do
                {
                    sf = st.GetFrame(depth++);
                    classType = sf.GetMethod().DeclaringType;
                    className = classType.ToString();
                } while (className.EndsWith("Exception") && depth < maxFrames);
                methodName = sf.GetMethod().Name;
                return className + "." + methodName;
            }
            catch
            {
                return null;
            }
        }
    }
}
