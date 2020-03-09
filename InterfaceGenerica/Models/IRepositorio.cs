using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InterfaceGenerica.Models
{
    public interface IRepositorio<T> where T : class
    {
        T Insert(T obj);
        void Update(T obj);
        T Delete(long id);
        T SelectById(long id);
        IEnumerable<T> SelectAll();
    }
}