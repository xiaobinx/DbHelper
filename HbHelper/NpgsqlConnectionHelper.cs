using DbHelper.ResultHandlers;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace DbHelper {
    public static class NpgsqlConnectionHelper {
        public static async Task<T> QuerySingleAsync<T>(this NpgsqlConnection conn, string sql, object paramObj) {
            return await conn.QueryAsync(sql, paramObj, new SingleResultHandler<T>());
        }

        public static async Task<List<T>> QueryListAsync<T>(this NpgsqlConnection conn, string sql, object paramObj) {
            return await conn.QueryAsync(sql, paramObj, new ListResultHandler<T>());
        }

        public static async Task<T> QueryAsync<T>(this NpgsqlConnection conn, string sql, object paramObj, IResultHandler<T> handler) {
            await using var cmd = new NpgsqlCommand(sql, conn);
            var props = paramObj.GetType().GetProperties();
            foreach(var prop in props) {
                var value = prop.GetValue(paramObj);
                if(null == value) {
                    cmd.Parameters.AddWithValue(prop.Name, DBNull.Value);
                } else {
                    cmd.Parameters.AddWithValue(prop.Name, prop.GetValue(paramObj));
                }
            }
            await using var reader = await cmd.ExecuteReaderAsync();
            return await handler.Handle(reader);
        }
    }
}
