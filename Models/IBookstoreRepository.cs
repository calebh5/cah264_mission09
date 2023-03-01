using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cah264_mission09.Models
{
    public interface IBookstoreRepository
    {
        IQueryable<Book> Books { get; }
    }
}
