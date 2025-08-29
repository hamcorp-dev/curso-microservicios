using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGlobal.Models
{
    [Table(("adults"))]
    public class Adult
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("name")]
        public string Name { get; set; }
        
        [Column("lastname")]
        public string Lastname { get; set; }
        
        [Column("birthyear")]
        public int BirthYear { get; set; }
        
        [Column("imageurl")]
        public string ImageUrl { get; set; }
    }
}