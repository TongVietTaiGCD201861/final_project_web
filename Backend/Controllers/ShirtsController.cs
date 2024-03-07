using AutoMapper;
using BackEnd.Attributes;
using BackEnd.Dtos;
using BackEnd.Models;
using BackEnd.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        private IShirtService _shirtService;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;    

        public ShirtsController(IShirtService shirtService, IMapper mapper, IEmailService emailService)
        {
            _shirtService = shirtService;
            _mapper = mapper;
            _emailService= emailService;

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IList<Shirt>>GetAll()
        {
            //await _emailService.Send("taitong.25052002@gmail.com", "R day", "<h1>Hello </h1>");
            return _shirtService.GetAll();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var shirt = _shirtService.GetById(id);
            return Ok(shirt);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = _shirtService.Delete(id);
            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult Create(ShirtUpsertDto input)
        {
            var shirt = _mapper.Map<Shirt>(input);
            _shirtService.Create(shirt);
            return Ok(shirt);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id, ShirtUpsertDto input)
        {
            var shirt = _shirtService.GetById(id);
            _mapper.Map(input, shirt);
            _shirtService.Update(shirt);
            return Ok(shirt);
        }
    }
}
