//Puls web scaroed information back from Heroku Database

using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Dapper;
using Server.Models;
using System.Threading.Tasks;

namespace Server.Data
{ 

public class RedRepository : BaseRepository, IRepository<RedCountry>
{
    public RedRepository(IConfiguration configuration) : base(configuration) { }

    public IEnumerable<RedCountry> Search(string search)
    {
        using var connection = CreateConnection();
        IEnumerable<RedCountry> countries = connection.Query<RedCountry>("SELECT * FROM GovAdvice", new { Search = $"%{search}%" });

        return countries;
    }

    public IEnumerable<RedCountry> GetAll()
    {
        using var connection = CreateConnection();
        IEnumerable<RedCountry> countries = connection.Query<RedCountry>("SELECT * FROM GovAdvice;");
        return countries;
    }

}
}