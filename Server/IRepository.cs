using System.Collections.Generic;
using System.Threading.Tasks;
using System.Numerics;


public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    IEnumerable<T> Search(string search);
}