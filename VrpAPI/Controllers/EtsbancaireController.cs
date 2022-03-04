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
    public class EtsbancaireController : ApiController
    {
        // GET ALL ETS_BANCAIRE
        public IHttpActionResult GetAllEtsbancaire() 
        {
            IList<EtsbancaireVM> etsbancaires = null;

            using (var ctx = new IBISVRPEntities())
            {
                etsbancaires = ctx.ETS_BANCAIRE.Include("ORGAN_ETS_BANCAIRE")
                    .Select(s => new EtsbancaireVM()
                    {
                        BANQUE_CODE_BCEAO = s.BANQUE_CODE_BCEAO,
                        PAYS_CODE = s.PAYS_CODE,
                        UserId = s.UserId,
                        BANQUE_NOM = s.BANQUE_NOM,
                        BANQUE_SIGLE = s.BANQUE_SIGLE,
                        BANQUE_DATE_SUSP = s.BANQUE_DATE_SUSP,
                        BANQUE_CLE_BCEAO = s.BANQUE_CLE_BCEAO,
                        BANQUE_CODE_REMET = s.BANQUE_CODE_REMET,
                        CODE_FORMULE = s.CODE_FORMULE,
                        BANQUE_SDEVMT = s.BANQUE_SDEVMT,
                        BANQUE_B_F = s.BANQUE_B_F,
                        ETCIV_MATRICULE = s.ETCIV_MATRICULE,
                        DATE_CREATION = s.DATE_CREATION,
                        DATE_MODIF = s.DATE_MODIF
                    }).ToList<EtsbancaireVM>();
            }
            if (etsbancaires.Count == 0)
            {
                return NotFound();
            }
            return Ok(etsbancaires);
        }

        // GET DETAILS
        public IHttpActionResult GetEtsbancaireDetail(string id) 
        {
            EtsbancaireVM etsbancaires = null;
            using (var ctx = new IBISVRPEntities()) 
            {
                etsbancaires = ctx.ETS_BANCAIRE.Include("ORGAN_ETS_BANCAIRE")
                           .Where(e => e.BANQUE_CODE_BCEAO == id)
                           .Select(s => new EtsbancaireVM() 
                           {
                               BANQUE_CODE_BCEAO = s.BANQUE_CODE_BCEAO,
                               PAYS_CODE = s.PAYS_CODE,
                               UserId = s.UserId,
                               BANQUE_NOM = s.BANQUE_NOM,
                               BANQUE_SIGLE = s.BANQUE_SIGLE,
                               BANQUE_DATE_SUSP = s.BANQUE_DATE_SUSP,
                               BANQUE_CLE_BCEAO = s.BANQUE_CLE_BCEAO,
                               BANQUE_CODE_REMET = s.BANQUE_CODE_REMET,
                               CODE_FORMULE = s.CODE_FORMULE,
                               BANQUE_SDEVMT = s.BANQUE_SDEVMT,
                               BANQUE_B_F = s.BANQUE_B_F,
                               ETCIV_MATRICULE = s.ETCIV_MATRICULE,
                               DATE_CREATION = s.DATE_CREATION,
                               DATE_MODIF = s.DATE_MODIF

                           }).FirstOrDefault<EtsbancaireVM>();
            }
            if (etsbancaires == null)
            {
                return NotFound();
            }
            return Ok(etsbancaires);
        }

        public IHttpActionResult GetBankByCountry(string payscode) 
        {
            //Ici LsBanqParPays est une procédure stockée
            IBISVRPEntities ctx = new IBISVRPEntities();
            IList<BankByCountPS> jt = ctx.LsBanqParPays(payscode).Select(x => new BankByCountPS()
            {
                Pays_code = x.PAYS_CODE,
                Pays_nom = x.PAYS_NOM,
                Banque_code_bceao = x.BANQUE_CODE_BCEAO,
                Banque_nom = x.BANQUE_NOM,
                Banque_sigle = x.BANQUE_SIGLE

            }).ToList();

            return Ok(jt);
        }

        // POST ETS_BANCAIRE
        public IHttpActionResult PostNewEtsbancaire(EtsbancaireVM etsbancaire) 
        {
            if (!ModelState.IsValid)
                return BadRequest("Données invalides.");

            using (var ctx = new IBISVRPEntities())
            {
                ctx.ETS_BANCAIRE.Add(new ETS_BANCAIRE()
                {
                    BANQUE_CODE_BCEAO = etsbancaire.BANQUE_CODE_BCEAO,
                    PAYS_CODE = etsbancaire.PAYS_CODE,
                    UserId = etsbancaire.UserId,
                    BANQUE_NOM = etsbancaire.BANQUE_NOM,
                    BANQUE_SIGLE = etsbancaire.BANQUE_SIGLE,
                    BANQUE_DATE_SUSP = etsbancaire.BANQUE_DATE_SUSP,
                    BANQUE_CLE_BCEAO = etsbancaire.BANQUE_CLE_BCEAO,
                    BANQUE_CODE_REMET = etsbancaire.BANQUE_CODE_REMET,
                    CODE_FORMULE = etsbancaire.CODE_FORMULE,
                    BANQUE_SDEVMT = etsbancaire.BANQUE_SDEVMT,
                    BANQUE_B_F = etsbancaire.BANQUE_B_F,
                    ETCIV_MATRICULE = etsbancaire.ETCIV_MATRICULE,
                    DATE_CREATION = etsbancaire.DATE_CREATION
                    //DATE_MODIF = etsbancaire.DATE_MODIF

                });

                ctx.SaveChanges();
            }
            return Ok();
        }

        // PUT ETS_BANCAIRE
        public IHttpActionResult Put(EtsbancaireVM etsbancaire) 
        {
            if (!ModelState.IsValid)
                return BadRequest("Le model n'est pas valide");

            using (var ctx = new IBISVRPEntities()) 
            {
                var existEtsbancaire = ctx.ETS_BANCAIRE.Where(s => s.BANQUE_CODE_BCEAO == etsbancaire.BANQUE_CODE_BCEAO)
                                                        .FirstOrDefault<ETS_BANCAIRE>();

                if (existEtsbancaire != null) 
                {
                    //existEtsbancaire.UserID = etsbancaire.UserID;
                    existEtsbancaire.BANQUE_NOM = etsbancaire.BANQUE_NOM;
                    existEtsbancaire.BANQUE_SIGLE = etsbancaire.BANQUE_SIGLE;
                    existEtsbancaire.BANQUE_DATE_SUSP = etsbancaire.BANQUE_DATE_SUSP;
                    existEtsbancaire.BANQUE_CLE_BCEAO = etsbancaire.BANQUE_CLE_BCEAO;
                    existEtsbancaire.BANQUE_CODE_REMET = etsbancaire.BANQUE_CODE_REMET;
                    existEtsbancaire.CODE_FORMULE = etsbancaire.CODE_FORMULE;
                    existEtsbancaire.BANQUE_SDEVMT = etsbancaire.BANQUE_SDEVMT;
                    existEtsbancaire.BANQUE_B_F = etsbancaire.BANQUE_B_F;
                    existEtsbancaire.ETCIV_MATRICULE = etsbancaire.ETCIV_MATRICULE;
                    //existEtsbancaire.DATE_CREATION = etsbancaire.DATE_CREATION;
                    existEtsbancaire.DATE_MODIF = etsbancaire.DATE_MODIF;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }

        public IHttpActionResult Delete(string BANQUE_CODE_BCEAO) 
        {
            if (BANQUE_CODE_BCEAO == null)
                return BadRequest("L'identifiant n'est pas valide");

            using (var ctx = new IBISVRPEntities()) 
            {
                //string compareID = BANQUE_CODE_BCEAO.ToString();
                var dEtsbancaire = ctx.ETS_BANCAIRE
                    .Where(s => s.BANQUE_CODE_BCEAO == BANQUE_CODE_BCEAO)
                    .FirstOrDefault();

                ctx.Entry(dEtsbancaire).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }


    }
}
