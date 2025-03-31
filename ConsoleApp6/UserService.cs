using ConsoleApp6.DAL;

namespace ConsoleApp6
{
    public class UserService
    {
        private readonly UsersRepository _userRepos;
        public UserService()
        {
            _userRepos = new UsersRepository();
        }

        public void Add(User student)
        {
             _userRepos.Add(student);
        }

        public void AddRange(List<User> students)
        {
            _userRepos.AddRange(students);
        }

        public void Update(User student)
        {
            _userRepos.Update(student);
        }

        public void Delete(User student)
        {
            _userRepos.Delete(student);
        }

        public User GetById(int id)
        {
            var res = _userRepos.GetById(id);
            if (res == null)
            {
                return _userRepos.GetAll().FirstOrDefault();
            }
            return res;
        }

        public User GetByName(string name)
        {
            return _userRepos.GetByName(name);
        }

        public List<User> GetAll()
        {
            return _userRepos.GetAll();
        }

        public List<User> OrderByName()
        {
            return GetAll().OrderBy(x => x.Name).ToList();
        }
    }
}
