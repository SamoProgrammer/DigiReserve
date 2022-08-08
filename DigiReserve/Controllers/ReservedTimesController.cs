using DigiReserve.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DigiReserve.Models;
using DigiReserve.Entities;
using Microsoft.AspNetCore.Identity;
using DigiReserve.Authentication;
using Microsoft.AspNetCore.Authorization;
using DigiReserve.Logic;
using Microsoft.EntityFrameworkCore;

namespace DigiReserve.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservedTimesController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ReservedTimesController(DatabaseContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [Route("ReserveTime")]
        [HttpPost]
        public async Task<IActionResult> ReserveTime(ReserveTimeModel model)
        {
            if (!ModelState.IsValid) return BadRequest();
            var acceptor = _context.Users.Where(x => x.Id == model.AcceptorId).First();
            var acceptorRoles = await _userManager.GetRolesAsync(acceptor);
            var reservatore = _context.Users.Where(x => x.Id == model.ReservatoreId).First();
            var reservatoreRoles = await _userManager.GetRolesAsync(reservatore);
            if (acceptorRoles.FirstOrDefault() != "Acceptor" || reservatoreRoles.FirstOrDefault() != "Reservatore") return BadRequest();
            var reservedTimes = _context.ReservedTimes.Where(x => x.Acceptor == acceptor).ToList();
            if (CheckTimes.RequestTime(model.ReservedTime, reservedTimes) == false) return BadRequest();
            var time = new ReserveTime
            {
                Acceptor = acceptor,
                Reservatore = reservatore,
                Description = model.Description,
                ReservedTime = model.ReservedTime
            };
            await _context.ReservedTimes.AddAsync(time);
            await _context.SaveChangesAsync();
            return (Ok(time));
        }
        [Authorize(Roles = UserRoles.Reservatore)]
        [Route("GetReservedTimesByReservatore")]
        [HttpGet]
        public async Task<IActionResult> GetReservedTimes([FromHeader] string userId)
        {
            var user = _context.Users.Where(x => x.Id == userId).First();
            if (user == null) return BadRequest();
            var userRoles = await _userManager.GetRolesAsync(user);
            if (userRoles.First() != "Reservatore") return Unauthorized();
            var times = _context.ReservedTimes.Include(times => times.Reservatore)
                .Include(times => times.Acceptor)
                .Where(x => x.Reservatore == user).ToList();
            return Ok(times);
        }
        [Route("GetAvaliableTimesByAcceptor")]
        [HttpGet]
        public async Task<IActionResult> GetAvaliableTimes([FromHeader] string acceptorId)
        {
            var user = _context.Users.Where(x => x.Id == acceptorId).First();
            var userRoles = await _userManager.GetRolesAsync(user);
            if (userRoles.First() != "Acceptor") return Unauthorized();
            var reservedTimes = _context.ReservedTimes.Where(x => x.Acceptor == user).ToList();
            return Ok(CheckTimes.AvaliableTimes(reservedTimes));
        }
    }
}
