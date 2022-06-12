using kolos.Models;
using kolos.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace kolos.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _context;
        public DbService(MainDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MusicianGetter>> GetMusicianTrack(int idMusician)
        {
            return await _context.Musician_Tracks
                    .Include(e => e.Musician)
                    .Include(e => e.Track)
                    .Select(e => new MusicianGetter
                    {
                        IdMusician = e.Musician.IdMusician,
                        FirstName = e.Musician.FirstName,
                        LastName = e.Musician.LastName,
                        NickName = e.Musician.NickName,
                        TrackName = e.Track.TrackName,
                        Duration = e.Track.Duration
                    })
                    .Where(e => e.IdMusician == idMusician)
                    .OrderBy(e => e.Duration)
                    .ToListAsync();
        }

        public async Task<int> RemoveMusician(int idMusician)
        {
            var musicianCheck = _context.Musician_Tracks.Where(e => e.IdMusician == idMusician).FirstOrDefault();
            var albumCheck = _context.Tracks.Where(e => e.IdTrack == musicianCheck.IdTrack && e.IdMusicAlbum == null).FirstOrDefault();
            if (albumCheck == null)
            {
                var musician = _context.Musicians.Where(e => e.IdMusician == idMusician).FirstOrDefault();
                    _context.Musicians.Remove(musician);
                    await _context.SaveChangesAsync();
                    return 0;
            }
            return 1;

        }

    }
}