
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace kolos.Services
{
    public class Track
    {
        [Key]
        public int IdTrack { get; set; }
        [Required]
        [MaxLength(20)]
        public string TrackName { get; set; }
        [Required]
        public float Duration { get; set; }
        public int? IdMusicAlbum { get; set; }
        public Album Album { get; set; }
        public virtual ICollection<Musician_Track> Musician_Tracks { get; set; }
    }
}
