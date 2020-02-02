using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAppWithMysql.Btctalk.Models
{
    public class Forum
    {
        [Column("fid")]
        public int FID { get; set; }
        [Column("level")]
        public int Level { get; set; }
        [Column("parent_fid")]
        public int ParentFID { get; set; }

        [Column("name")]
        public string Name { get; set; }
        [Column("title")]
        public string Title { get; set; }

        public ICollection<Topic> Topics { get; set; }

    }
    public class Topic
    {
        [Column("tid")]
        public int TID { get; set; }
        [Column("fid")]
        public int FID { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("created")]
        [DataType(DataType.Date)]
        public DateTime? Created { get; set; }
        [Column("updated")]
        [DataType(DataType.Date)]
        public DateTime? Updated { get; set; }
        [Column("viewers")]
        public int? Viewers { get; set; }
        [Column("responses")]
        public int? Responses { get; set; }
        [Column("reliable")]
        public float? Reliable { get; set; }

        public ICollection<ThreadResponse> ThreadResponses { get; set; }

    }

    public class ThreadResponse
    {
        [Column("tid")]
        public int TID { get; set; }
        [Column("fid")]
        public int FID { get; set; }
        [Column("responses")]
        public int? Responses { get; set; }
        [Column("last_post_date")]
        [DataType(DataType.Date)]
        public DateTime? LastPostDate { get; set; }
    }
}