using kolos.Models;
using kolos.Models.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kolos.Models
{
    public interface IDbService
    {
        Task<IEnumerable<MusicianGetter>> GetMusicianTrack(int idMusician);
        Task<int> RemoveMusician(int idMusician);
    }
}
