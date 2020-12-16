using My.Domain;
using Npgsql;
using System;
using DbHelper;
using System.Threading.Tasks;

namespace Test {
    class Program {
        static void Main(string[] _) {
            Task.Run(async () => await TestDb());
            Console.ReadKey();
            //TestPojo();
        }

        public static async Task TestDb() {
            var connString = "Host=127.0.0.1;Database=MyDb;Username=postgres;Password=q123456";
            await using var runner = new NpgsqlConnection(connString);
            await runner.OpenAsync();
            //var sql = "SELECT * FROM k_day_data k where close > @Close LIMIT @Adjustflag";
            //var k = await runner.QueryListAsync<KDayData>(sql, param);
            var sql = "SELECT * FROM listed_company l where code = @code LIMIT 10";
            var com = await runner.QuerySingleAsync<ListedCompany>(sql, new { code = "sh.600319" });
            System.Console.WriteLine(com);
        }
    }
}
