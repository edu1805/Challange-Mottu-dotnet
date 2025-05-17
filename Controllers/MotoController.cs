using AutoMapper;
using Cp2WebApplication.Domain.Entities;
using Cp2WebApplication.Infrastructure.Context;
using Cp2WebApplication.Infrastructure.DTOs;
//using Cp2WebApplication.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cp2WebApplication.Controllers
{

    [ApiController]
    [Route("api/motos")]
    public class MotoController : ControllerBase
    {
        private readonly Cp2Context _context;
        private readonly IMapper _mapper;

        public MotoController(Cp2Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/motos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotoDto>>> GetAll([FromQuery] string? status = null)
        {
            var query = _context.Motos.AsQueryable();

            if (!string.IsNullOrWhiteSpace(status))
                query = query.Where(m => m.Status == status.ToLower());

            var motos = await query.ToListAsync();
            return Ok(_mapper.Map<List<MotoDto>>(motos));
        }

        // GET: api/motos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MotoDto>> GetById(int id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null) return NotFound();

            return Ok(_mapper.Map<MotoDto>(moto));
        }

        // POST: api/motos
        [HttpPost("criar")]
        public async Task<ActionResult<MotoDto>> Create(CreateMotoDto dto)
        {
            try
            {
                var novaMoto = new Moto(dto.Placa, dto.Posicao, dto.Status);

                _context.Motos.Add(novaMoto);
                await _context.SaveChangesAsync();

                var result = _mapper.Map<MotoDto>(novaMoto);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        // PUT: api/motos/editar/5
        [HttpPut("editar/{id}")]
        public async Task<ActionResult> Update(int id, CreateMotoDto dto)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null) return NotFound();

            try
            {
                moto.AtualizarPlaca(dto.Placa);
                moto.AtualizarPosicao(dto.Posicao);
                moto.AtualizarStatus(dto.Status);

                _context.Motos.Update(moto);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        // DELETE: api/motos/delete/5
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null) return NotFound();

            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
