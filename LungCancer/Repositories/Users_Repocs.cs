using LungCancer.Interfaces;
using LungCancer.Models.DB;
using LungCancer.Models.DbContextDir;

namespace LungCancer.Repositories
{
    public class Users_Repo : LungsInterface<User>
    {
        private readonly LungCancerContext db;

        public Users_Repo(LungCancerContext db )
        {
            this.db = db;
        }
        public void Add(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
        }
        public bool CreateUser(User entity)
        {
            var user = db.Users.FirstOrDefault(x => x.UserEmail==entity.UserEmail);
            if (user == null)
            {
                db.Users.Add(entity);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public User UserLogin(String email, String pass)
        {
            var user = db.Users.SingleOrDefault(u => u.UserEmail == email && u.UserPassword == pass);
            if(user == null)
            {
                return null;
            }
            else
            {
                return user;
            }
        }
       
        public void Delete(int id)
        {
            var singleUser = Find(id);
            if(singleUser != null)
            {
                db.Users.Remove(singleUser);
                db.SaveChanges();

            }
        }

        public User Find(int id)
        {
            return db.Users.Find(id);
        }

        public IList<User> List()
        {
            return db.Users.ToList();   
        }

        public void Update(int id, User entity)
        {
            throw new NotImplementedException();
        }
    }
}
