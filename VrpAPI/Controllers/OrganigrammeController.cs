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
    public class OrganigrammeController : ApiController
    {
        // GET ALL ORGANIGRAMME
        public IHttpActionResult GetAllOganigramme()
        {
            IList<OrganigramVM> organigrammes = null;

            using (var ctx = new IBISVRPEntities())
            {
                organigrammes = ctx.ORGANIGRAMMEs.Include("ORGAN_ETS_BANCAIRE")

                            .Select(o => new OrganigramVM()
                            {
                                CODE_ORG = o.CODE_ORG,
                                LIBELLE = o.LIBELLE,
                                NIVEAU = o.NIVEAU,
                                HIERARCHIE = o.HIERARCHIE

                            }).ToList<OrganigramVM>();
            }
            if (organigrammes.Count == 0)
            {
                return NotFound();
            }
            return Ok(organigrammes);
        }

        // GET DETAILS
        public IHttpActionResult GetAllOgangramWithETSBanc(string id)
        {
            OrganigramVM organigrammes = null;

            using (var ctx = new IBISVRPEntities())
            {
                organigrammes = ctx.ORGANIGRAMMEs.Include("ORGAN_ETS_BANCAIRE").Where(o => o.CODE_ORG == id)
                .Select(s => new OrganigramVM()
                {
                    CODE_ORG = s.CODE_ORG,
                    LIBELLE = s.LIBELLE,
                    NIVEAU = s.NIVEAU,
                    HIERARCHIE = s.HIERARCHIE,

                }).FirstOrDefault<OrganigramVM>();
            }

            if (organigrammes == null)
            {
                return NotFound();
            }

            return Ok(organigrammes);
        }

        // POST ORGANIGRAMME
        public IHttpActionResult PostNewOrganigramme(OrganigramVM organigramme)
        {
            if (!ModelState.IsValid)
                return BadRequest("Données invalides.");

            using (var ctx = new IBISVRPEntities())
            {
                ctx.ORGANIGRAMMEs.Add(new ORGANIGRAMME()
                {
                    CODE_ORG = organigramme.CODE_ORG,
                    LIBELLE = organigramme.LIBELLE,
                    NIVEAU = organigramme.NIVEAU,
                    HIERARCHIE = organigramme.HIERARCHIE
                });

                ctx.SaveChanges();
            }

            return Ok();
        }

        // PUT ORGANIGRAMME
        public IHttpActionResult Put(OrganigramVM organigramme)
        {
            if (!ModelState.IsValid)
                return BadRequest("Le model n'est pas valide");

            using (var ctx = new IBISVRPEntities())
            {
                var existingOrganigramme = ctx.ORGANIGRAMMEs.Where(s => s.CODE_ORG == organigramme.CODE_ORG)
                                                        .FirstOrDefault<ORGANIGRAMME>();

                if (existingOrganigramme != null)
                {
                    existingOrganigramme.LIBELLE = organigramme.LIBELLE;
                    existingOrganigramme.NIVEAU = organigramme.NIVEAU;
                    existingOrganigramme.HIERARCHIE = organigramme.HIERARCHIE;

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
        public IHttpActionResult Delete(string CODE_ORG)
        {
            if (CODE_ORG == null)
                return BadRequest("L'identifiant n'est pas valide");

            using (var ctx = new IBISVRPEntities())
            {
                var dOrganigramme = ctx.ORGANIGRAMMEs
                    .Where(s => s.CODE_ORG == CODE_ORG)
                    .FirstOrDefault();

                ctx.Entry(dOrganigramme).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }

            return Ok();
        }

    }
}
