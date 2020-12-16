using DbHelper;
using System.ComponentModel.DataAnnotations;

namespace My.Domain {
    public class ListedCompany {
        [Column("code")]
        public string Code { get; set; }
        [Column("typ")]
        public string Typ { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("code0"), Required, MaxLength(6)]
        public string Code_0 { get; set; }
    }
}
