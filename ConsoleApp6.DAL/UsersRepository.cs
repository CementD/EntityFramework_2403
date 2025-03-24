namespace ConsoleApp6.DAL
{
    public class UsersRepository
    {
        private readonly AppDbContext _context;
        public UsersRepository()
        {
            _context = new AppDbContext();
        }

        public void Add(User student)
        {
            _context.Users.Add(student);
            _context.SaveChanges();
        }

        public void AddRange(List<User> students)
        {
            _context.AddRange(students);
            _context.SaveChanges();
        }

        public void Update(User student)
        {
            _context.Users.Update(student);
            _context.SaveChanges();
        }

        public void Delete(User student)
        {
            _context.Users.Remove(student);
            _context.SaveChanges();
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public User GetByName(string name)
        {
            return _context.Users.FirstOrDefault(x => x.Name == name);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}
