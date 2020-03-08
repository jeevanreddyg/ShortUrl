using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShortUrl.Domain;

namespace ShortUrl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private readonly ILinkRepository _repository;

        public LinkController(ILinkRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Link
        [HttpGet]
        public IEnumerable<Link> GetUrls()
        {
            return _repository.GetAll();
        }

        // GET: api/Link/5
        [HttpGet("{id}")]
        public ActionResult<Link> GetById(int id)
        {
            var urlModel = _repository.GetById(id);

            if (urlModel == null)
            {
                return NotFound();
            }

            return urlModel;
        }

        //// PUT: api/Url/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUrlModel(int id, Link urlModel)
        //{
        //    if (id != urlModel.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(urlModel).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UrlModelExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Url
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [Route("createshortlink")]
        [HttpPost]
        public ActionResult<Link> PostLink([FromBody]Link longUrl)
        {
            var urlModel = _repository.CreateShortUrl(longUrl.LongUrl);

            if (urlModel == null)
            {
                return NotFound();
            }

            return urlModel;
        }

        //// DELETE: api/Url/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Link>> DeleteUrlModel(int id)
        //{
        //    var urlModel = await _context.Urls.FindAsync(id);
        //    if (urlModel == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Urls.Remove(urlModel);
        //    await _context.SaveChangesAsync();

        //    return urlModel;
        //}

        //private bool UrlModelExists(int id)
        //{
        //    return _context.Urls.Any(e => e.Id == id);
        //}
    }
}
