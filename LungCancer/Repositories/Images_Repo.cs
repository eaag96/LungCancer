using LungCancer.Interfaces;
using LungCancer.Models.DB;
using LungCancer.Models.DbContextDir;

namespace LungCancer.Repositories
{
    public class Images_Repo : LungsInterface<Image>
    {
        private readonly LungCancerContext db;

        public Images_Repo(LungCancerContext db)
        {
            this.db = db;
        }
        public void Add(Image entity)
        {
            db.Images.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Image Find(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Image> List()
        {
            return db.Images.ToList();
        }

        public void Update(int id, Image entity)
        {
            throw new NotImplementedException();
        }
    }
}
