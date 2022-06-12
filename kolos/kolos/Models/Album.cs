
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace kolos.Services
{
    public class Album
    {
        [Key]
        public int IdAlbum { get; set; }
        [Required]
        [MaxLength(30)]
        public string AlbumName { get; set; }
        [Required]
        public System.DateTime PublishDate { get; set; }
        public int IdMusicLabel { get; set; }
        public MusicLabel MusicLabel { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
