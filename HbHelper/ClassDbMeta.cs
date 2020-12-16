using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DbHelper {
    class Locker<T> {
        public Locker() {
        }
    }
    public class ClassDbMeta<T> {

        private static ClassDbMeta<T> instance;
        //private static readonly object locker = new object();
        public static ClassDbMeta<T> Instance {
            get {
                if(instance == null) {
                    lock(typeof(ClassDbMeta<T>)) {
                        if(instance == null) {
                            instance = new ClassDbMeta<T>();
                        }
                    }
                }
                return instance;
            }
        }

        public Type Type { get; }
        private Dictionary<string, PropertyInfo> ColumnPropMap { get; } = new Dictionary<string, PropertyInfo>();
        private ClassDbMeta() {
            Type = typeof(T);
            //ColumnPropMap = GetColumnPropMap(Type);
            foreach(var i in Type.GetProperties()) {
                if(i.IsDefined(typeof(ColumnAttribute), false)) {
                    if(i.GetCustomAttributes(false)
                        .Where(x => x is ColumnAttribute)
                        .First()
                        is ColumnAttribute attr && attr.Name != null) {
                        ColumnPropMap.Add(attr.Name, i);
                    }
                }
            }
        }

        public PropertyInfo GetPropertyInfo(string columnName) {
            ColumnPropMap.TryGetValue(columnName, out PropertyInfo info);
            return info;
        }
    }
}
