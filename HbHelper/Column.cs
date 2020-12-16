using System;
using System.Collections.Generic;
using System.Text;

namespace DbHelper {
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ColumnAttribute : Attribute {
        public string Name { get; set; }
        public ColumnAttribute(string name) {
            Name = name;
        }
    }
}
