using System;
using System.ComponentModel.DataAnnotations;

namespace Sample.CRUDSQLiteEFCore.Model
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }

        [Required]
        [MaxLength(128)]
        public string Title { get; set; }

        [Required]
        [MaxLength(256)]
        public string SubTitle { get; set; }

        [Required]
        public DateTime DateTimeAdd { get; set; }
    }
}
