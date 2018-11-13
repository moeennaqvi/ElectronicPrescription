using ElectronicRX2._1.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicRX2._1.DataAccess.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        List<T> Get();

        T Get(string id);

        T Update(T obj);

        T Insert(T obj);

        int Delete(T obj);
    }
} 