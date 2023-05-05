using LungCancer.Interfaces;
using LungCancer.Models.DB;
using LungCancer.Models.DbContextDir;
using Microsoft.EntityFrameworkCore;

namespace LungCancer.Repositories
{
    public class Prediction_Repo: LungsInterface<Prediction>
    {
        private readonly LungCancerContext db;

        public Prediction_Repo(LungCancerContext db)
        {
            this.db = db;
        }

        public void Add(Prediction entity)
        {
            db.Predictions.Add(entity);
        }

        public void Delete(int id)
        {
            var singlePrediction = Find(id);
            if(singlePrediction != null)
            {
               // db.Prescriptions.Remove(singlePrediction);

            }
        }

        public Prediction Find(int id)
        {
            var singlePrediction=db.Predictions.Find(id);
            return singlePrediction;
        }
        public Prediction FindByUserID(int userId)
        {
            var singlePrediction = db.Predictions.Include(i=>i.User).Include(d=>d.Doctor).Include(p=>p.Prescription).FirstOrDefault(i=>i.UserId==userId);
            return singlePrediction;
        }
        public IList<Prediction> List()
        {
             return db.Predictions.ToList();
        }

        public void Update(int id, Prediction entity)
        {
            throw new NotImplementedException();
        }
    }
}
