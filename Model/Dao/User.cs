using BgDapper;
using System;

namespace Model.Dao
{
    public class User
    {
        [Column("UserId")]
        public string UserId { get; set; }
        public string Nick { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
