using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace N5_API.Project.Models.Blob
{
    [Table("clch_claim_collection_history")]
    public class ClaimCollectionHistory
    {
        [Column("id")]
        public long id { get; set; }

        [Column("tid")]
        public Guid tid { get; set; }

        [Column("app_id")]
        public long app_id { get; set; }

        [Column("dom_id")]
        public long dom_id { get; set; }

        [Column("usr_id")]
        public long usr_id { get; set; }

        [Column(TypeName = "jsonb")]
        public string data { get; set; }
    }
}
    