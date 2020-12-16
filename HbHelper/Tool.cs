using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace DbHelper {
    public static class Tool {
        public static object DefaultValueFormColumnToProp(IDataReader reader, int ordinal, Type valueTyp) {
            object value;
            if(valueTyp == typeof(string)) {
                value = reader.GetString(ordinal);
            } else if(valueTyp == typeof(int)) {
                value = reader.GetInt32(ordinal);
            } else if(valueTyp == typeof(DateTime)) {
                value = reader.GetDateTime(ordinal);
            } else if(valueTyp == typeof(long)) {
                value = reader.GetInt64(ordinal);
            } else if(valueTyp == typeof(Decimal)) {
                value = reader.GetDecimal(ordinal);
            } else if(valueTyp == typeof(double)) {
                value = reader.GetDouble(ordinal);
            } else if(valueTyp == typeof(float)) {
                value = reader.GetFloat(ordinal);
            } else {
                throw new Exception($"type: {valueTyp} has no mapper");
            }
            return value;
        }
    }
}
