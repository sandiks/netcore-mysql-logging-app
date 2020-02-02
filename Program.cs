using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore;
using System;
using System.Text;
using System.Threading;
using BookAppWithMysql.Btctalk;
using System.Linq;

namespace BookAppWithMysql
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintData();
        }

        private async static void PrintData()
        {
            using (var context = new BtctalkContext())
            {
                try
                {
                    var query = context.Forums
                    .Include(f => f.Topics)
                    // .Include(f => f.Topics).ThenInclude(t => t.ThreadResponses)
                    .AsNoTracking();

                    // var sqlText = query.ToSql();
                    // Console.WriteLine($"raw sql: {sqlText}");
                    
                    var forums = await query.FirstOrDefaultAsync();
                    
                    Console.WriteLine($"count={forums.Topics.Count}");

                    foreach (var tt in forums.Topics.Take(5))
                    {
                        var info = $" Title: {tt.Title} reliable: {tt.Reliable}";
                        // var info = $" Title: {tt.Title} reliable: {tt.Reliable} count {tt.ThreadResponses.Count}";
                        Console.WriteLine(info);
                    }

                    //var topics = await context.Topics.FirstOrDefaultAsync(m => m.ID == id);;
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }
        }
    }
}