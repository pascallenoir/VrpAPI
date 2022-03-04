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
    public class BanquevrpController : ApiController
    {
        // GET ALL BANQUE_VRP
        public IHttpActionResult GetAllBanquevrp() 
        {
            IList<BanquevrpVM> banquevrps = null;
            using (var ctx = new IBISVRPEntities()) 
            {
                banquevrps = ctx.BANQUE_VRP/*.Include("VRP_RELATION_ETS")*/
                           .Select(o => new BanquevrpVM() 
                           {
                               CODE_VRP = o.CODE_VRP,
                               UserId = o.UserId,
                               NOM_VRP = o.NOM_VRP,
                               PRENOM_VRP = o.PRENOM_VRP,
                               E_MAIL_VRP = o.E_MAIL_VRP,
                               TEL1_VRP = o.TEL1_VRP,
                               TEL2_VRP = o.TEL2_VRP,
                               ADR1_VRP = o.ADR1_VRP,
                               ADR2_VRP = o.ADR2_VRP,
                               DATE_CREATION = o.DATE_CREATION,
                               DATE_MODIF = o.DATE_MODIF
                           }).ToList<BanquevrpVM>();
            }
            if (banquevrps.Count == 0)
            {
                return NotFound();
            }
            return Ok(banquevrps);
        }

        // GET DETAILS
        public IHttpActionResult GetBanquevrpDetail(string id) 
        {
            BanquevrpVM banquevrps = null;
            using (var ctx = new IBISVRPEntities()) 
            {
                banquevrps = ctx.BANQUE_VRP/*.Include("VRP_RELATION_ETS")*/
                            .Where(b => b.CODE_VRP == id)
                            .Select(o => new BanquevrpVM() 
                            {
                                CODE_VRP = o.CODE_VRP,
                                UserId = o.UserId,
                                NOM_VRP = o.NOM_VRP,
                                PRENOM_VRP = o.PRENOM_VRP,
                                E_MAIL_VRP = o.E_MAIL_VRP,
                                TEL1_VRP = o.TEL1_VRP,
                                TEL2_VRP = o.TEL2_VRP,
                                ADR1_VRP = o.ADR1_VRP,
                                ADR2_VRP = o.ADR2_VRP,
                                DATE_CREATION = o.DATE_CREATION,
                                DATE_MODIF = o.DATE_MODIF
                            }).FirstOrDefault<BanquevrpVM>();
            }
            if (banquevrps == null)
            {
                return NotFound();
            }

            return Ok(banquevrps);
        }

        
        public IHttpActionResult Get(string banqueCode, string paysCode) 
        {
            IBISVRPEntities ctx = new IBISVRPEntities();

            IList<LsPaysVrpIntPS> jt = ctx.LsPaysVrpInt(banqueCode, paysCode)
            .Where(b => b.BANQUE_CODE_BCEAO == banqueCode)
            .Select(x => new LsPaysVrpIntPS() 
            {
                CODE_VRP = x.CODE_VRP,
                NOM_VRP = x.NOM_VRP,
                PRENOM_VRP = x.PRENOM_VRP,
                E_MAIL_VRP = x.E_MAIL_VRP,
                TEL1_VRP = x.TEL1_VRP,
                BANQUE_CODE_BCEAO = x.BANQUE_CODE_BCEAO,
                BANQUE_NOM = x.BANQUE_NOM,
                BANQUE_SIGLE = x.BANQUE_SIGLE,
                PAYS_CODE = x.PAYS_CODE,
                PAYS_NOM = x.PAYS_NOM
            }).ToList();
            return Ok(jt);
        }


        // POST BANQUE_VRP

        public IHttpActionResult PostNewBanquevrp(BanquevrpVM bANQUE_VRP) 
        {
            if (!ModelState.IsValid)
                return BadRequest("Données invalides.");

            using (var ctx = new IBISVRPEntities()) 
            {
                ctx.BANQUE_VRP.Add(new BANQUE_VRP()
                {
                    CODE_VRP = bANQUE_VRP.CODE_VRP,
                    UserId = bANQUE_VRP.UserId,
                    NOM_VRP = bANQUE_VRP.NOM_VRP,
                    PRENOM_VRP = bANQUE_VRP.PRENOM_VRP,
                    E_MAIL_VRP = bANQUE_VRP.E_MAIL_VRP,
                    TEL1_VRP = bANQUE_VRP.TEL1_VRP,
                    TEL2_VRP = bANQUE_VRP.TEL2_VRP,
                    ADR1_VRP = bANQUE_VRP.ADR1_VRP,
                    ADR2_VRP = bANQUE_VRP.ADR2_VRP,
                    DATE_CREATION = bANQUE_VRP.DATE_CREATION,
                    //DATE_MODIF = bANQUE_VRP.DATE_MODIF
                });

                ctx.SaveChanges();
            }
            
            return Ok();
        }

        // PUT ETS_BANCAIRE
        public IHttpActionResult Put(BanquevrpVM banquevrp) 
        {
            if (!ModelState.IsValid)
                return BadRequest("Données invalides.");

            using (var ctx = new IBISVRPEntities()) 
            {
                var existBancVrp = ctx.BANQUE_VRP.Where(s => s.CODE_VRP == banquevrp.CODE_VRP)
                                                        .FirstOrDefault<BANQUE_VRP>();

                if (existBancVrp != null) 
                {
                    //existBancVrp.UserID = banquevrp.UserID;
                    existBancVrp.NOM_VRP = banquevrp.NOM_VRP;
                    existBancVrp.PRENOM_VRP = banquevrp.PRENOM_VRP;
                    existBancVrp.E_MAIL_VRP = banquevrp.E_MAIL_VRP;
                    existBancVrp.TEL1_VRP = banquevrp.TEL1_VRP;
                    existBancVrp.TEL2_VRP = banquevrp.TEL2_VRP;
                    existBancVrp.ADR1_VRP = banquevrp.ADR1_VRP;
                    existBancVrp.ADR2_VRP = banquevrp.ADR2_VRP;
                    //existBancVrp.DATE_CREATION = banquevrp.DATE_CREATION;
                    existBancVrp.DATE_MODIF = banquevrp.DATE_MODIF;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }

        // DELETE BANQUE_VRP

        public IHttpActionResult Delete(string CODE_VRP) 
        {
            if (CODE_VRP == null)
                return BadRequest("L'identifiant n'est pas valide");

            using (var ctx = new IBISVRPEntities()) 
            {

                //string compareID = CODE_VRP.ToString();
                var dbancvrp = ctx.BANQUE_VRP
                    .Where(s => s.CODE_VRP == CODE_VRP)
                    .FirstOrDefault();

                ctx.Entry(dbancvrp).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }


    }
}
