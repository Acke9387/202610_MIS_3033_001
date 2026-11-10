using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class AnimesController : ControllerBase
{
    private readonly DB_128040_practiceContext _context;
    public AnimesController(DB_128040_practiceContext context)
    {
        _context = context;
    }

    // GET: api/Anime
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Anime>>> GetAnime([FromQuery] int? minEpisodes = 0)
    {
        return await _context.Animes.Where(a => a.Episodes >= minEpisodes).ToListAsync();
    }

    // GET: api/Anime/5
    [HttpGet("{animeid}")]
    public async Task<ActionResult<Anime>> GetAnime(int animeid)
    {
        var anime = await _context.Animes.FindAsync(animeid);

        if (anime == null)
        {
            return NotFound();
        }

        return anime;
    }

    // PUT: api/Anime/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{animeid}")]
    public async Task<IActionResult> PutAnime(int? animeid, Anime anime)
    {
        if (animeid != anime.AnimeId)
        {
            return BadRequest();
        }

        _context.Entry(anime).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AnimeExists(animeid))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Anime
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Anime>> PostAnime(Anime anime)
    {
        _context.Animes.Add(anime);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetAnime", new { animeid = anime.AnimeId }, anime);
    }

    // DELETE: api/Anime/5
    [HttpDelete("{animeid}")]
    public async Task<IActionResult> DeleteAnime(int? animeid)
    {
        var anime = await _context.Animes.FindAsync(animeid);
        if (anime == null)
        {
            return NotFound();
        }

        _context.Animes.Remove(anime);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AnimeExists(int? animeid)
    {
        return _context.Animes.Any(e => e.AnimeId == animeid);
    }
}
