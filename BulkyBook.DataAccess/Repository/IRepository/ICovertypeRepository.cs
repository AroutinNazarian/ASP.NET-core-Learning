using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface ICovertypeRepository : IRepository<CoverType>
    {
        void Update(CoverType obj);
    }
}
