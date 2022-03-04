using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VrpAPI.DTOs;
using VrpAPI.Models;

namespace VrpAPI.Controllers
{
    public class TyperelationvrpController : ApiController
    {
        // GET ALL TYPE_RELATION_VRP
        public IHttpActionResult GetTyprelavrp()
        {
            IList<TypreletsVM> typerelvrp = null;

            using (var ctx = new IBISVRPEntities())
            {
                typerelvrp = ctx.TYPE_RELATION_VRP.Include("VRP_RELATION_ETS")

                            .Select(t => new TypreletsVM()
                            {
                                CODE_TYPE_RELATION = t.CODE_TYPE_RELATION,
                                UserId = t.UserId,
                                LIBELLE_RELATION = t.LIBELLE_RELATION,
                                DATE_CREATION = t.DATE_CREATION,
                                DATE_MODIF = t.DATE_MODIF

                            }).ToList<TypreletsVM>();
            }
            if (typerelvrp.Count == 0)
            {
                return NotFound();
            }
            return Ok(typerelvrp);
        }

        public IHttpActionResult GetTyprelavrpDetail(string id)
        {
            //    IList<TypreletsVM> typerelvrp = null;
            //    identifiant unique

            TypreletsVM typerelation = null;

            using (var ctx = new IBISVRPEntities())
            {
                typerelation = ctx.TYPE_RELATION_VRP
                    .Where(s => s.CODE_TYPE_RELATION == id)
                    .Select(s => new TypreletsVM()
                    {
                        CODE_TYPE_RELATION = s.CODE_TYPE_RELATION,
                        UserId = s.UserId,
                        LIBELLE_RELATION = s.LIBELLE_RELATION,
                        DATE_CREATION = s.DATE_CREATION,
                        DATE_MODIF = s.DATE_MODIF
                    }).FirstOrDefault<TypreletsVM>();
            }

            if (typerelation == null)
            {
                return NotFound();
            }

            return Ok(typerelation);
        }

        // POST TYPE_RELATION_VRP
        public IHttpActionResult PostNewTyprelvpr(TypreletsVM typerelationets)
        {
            if (!ModelState.IsValid)
                return BadRequest("Données invalides.");

            using (var ctx = new IBISVRPEntities())
            {
                ctx.TYPE_RELATION_VRP.Add(new TYPE_RELATION_VRP()
                {
                    CODE_TYPE_RELATION = typerelationets.CODE_TYPE_RELATION,
                    UserId = typerelationets.UserId,
                    LIBELLE_RELATION = typerelationets.LIBELLE_RELATION,
                    DATE_CREATION = typerelationets.DATE_CREATION
                });

                ctx.SaveChanges();
            }

            return Ok();
        }

        // PUT TYPE_RELATION_VRP
        public IHttpActionResult Put(TypreletsVM typerelationets)
        {
            if (!ModelState.IsValid)
                return BadRequest("Le model n'est pas valide");

            using (var ctx = new IBISVRPEntities())
            {
                var existTyprelvrp = ctx.TYPE_RELATION_VRP.Where(s => s.CODE_TYPE_RELATION == typerelationets.CODE_TYPE_RELATION)
                                                        .FirstOrDefault<TYPE_RELATION_VRP>();

                if (existTyprelvrp != null)
                {
                    existTyprelvrp.LIBELLE_RELATION = typerelationets.LIBELLE_RELATION;
                    existTyprelvrp.DATE_MODIF = typerelationets.DATE_MODIF;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }

        // DELETE api / values
        public IHttpActionResult Delete(string CODE_TYPE_RELATION)
        {
            if (CODE_TYPE_RELATION == null)
                return BadRequest("L'identifiant n'est pas valide");

            using (var ctx = new IBISVRPEntities())
            {
                var dTyprelvrp = ctx.TYPE_RELATION_VRP
                    .Where(s => s.CODE_TYPE_RELATION == CODE_TYPE_RELATION)
                    .FirstOrDefault();

                ctx.Entry(dTyprelvrp).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }

            return Ok();
        }

    }
}
