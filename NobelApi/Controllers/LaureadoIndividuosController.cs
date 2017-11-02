﻿using System;
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
    public class LaureadoIndividuosController : ApiController
    {
        private NobelEntities db = new NobelEntities();

        // GET: api/LaureadoIndividuos
        //// GET: api/LaureadoIndividuos
        /// <summary>
        /// Método para a recolha da lista de Individuos Laureados
        /// </summary>
        /// <returns></returns>
        public IQueryable<LaureadoIndividuoDTO> GetLaureadoIndividuo()
        {
            return db.LaureadoIndividuo.Select(p => new LaureadoIndividuoDTO
            {
                DataMorte = p.DataMorte,
                DataNascimento = p.DataNascimento,
                LaureadoId = p.LaureadoId,
                Nome = p.Nome,
                Sexo = p.Sexo
            });
        }

        // GET: api/LaureadoIndividuos/5
        /// <summary>
        /// Método para a recolha de informação detalhada de um Individuo Laureado
        /// </summary>
        /// <param name="id">ID do Individuo Laureado</param>
        /// <returns></returns>
        [ResponseType(typeof(LaureadoIndividuoDetailsDTO))]
        public IHttpActionResult GetLaureadoIndividuo(int id)
        {
            if (!LaureadoIndividuoExists(id))
            {
                return NotFound();
            }
            LaureadoIndividuoDetailsDTO laureadoIndividuo = null;
            laureadoIndividuo = db.LaureadoIndividuo
                .Where(p => p.LaureadoId == id).Select(p => new LaureadoIndividuoDetailsDTO
                {
                    LaureadoId = p.LaureadoId,
                    Sexo = p.Sexo,
                    Nome = p.Nome,
                    DataNascimento = p.DataNascimento,
                    DataMorte = p.DataMorte,
                    CidadeMorte = p.CidadeMorteId.HasValue ? new CidadeDTO()
                    {
                        CidadeId = p.CidadeMorte.CidadeId,
                        Nome = p.CidadeMorte.Nome,
                        Pais = new PaisDTO()
                        {
                            PaisID = p.CidadeMorte.PaisId,
                            Nome = p.CidadeMorte.Pais.Nome
                        }
                    } : null,
                    CidadeNascimento = new CidadeDTO()
                    {
                        CidadeId = p.CidadeNascimento.CidadeId,
                        Nome = p.CidadeNascimento.Nome,
                        Pais = new PaisDTO()
                        {
                            PaisID = p.CidadeNascimento.PaisId,
                            Nome = p.CidadeNascimento.Pais.Nome,
                        }
                    },
                    //PremioNobel = new List<PremioNobelDTO>()
                    Filiacao = p.Filiacao.Select(t => new FiliacaoDTO()
                    {
                        Nome = t.Nome,
                        FiliacaoId = t.FiliacaoId,
                        Cidade = new CidadeDTO()
                        {
                            CidadeId = t.CidadeId,
                            Nome  = t.Cidade.Nome,
                            Pais = new PaisDTO()
                            {
                                PaisID = t.Cidade.PaisId,
                                Nome = t.Cidade.Pais.Nome
                            }
                        },
                    }).ToList()


                }).FirstOrDefault();

            if (laureadoIndividuo == null)
                return NotFound();

            List<Laureado> Premios = db.Laureado.Include("PremioNobel").Where(p => p.LaureadoId == id).ToList();
            //laureadoIndividuo.PremioNobel.ToList();
            if (laureadoIndividuo.Filiacao != null)
            {
                List<FiliacaoDTO> Filiacoes = laureadoIndividuo.Filiacao.ToList();
            }

            //var FiliacoesAux = (from f in db.LaureadoIndividuo
            //                                  where f.LaureadoId == id
            //                                  select f.Filiacao).ToList();


            int index = 0;
            foreach (var item in Premios)
            {
                foreach (var newitem in item.PremioNobel)
                {
                    PremioNobelDTO premio = new PremioNobelDTO();
                    premio.Ano = newitem.Ano;
                    premio.Categoria = new CategoriaDTO();
                    premio.Categoria.CategoriaID = newitem.Categoria.CategoriaId;
                    premio.Categoria.Nome = newitem.Categoria.Nome;
                    premio.Motivacao = newitem.Motivacao;
                    premio.PremioNobelId = newitem.PremioNobelId;
                    premio.Titulo = newitem.Titulo;
                    if (index == 0)
                    {
                        //--- "https://www.nobelprize.org/nobel_prizes/medicine/laureates/1949/moniz_postcard.jpg"
                        laureadoIndividuo.Picture = "https://www.nobelprize.org/nobel_prizes/" + newitem.Categoria.Nome.ToLower() + "/laureates/" + newitem.Ano + "/" + getLastNameOf(laureadoIndividuo.Nome) + "_postcard.jpg";
                        laureadoIndividuo.Thumbnail = "https://www.nobelprize.org/nobel_prizes/" + newitem.Categoria.Nome.ToLower() + "/laureates/" + newitem.Ano + "/" + getLastNameOf(laureadoIndividuo.Nome) + "_thumb.jpg";
                    }

                    if (laureadoIndividuo.PremioNobel == null)
                        laureadoIndividuo.PremioNobel = new List<PremioNobelDTO>();

                    laureadoIndividuo.PremioNobel.Add(premio);
                    index++;
                }
            }

            return Ok(laureadoIndividuo);
        }

        private string getLastNameOf(string name)
        {
            string[] names = name.Split(' ');
            return names.Last().ToLower();
        }




        //// PUT: api/LaureadoIndividuos/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutLaureadoIndividuo(int id, LaureadoIndividuo laureadoIndividuo)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != laureadoIndividuo.LaureadoId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(laureadoIndividuo).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!LaureadoIndividuoExists(id))
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

        //// POST: api/LaureadoIndividuos
        //[ResponseType(typeof(LaureadoIndividuo))]
        //public IHttpActionResult PostLaureadoIndividuo(LaureadoIndividuo laureadoIndividuo)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.LaureadoIndividuo.Add(laureadoIndividuo);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (LaureadoIndividuoExists(laureadoIndividuo.LaureadoId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = laureadoIndividuo.LaureadoId }, laureadoIndividuo);
        //}

        // DELETE: api/LaureadoIndividuos/5
        [ResponseType(typeof(LaureadoIndividuo))]
        //public IHttpActionResult DeleteLaureadoIndividuo(int id)
        //{
        //    LaureadoIndividuo laureadoIndividuo = db.LaureadoIndividuo.Find(id);
        //    if (laureadoIndividuo == null)
        //    {
        //        return NotFound();
        //    }

        //    db.LaureadoIndividuo.Remove(laureadoIndividuo);
        //    db.SaveChanges();

        //    return Ok(laureadoIndividuo);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LaureadoIndividuoExists(int id)
        {
            return db.LaureadoIndividuo.Count(e => e.LaureadoId == id) > 0;
        }
    }
}