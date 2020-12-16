using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace DbHelper.ResultHandlers {
    public class ListResultHandler<T> : IResultHandler<List<T>> {
        public async Task<List<T>> Handle(NpgsqlDataReader reader) {
            var meta = ClassDbMeta<T>.Instance;
            var list = new List<T>();
            var columns = await reader.GetColumnSchemaAsync();
            while(await reader.ReadAsync()) {
                var t = Activator.CreateInstance<T>();
                foreach(DbColumn column in columns) {
                    var prop = meta.GetPropertyInfo(column.ColumnName);
                    if(prop == null) continue;
                    int ordinal = column.ColumnOrdinal!.Value;
                    Type valueTyp = prop.PropertyType;
                    object value = Tool.DefaultValueFormColumnToProp(reader, ordinal, valueTyp);
                    prop.SetValue(t, value);
                }
                list.Add(t);
            }
            return list;
        }
    }
}
