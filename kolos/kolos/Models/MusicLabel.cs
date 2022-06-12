
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace kolos.Services
{
    public class MusicLabel
    {
        [Key]
        public int IdMusicLabel { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}
