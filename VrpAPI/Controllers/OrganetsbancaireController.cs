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
    public class OrganetsbancaireController : ApiController
    {
        // GET ALL ORGAN_ETS_BANCAIRE
        public IHttpActionResult GetAllOganetsbancaire()
        {
            IList<OrganetsbancVM> organetsban = null;

            using (var ctx = new IBISVRPEntities())
            {
                organetsban = ctx.ORGAN_ETS_BANCAIRE.Select(o => new OrganetsbancVM()
                {
                    BANQUE_CODE_BCEAO = o.BANQUE_CODE_BCEAO,
                    CODE_ORG = o.CODE_ORG,
                    NOM = o.NOM,
                    PRENOMS = o.PRENOMS,
                    ETCIV_MATRICULE = o.ETCIV_MATRICULE,
                    E_MAIL1 = o.E_MAIL1,
                    E_MAIL2 = o.E_MAIL2,
                    TEL1 = o.TEL1,
                    TEL2 = o.TEL2,
                    ADR_POST1 = o.ADR_POST1,
                    ADR_POST2 = o.ADR_POST2,
                    ADR_GEO1 = o.ADR_GEO1,
                    ADR_GEO2 = o.ADR_GEO2,
                    DATE_CREATION = o.DATE_CREATION,
                    DATE_MODIF = o.DATE_MODIF

                }).ToList<OrganetsbancVM>();

            }
            if (organetsban.Count == 0)
            {
                return NotFound();
            }
            return Ok(organetsban);
        }

        // GET DETAILS
        public IHttpActionResult GetOganetsbancaireDetail(string id)
        {
            OrganetsbancVM organetsban = null;

            using (var ctx = new IBISVRPEntities())
            {
                organetsban = ctx.ORGAN_ETS_BANCAIRE
                .Where(o => o.BANQUE_CODE_BCEAO == id)
                .Select(o => new OrganetsbancVM()
                {
                    BANQUE_CODE_BCEAO = o.BANQUE_CODE_BCEAO,
                    CODE_ORG = o.CODE_ORG,
                    NOM = o.NOM,
                    PRENOMS = o.PRENOMS,
                    ETCIV_MATRICULE = o.ETCIV_MATRICULE,
                    E_MAIL1 = o.E_MAIL1,
                    E_MAIL2 = o.E_MAIL2,
                    TEL1 = o.TEL1,
                    TEL2 = o.TEL2,
                    ADR_POST1 = o.ADR_POST1,
                    ADR_POST2 = o.ADR_POST2,
                    ADR_GEO1 = o.ADR_GEO1,
                    ADR_GEO2 = o.ADR_GEO2,
                    DATE_CREATION = o.DATE_CREATION,
                    DATE_MODIF = o.DATE_MODIF

                }).FirstOrDefault<OrganetsbancVM>();

            }
            if (organetsban == null)
            {
                return NotFound();
            }
            return Ok(organetsban);
        }

        // POST ORGAN_ETS_BANCAIRE
        public IHttpActionResult PostNewOrganetsbanc(OrganetsbancVM organetsban)
        {
            if (!ModelState.IsValid)
                return BadRequest("Données invalides.");

            using (var ctx = new IBISVRPEntities())
            {
                ctx.ORGAN_ETS_BANCAIRE.Add(new ORGAN_ETS_BANCAIRE()
                {
                    BANQUE_CODE_BCEAO = organetsban.BANQUE_CODE_BCEAO,
                    CODE_ORG = organetsban.CODE_ORG,
                    NOM = organetsban.NOM,
                    PRENOMS = organetsban.PRENOMS,
                    ETCIV_MATRICULE = organetsban.ETCIV_MATRICULE,
                    E_MAIL1 = organetsban.E_MAIL1,
                    E_MAIL2 = organetsban.E_MAIL2,
                    TEL1 = organetsban.TEL1,
                    TEL2 = organetsban.TEL2,
                    ADR_POST1 = organetsban.ADR_POST1,
                    ADR_POST2 = organetsban.ADR_POST2,
                    ADR_GEO1 = organetsban.ADR_GEO1,
                    ADR_GEO2 = organetsban.ADR_GEO2,
                    DATE_CREATION = organetsban.DATE_CREATION,
                    //DATE_MODIF = organetsban.DATE_MODIF

                });

                ctx.SaveChanges();
            }

            return Ok();
        }

        // PUT ORGAN_ETS_BANCAIRE
        public IHttpActionResult Put(OrganetsbancVM organetsban)
        {
            if (!ModelState.IsValid)
                return BadRequest("Le model n'est pas valide");

            using (var ctx = new IBISVRPEntities())
            {
                var existOrganetsbanc = ctx.ORGAN_ETS_BANCAIRE.Where(s => s.BANQUE_CODE_BCEAO == organetsban.BANQUE_CODE_BCEAO)
                                                        .FirstOrDefault<ORGAN_ETS_BANCAIRE>();

                if (existOrganetsbanc != null)
                {
                    existOrganetsbanc.NOM = organetsban.NOM;
                    existOrganetsbanc.PRENOMS = organetsban.PRENOMS;
                    existOrganetsbanc.ETCIV_MATRICULE = organetsban.ETCIV_MATRICULE;
                    existOrganetsbanc.E_MAIL1 = organetsban.E_MAIL1;
                    existOrganetsbanc.E_MAIL2 = organetsban.E_MAIL2;
                    existOrganetsbanc.TEL1 = organetsban.TEL1;
                    existOrganetsbanc.TEL2 = organetsban.TEL2;
                    existOrganetsbanc.ADR_POST1 = organetsban.ADR_POST1;
                    existOrganetsbanc.ADR_POST2 = organetsban.ADR_POST2;
                    existOrganetsbanc.ADR_GEO1 = organetsban.ADR_GEO1;
                    existOrganetsbanc.ADR_GEO2 = organetsban.ADR_GEO2;
                    existOrganetsbanc.ADR_GEO2 = organetsban.ADR_GEO2;
                    //existOrganetsbanc.DATE_CREATION = organetsban.DATE_CREATION;
                    existOrganetsbanc.DATE_MODIF = organetsban.DATE_MODIF;

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
        public IHttpActionResult Delete(string BANQUE_CODE_BCEAO)
        {
            if (BANQUE_CODE_BCEAO == null)
                return BadRequest("L'identifiant n'est pas valide");

            using (var ctx = new IBISVRPEntities())
            {
                //string compareID = BANQUE_CODE_BCEAO.ToString();
                var dOrganetsbanc = ctx.ORGAN_ETS_BANCAIRE
                    .Where(s => s.BANQUE_CODE_BCEAO == BANQUE_CODE_BCEAO)
                    .FirstOrDefault();

                ctx.Entry(dOrganetsbanc).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }

            return Ok();
        }

    }
}
