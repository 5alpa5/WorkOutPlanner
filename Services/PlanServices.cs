using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IPlanServices
    {
        IEnumerable<Plan> GetPlanByUserId(int id);
        void Update(Plan plan);

    }
    public class PlanServices : IPlanServices
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private readonly WebApiDb db = new WebApiDb();


        public PlanServices()
        {
           
        }

        public IEnumerable<Plan> GetPlanByUserId(int id)
        {
            var plan = db.Plan.Where(x => x.UserId == id).ToList();
            return plan;
        }

        public void Update(Plan planParam)
        {
            var plan = db.Plan.Find(planParam.PlanId);
            if (plan == null)
                throw new AppException("Could not find plan");

            if(!string.IsNullOrWhiteSpace(planParam.PlanName))
            {
                plan.PlanName = planParam.PlanName;
            }

            if (!string.IsNullOrWhiteSpace(planParam.PlanDesc))
            {
                plan.PlanDesc = planParam.PlanDesc;
            }

            try
            {
                db.Plan.Update(plan);
                db.SaveChanges();
               
            }
            catch(Exception evt)
            {
                Console.WriteLine(evt);
            }
        }
    }
}
