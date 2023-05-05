using LungCancer.Interfaces;
using LungCancer.Models.DB;
using LungCancer.Models.DbContextDir;

namespace LungCancer.Repositories
{
    public class Prescription_Repo: LungsInterface<Prescription>
    {
        private readonly LungCancerContext db;

        public Prescription_Repo(LungCancerContext db)
        {
            this.db = db;
        }

        public void Add(Prescription entity)
        {
            db.Prescriptions.Add(entity);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Prescription Find(int id)
        {
           var SinglePriscritption=db.Prescriptions.Find(id);
            return SinglePriscritption;
        }

        public IList<Prescription> List()
        {
           return db.Prescriptions.ToList();
        }

        public void Update(int id, Prescription entity)
        {
            throw new NotImplementedException();
        }
    }
}
