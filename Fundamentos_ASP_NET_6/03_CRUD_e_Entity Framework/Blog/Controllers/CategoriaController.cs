﻿using Blog.Data;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpGet("v1/categorias")]
        public async Task<IActionResult> GetAsync([FromServices] BlogDataContext context)
        {
            try
            {
                var categorias = await context.Categorias.ToListAsync();
                return Ok(new ResultViewModel<List<Categoria>>(categorias));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Categoria>>("05X04 - Falha interna no servidor!"));
            }
        }

        [HttpGet("v1/categorias/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id, [FromServices] BlogDataContext context)
        {
            try
            {
                var categoria = await context.Categorias.FirstOrDefaultAsync(c => c.Id == id);

                if (categoria == null)
                    return NotFound(new ResultViewModel<Categoria>("Conteúdo não encontrado!"));

                return Ok(new ResultViewModel<Categoria>(categoria));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Categoria>("Falha interna no servidor!"));
            }
        }

        [HttpPost("v1/categorias")]
        public async Task<IActionResult> Postsync([FromBody] EditorCategoriaViewModel model, [FromServices] BlogDataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var categoria = new Categoria()
                {
                    Id = 0,
                    Nome = model.Nome,
                    Slug = model.Slug.ToLower(),
                };

                await context.Categorias.AddAsync(categoria);
                await context.SaveChangesAsync();

                return Created($"v1/categorias/{categoria.Id}", model);
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "05X09 - Não foi possível incluir a categoria!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "05X10 - Falha interna no servidor!");
            }
        }

        [HttpPut("v1/categorias/{id:int}")]
        public async Task<IActionResult> Putsync([FromRoute] int id, [FromBody] EditorCategoriaViewModel model, [FromServices] BlogDataContext context)
        {
            try
            {
                var categoria = await context.Categorias.FirstOrDefaultAsync(c => c.Id == id);

                if (categoria == null)
                    return NotFound();

                categoria.Nome = model.Nome;
                categoria.Slug = model.Slug;

                context.Categorias.Update(categoria);
                await context.SaveChangesAsync();

                return Ok(categoria);
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "05X08 - Não foi possível atualizar a categoria!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "05X11 - Falha interna no servidor!");
            }
        }

        [HttpDelete("v1/categorias/{id:int}")]
        public async Task<IActionResult> Deletesync([FromRoute] int id, [FromServices] BlogDataContext context)
        {
            try
            {
                var categoria = await context.Categorias.FirstOrDefaultAsync(c => c.Id == id);

                if (categoria == null)
                    return NotFound();

                context.Categorias.Remove(categoria);
                await context.SaveChangesAsync();

                return Ok(categoria);
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "05X07 - Não foi possível excluir a categoria!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "05X12 - Falha interna no servidor!");
            }
        }
    }
}
