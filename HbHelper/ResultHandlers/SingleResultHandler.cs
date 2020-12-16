using Npgsql;
using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace DbHelper {
    internal class SingleResultHandler<T> : IResultHandler<T> {
        public async Task<T> Handle(NpgsqlDataReader reader) {
            var meta = ClassDbMeta<T>.Instance;
            var columns = await reader.GetColumnSchemaAsync();
            if(await reader.ReadAsync()) {
                var t = Activator.CreateInstance<T>();
                foreach(DbColumn column in columns) {
                    var prop = meta.GetPropertyInfo(column.ColumnName);
                    if(prop == null) continue;
                    int ordinal = column.ColumnOrdinal.Value;
                    Type valueTyp = prop.PropertyType;
                    object value = Tool.DefaultValueFormColumnToProp(reader, ordinal, valueTyp);
                    prop.SetValue(t, value);
                }
                return t;
            } else {
                return default;
            }
        }
    }
}