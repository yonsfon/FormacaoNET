using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using NobelApi.Models;

namespace NobelApi.Controllers
{
    /// <summary>
    /// Controlador para gerir a tabela PremioNobel
    /// </summary>
    public class PremioNobelsController : ApiController
    {
        private NobelEntities db = new NobelEntities();

        /// <summary>
        /// Método para extrair a lista de Prémios Nobel
        /// </summary>
        /// <returns></returns>
        // GET: api/PremioNobels
        public IQueryable<PremioNobelDTO> GetPremioNobel()
        {
            return db.PremioNobel.Select(t => new PremioNobelDTO()
            {
                PremioNobelId = t.PremioNobelId,
                Ano = t.Ano,
                Categoria = new CategoriaDTO()
                {
                    CategoriaID = t.CategoriaId,
                    Nome = t.Categoria.Nome,
                },
                Motivacao = t.Motivacao,
                Titulo = t.Titulo,
            }).OrderBy(t => t.Ano);
        }


        /// <summary>
        /// Método para recolher a informação especifica de um prémio nobel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/PremioNobels/5
        [ResponseType(typeof(PremioNobel))]
        public IHttpActionResult GetPremioNobel(int id)
        {
            if (!PremioNobelExists(id))
                return NotFound();


            PremioNobelDetailsDTO premioNobel = db.PremioNobel.Include("Categoria").Include("Laureado").Where(t => t.PremioNobelId == id).
                Select(p => new PremioNobelDetailsDTO()
                {
                    PremioNobelId = p.PremioNobelId,
                    Ano = p.Ano,
                    Motivacao = p.Motivacao,
                    Titulo = p.Titulo,
                    Categoria = new CategoriaDTO()
                    {
                        CategoriaID = p.CategoriaId,
                        Nome = p.Categoria.Nome
                    },

                    Individuo = p.Laureado.Where(t => t.LaureadoTipo == "I").Select(x => new LaureadoIndividuoDTO()
                    {
                        LaureadoId = x.LaureadoId,
                        Nome = x.LaureadoIndividuo.Nome,
                        DataNascimento = x.LaureadoIndividuo.DataNascimento,
                        DataMorte = x.LaureadoIndividuo.DataMorte,
                        Sexo = x.LaureadoIndividuo.Sexo

                    }).ToList(),

                    Organizacao = p.Laureado.Where(t => t.LaureadoTipo == "O").Select(x => new LaureadoOrganizacaoDTO()
                    {
                        LaureadoId = x.LaureadoId,
                        Nome = x.LaureadoOrganizacao.Nome,
                    }).ToList(),


        }).FirstOrDefault();

            if (premioNobel == null)
            {
                return NotFound();
    }

            return Ok(premioNobel);
}

//// PUT: api/PremioNobels/5
//[ResponseType(typeof(void))]
//public IHttpActionResult PutPremioNobel(int id, PremioNobel premioNobel)
//{
//    if (!ModelState.IsValid)
//    {
//        return BadRequest(ModelState);
//    }

//    if (id != premioNobel.PremioNobelId)
//    {
//        return BadRequest();
//    }

//    db.Entry(premioNobel).State = EntityState.Modified;

//    try
//    {
//        db.SaveChanges();
//    }
//    catch (DbUpdateConcurrencyException)
//    {
//        if (!PremioNobelExists(id))
//        {
//            return NotFound();
//        }
//        else
//        {
//            throw;
//        }
//    }

//    return StatusCode(HttpStatusCode.NoContent);
//}

//// POST: api/PremioNobels
//[ResponseType(typeof(PremioNobel))]
//public IHttpActionResult PostPremioNobel(PremioNobel premioNobel)
//{
//    if (!ModelState.IsValid)
//    {
//        return BadRequest(ModelState);
//    }

//    db.PremioNobel.Add(premioNobel);
//    db.SaveChanges();

//    return CreatedAtRoute("DefaultApi", new { id = premioNobel.PremioNobelId }, premioNobel);
//}

//// DELETE: api/PremioNobels/5
//[ResponseType(typeof(PremioNobel))]
//public IHttpActionResult DeletePremioNobel(int id)
//{
//    PremioNobel premioNobel = db.PremioNobel.Find(id);
//    if (premioNobel == null)
//    {
//        return NotFound();
//    }

//    db.PremioNobel.Remove(premioNobel);
//    db.SaveChanges();

//    return Ok(premioNobel);
//}

protected override void Dispose(bool disposing)
{
    if (disposing)
    {
        db.Dispose();
    }
    base.Dispose(disposing);
}

private bool PremioNobelExists(int id)
{
    return db.PremioNobel.Count(e => e.PremioNobelId == id) > 0;
}
    }
}