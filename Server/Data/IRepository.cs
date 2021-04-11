using System.Collections.Generic;
using System.Threading.Tasks;
using System.Numerics;
using Server.Models;

namespace Server.Data
{
public interface IRepository
{
    IEnumerable<CountryObj> GetAll();
    IEnumerable<CountryObj> Search(string search);
}
} 