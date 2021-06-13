using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectAPI.Contexts;
using ProjectAPI.Models;
using ProjectAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService=null;
        private ApplicationDbContext appdbcontext = null;

        public UserController(IUserService userService, ApplicationDbContext _adb)
        {
            _userService = userService;
            appdbcontext = _adb;
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult> RegisterAsync(RegisterModel model)
        {
            try
            {
                var result = await _userService.RegisterAsync(model);
                if (result.StartsWith("Error"))
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("GenerateToken")]
        public async Task<IActionResult> GetTokenAsync(TokenRequestModel model)
        {
            var result = await _userService.GetTokenAsync(model);
            if(string.IsNullOrEmpty( result.Token))
                return NotFound(" "+ result.Message);

            return Ok(result.Token);
        }
        
        [Authorize]
        [HttpGet]
        [Route("AllCities")]
        public IActionResult GetAllCities(string Email)
        {
            if (appdbcontext.CountryInfos == null || !appdbcontext.CountryInfos.Any())
                return Ok("No Country-Cities created as yet.");

            var res = appdbcontext.CountryInfos.Where(aa => aa.Email == Email).
                Select(xx => new 
                            {
                                City = xx.City,
                                Email = xx.Email,
                                Isfavourite = xx.Isfavourite
                            });

            if (res.Count() < 1)
            {
                return NotFound("No records against this UserEmail" + Email);
            }
            else
                return Ok(res);
        }

        [Authorize]
        [HttpGet]
        [Route("FavoriteCities")]
        public IActionResult GetFavoriteCities(string Email)
        {
            if (appdbcontext.CountryInfos == null || !appdbcontext.CountryInfos.Any())
                return NoContent();

            var res = appdbcontext.CountryInfos.Where(aa => aa.Email == Email &&
                aa.Isfavourite == true).Select(xx => new
                {
                    City = xx.City,
                    Email = xx.Email,
                    Isfavourite = xx.Isfavourite
                }).ToList();

            if (res.Count() < 1)
            {
                return NotFound("No records against this email.");
            }
            else
                return Ok(res);
        }

        [Authorize]
        [HttpPost]
        [Route("CreateCity")]
        public IActionResult PostData(CountryInfo ck)
        {
            try
            {
                var res = appdbcontext.CountryInfos.Where(aa => aa.Email == ck.Email &&
                 aa.City == ck.City).Take(1);
                
                if (res.Any())// duplicate records
                    return Conflict($"This city already added for Email { ck.Email }");

                appdbcontext.CountryInfos.Add(ck);
                appdbcontext.SaveChanges();

                return Ok("City-Country data created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating records {  ex.Message}");
            }
        }

        [Authorize]
        [HttpPut]
        [Route("Updatecity")]
        public IActionResult PutData(CountryInfo ck)
        {
            try
            {
           var ccity= appdbcontext.CountryInfos.Where(k=>k.Email==ck.Email).FirstOrDefault();
                if (ccity != null)
                {
                    ccity.City = ck.City;
                    ccity.Isfavourite = ck.Isfavourite;
                    ccity.Country = ck.Country;
                    appdbcontext.SaveChanges();

                    return Ok("City-Country data updated successfully.");
                }
                else
                    return NotFound();
                
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating records {  ex.Message}");
            }
        }

    }
}