using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cah264_mission09.Models.ViewModels
{
    public class BookstoreViewModel
    {
        public IQueryable<Book> Books { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
