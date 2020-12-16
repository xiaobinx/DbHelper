using DbHelper;
using System;

namespace My.Domain {
    public class KDayData {
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("code")]
        public string Code { get; set; }
        [Column("open")]
        public decimal Open { get; set; }
        [Column("high")]
        public decimal High { get; set; }
        [Column("low")]
        public decimal Low { get; set; }
        [Column("close")]
        public decimal Close { get; set; }
        [Column("preclose")]
        public decimal Preclose { get; set; }
        [Column("volume")]
        public long Volume { get; set; }
        [Column("amount")]
        public decimal Amount { get; set; }
        [Column("adjustflag")]
        public int Adjustflag { get; set; }
        [Column("turn")]
        public decimal Turn { get; set; }
        [Column("tradestatus")]
        public int Tradestatus { get; set; }
        [Column("pctchg")]
        public decimal Pctchg { get; set; }
        [Column("pettm")]
        public decimal Pettm { get; set; }
        [Column("psttm")]
        public decimal Psttm { get; set; }
        [Column("pcfncfttm")]
        public decimal Pcfncfttm { get; set; }
        [Column("pbmrq")]
        public decimal Pbmrq { get; set; }
        [Column("isst")]
        public int Isst { get; set; }
    }
}
