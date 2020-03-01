using EFFramework;
using Models.Entitys;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class BookController : Controller
    {
        BooksOrUsersService service = new BooksOrUsersService();
        public BookController()
        {
        }


        //
        // GET: /Book/
        [Authorize]
        public ActionResult Index()
        {
            // Book b = new Book();
            //b.ID = 7;
            //b.Uid = 1;
            //b.Name = "天书奇谈" + DateTime.Now;
            //users u = new users();
            //u.id = 1;
            //u.user_name = "周杰伦" + DateTime.Now;
            //service.Add(b);
            //service.Add(u);
            //service.Commit();

            users u = service.GetModel<users>(s => s.id == 13);
            //book.Name = "天天向上";
            // List<UserOnBookModel> bk = service.GetSqlQuery<UserOnBookModel>();
            u.nick_name += "哈哈哈啊哈哈哈哈";
            service.Commit();
            return Content(u.nick_name);
            // return Content("");
        }

    }
}
