using EFFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserOnBookModel : IBaseEntity
    {
        public int bookId { get; set; }
        public string UserName { get; set; }
        public string BookName { get; set; }
    }
}
