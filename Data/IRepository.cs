using System.Collections.Generic;
using System.Threading.Tasks;
using System.Numerics;
using Server.Models;

namespace Server.Data
{
public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    IEnumerable<T> Search(string search);
}
} 