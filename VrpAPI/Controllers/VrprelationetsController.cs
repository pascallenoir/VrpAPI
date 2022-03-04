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
    public class VrprelationetsController : ApiController
    {
        // GET VRP_RELATION_ETS
        // GET ALL DETAILS
        public IHttpActionResult GetAllVrprelation()
        {
            //Ici JoinTables est une procédure stockée
            IBISVRPEntities ctx = new IBISVRPEntities();
            IList<JoinTablesPS> jt = ctx.JoinTables().Select(x => new JoinTablesPS()
            {
                Code_vrp = x.CODE_VRP,
                Nom_vrp = x.NOM_VRP,
                Banque_code_vrp = x.BANQUE_CODE_BCEAO,
                Banque_nom = x.BANQUE_NOM

            }).ToList();

            return Ok(jt);
        }

        // GET DETAILS ONE
        public IHttpActionResult GetVrpIntervBank(string codeVrp)
        {
            //Ici VrpintervBank est une procédure stockée
            IBISVRPEntities ctx = new IBISVRPEntities();
            IList<VrpintervBankPS> jt = ctx.VrpintervBank(codeVrp).Select(x => new VrpintervBankPS()
            {
                Code_vrp = x.CODE_VRP,
                Banque_code_bceao = x.BANQUE_CODE_BCEAO,
                Banque_nom = x.BANQUE_NOM

            }).ToList();

            return Ok(jt);
        }

        // GET DETAILS TWO
        public IHttpActionResult GetVrprelationDetail(string codeVrp, string banqueCodeBceao)
        {
            //Ici JoinTables est une procédure stockée
            IBISVRPEntities ctx = new IBISVRPEntities();

            //string comp = id.ToString();
            IList<RelationVrpClass> jt = ctx.RelationVrp(codeVrp, banqueCodeBceao)
            .Where(b => b.CODE_VRP == codeVrp)
            .Where(b => b.BANQUE_CODE_BCEAO == banqueCodeBceao)
            .Select(x => new RelationVrpClass()
            {
                Code_vrp = x.CODE_VRP,
                Nom_vrp = x.NOM_VRP,
                Banque_code_bceao = x.BANQUE_CODE_BCEAO,
                Banque_nom = x.BANQUE_NOM,
                Code_org = x.CODE_ORG,
                Libelle = x.LIBELLE,
                Code_type_relation = x.CODE_TYPE_RELATION,
                Libelle_relation = x.LIBELLE_RELATION,
                Observation_rel = x.OBSERVATION_REL
            }).ToList();

            return Ok(jt);
        }


        // POST VRP_RELATION_ETS
        public IHttpActionResult PostNewVrprelationets(VrprelVM vrprelationets)
        {
            if (!ModelState.IsValid)
                return BadRequest("Données invalides.");

            using (var ctx = new IBISVRPEntities())
            {
                ctx.VRP_RELATION_ETS.Add(new VRP_RELATION_ETS()
                {
                    CODE_VRP = vrprelationets.CODE_VRP,
                    BANQUE_CODE_BCEAO = vrprelationets.BANQUE_CODE_BCEAO,
                    CODE_ORG = vrprelationets.CODE_ORG,
                    CODE_TYPE_RELATION = vrprelationets.CODE_TYPE_RELATION,
                    OBSERVATION_REL = vrprelationets.OBSERVATION_REL
                });

                ctx.SaveChanges();
            }

            return Ok();
        }

        // PUT VRP_RELATION_ETS
        public IHttpActionResult Put(VrprelVM vrprelationets)
        {
            if (!ModelState.IsValid)
                return BadRequest("Le model n'est pas valide");

            using (var ctx = new IBISVRPEntities())
            {
                var existVrelationets = ctx.VRP_RELATION_ETS.Where(s => s.CODE_ORG == vrprelationets.CODE_ORG)
                                                        .FirstOrDefault<VRP_RELATION_ETS>();

                if (existVrelationets != null)
                {
                    existVrelationets.CODE_VRP = vrprelationets.CODE_VRP;
                    existVrelationets.BANQUE_CODE_BCEAO = vrprelationets.BANQUE_CODE_BCEAO;
                    existVrelationets.CODE_ORG = vrprelationets.CODE_ORG;
                    existVrelationets.CODE_TYPE_RELATION = vrprelationets.CODE_TYPE_RELATION;
                    existVrelationets.OBSERVATION_REL = vrprelationets.OBSERVATION_REL;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }

        // DELETE
        public IHttpActionResult Delete(int CODE_VRP, int BANQUE_CODE_BCEAO, int CODE_TYPE_RELATION)
        {
            if (CODE_VRP <= 0 && BANQUE_CODE_BCEAO <= 0 && CODE_TYPE_RELATION <= 0)
                return BadRequest("Les identifiants ne sont pas valide");

            using (var ctx = new IBISVRPEntities())
            {
                string cmprIDa = CODE_VRP.ToString();
                string cmprIDb = BANQUE_CODE_BCEAO.ToString();
                string cmprIDc = CODE_TYPE_RELATION.ToString();

                var dvrprel = ctx.VRP_RELATION_ETS
                    .Where(s => s.CODE_VRP == cmprIDa)
                    .Where(s => s.BANQUE_CODE_BCEAO == cmprIDb)
                    .Where(s => s.CODE_TYPE_RELATION == cmprIDc)
                    .FirstOrDefault();

                ctx.Entry(dvrprel).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }

            return Ok();
        }

    }
}
