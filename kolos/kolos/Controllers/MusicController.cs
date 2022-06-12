using kolos.Models;
using kolos.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace kolos.Controllers
{
    [Route("/api/musicFactory")]
    [ApiController]
    public class MusicControlller : ControllerBase
    {
        private readonly IDbService _dbService;

        public MusicControlller(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        [Route("/api/musicFactory/{IdMusician}")]
        public async Task<IActionResult> GetMusician(int IdMusician)
        {
            var musicianGetter = await _dbService.GetMusicianTrack(IdMusician);
            return Ok(musicianGetter);
        }


        [HttpDelete]
        [Route("/api/musicFactory/{IdMusician}")]
        public async Task<IActionResult> RemoveMusician(int IdMusician)
        {
            int result = _dbService.RemoveMusician(IdMusician).Result;
            if (result == 1)
            {
                return BadRequest("Cant delete");

            }
            return Ok("Removed Musician");

        }


    }
    
}