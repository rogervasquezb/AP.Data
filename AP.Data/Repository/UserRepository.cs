using AP.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AP.Data.Repository;

public interface IUserRepository
{
    bool AddEntity(User user);
}

public class UserRepository(ApdatadbContext context) : Repository<User>(context), IUserRepository
{
    public bool AddEntity(User user)
    {
        return user == null
            ? throw new ArgumentNullException("User does not exist!") 
            : Add(user);
    }


    public bool DeleteUser(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null)
        {
            return false;
        }

        _context.Users.Remove(user);
        _context.SaveChanges();
        return true;
    }

    public IEnumerable<User> FindUsers(Expression<Func<User, bool>> predicate)
    {
        return _context.Users.Where(predicate).ToList();
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _context.Users.ToList();
    }

    public User GetUserById(int id)
    {
        return _context.Users.Find(id);
    }

    public User UpdateUser(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "User does not exist!");
        }

        _context.Users.Attach(user);
        _context.Entry(user).State = EntityState.Modified;
        _context.SaveChanges();
        return user;
    }
}
