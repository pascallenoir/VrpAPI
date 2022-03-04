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
    public class PaysvrpController : ApiController
    {
        // GET ALL PAYS_NATIONAL
        public IHttpActionResult GetPaysvrp()
        {
            IList<PaysVM> paysvrps = null;

            using (var ctx = new IBISVRPEntities())
            {
                paysvrps = ctx.PAYS_NATIONAL/*.Include("VRP_RELATION_ETS")*/

                            .Select(p => new PaysVM()
                            {
                                PAYS_CODE = p.PAYS_CODE,
                                PAYS_NOM = p.PAYS_NOM

                            }).ToList<PaysVM>();
            }
            if (paysvrps.Count == 0)
            {
                return NotFound();
            }
            return Ok(paysvrps);
        }

        // GET DETAILS
        public IHttpActionResult GetPaysvrpDetail(string id)
        {
            PaysVM paysvrps = null;

            using (var ctx = new IBISVRPEntities())
            {
                paysvrps = ctx.PAYS_NATIONAL/*.Include("VRP_RELATION_ETS")*/
                            .Where(p => p.PAYS_CODE == id)
                            .Select(o => new PaysVM()
                            {
                                PAYS_CODE = o.PAYS_CODE,
                                PAYS_NOM = o.PAYS_NOM

                            }).FirstOrDefault<PaysVM>();
            }
            if (paysvrps == null)
            {
                return NotFound();
            }
            return Ok(paysvrps);
        }


        // POST PAYS_NATIONAL
        public IHttpActionResult PostNewPaysvrp(PAYS_NATIONAL pAYS_NATIONAL)
        {
            if (!ModelState.IsValid)
                return BadRequest("Données invalides.");

            using (var ctx = new IBISVRPEntities())
            {
                ctx.PAYS_NATIONAL.Add(new PAYS_NATIONAL()
                {
                    PAYS_CODE = pAYS_NATIONAL.PAYS_CODE,
                    PAYS_NOM = pAYS_NATIONAL.PAYS_NOM

                });

                ctx.SaveChanges();
            }

            return Ok();
        }

        // PUT api / values
        public IHttpActionResult Put(PaysVM paysvrps)
        {
            if (!ModelState.IsValid)
                return BadRequest("Le model n'est pas valide");

            using (var ctx = new IBISVRPEntities())
            {
                var existingPays = ctx.PAYS_NATIONAL.Where(p => p.PAYS_CODE == paysvrps.PAYS_CODE)
                                                        .FirstOrDefault<PAYS_NATIONAL>();

                if (existingPays != null)
                {
                    existingPays.PAYS_NOM = paysvrps.PAYS_NOM;

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
        public IHttpActionResult Delete(string PAYS_CODE)
        {
            if (PAYS_CODE == null)
                return BadRequest("L'identifiant n'est pas valide");

            using (var ctx = new IBISVRPEntities())
            {

                //string compareID = CODE_VRP.ToString();
                var dpayvrp = ctx.PAYS_NATIONAL
                    .Where(p => p.PAYS_CODE == PAYS_CODE)
                    .FirstOrDefault();

                ctx.Entry(dpayvrp).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }

            return Ok();
        }


    }
}
