using OrderFlow.Data;
using OrderFlow.Data.Tables;

namespace OrderFlow.Util
{
    public static class Validator
    {
        private static DateTime s_lastRefresh = DateTime.MinValue;
        private static List<Table> s_cachedTables = new List<Table>();

        public static bool ValidTableCode(string code)
        {
            if ((DateTime.Now - s_lastRefresh).Minutes >= 1 || s_lastRefresh == DateTime.MinValue)
            {
                s_cachedTables = refreshTables();
            }

            return s_cachedTables.Exists(e => e.TableCode == code);
        }

        private static List<Table> refreshTables()
        {
            using (var db = new DatabaseDbContext())
            {
                var tables = db.Tables
                    .Select(e => e)
                    .ToList();

                return tables;
            }
        }
    }
}
