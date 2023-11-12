using Npgsql.PostgresTypes;

namespace DapperTest.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }

        public double Rating { get; set; }

        public int  CountryId { get; set; }

        public Country country { get; set; }
    }
}
