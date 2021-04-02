//Puls web scaroed information back from Heroku Database

using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Threading.Tasks;
using System.Numerics;

public class CountryRepository : BaseRepository, IRepository<CountryObj>
{

    public CountryRepository(IConfiguration configuration) : base(configuration) { }

    public IEnumerable<CountryObj> Search(string search)
    {
        using var connection = CreateConnection();
        IEnumerable<CountryObj> countries = connection.Query<CountryObj>("SELECT * FROM GovAdvice2", new { Search = $"%{search}%" });
        return countries;
    }

    public IEnumerable<CountryObj> GetAll()
    {
        using var connection = CreateConnection();
        IEnumerable<CountryObj> countries = connection.Query<CountryObj>("SELECT * FROM GovAdvice2;");
        return countries;
    }

}