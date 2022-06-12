
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace kolos.Services
{
    public class Musician_Track
    {
        public int IdTrack { get; set; }
        public int IdMusician { get; set; }
        public Musician Musician { get; set; }
        public Track Track { get; set; }
    }
}
