using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos.Models.DTO
{
    public class MusicianGetter
    {
        public int IdMusician { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string TrackName { get; set; }
        public float Duration { get; set; }
    }
}
