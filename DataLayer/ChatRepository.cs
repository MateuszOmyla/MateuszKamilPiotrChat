using DataLayer.Context;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class ChatRepository : IChatRepository
    {
        private readonly ChatDbContext _dbContext;

        public ChatRepository(ChatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetListOfUsers()
        {
            var userList = _dbContext.Users.ToList();
            return userList;
        }

        public User UpdateUserPassword(User user)
        {
            _dbContext.Update(user);
            _dbContext.SaveChanges();

            return user;
        }

        public void Register(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public List<Group> GetListOfGroups()
        {
            var groupList = _dbContext.Groups.ToList();
            return groupList;
        }

        public void AddGroup(Group group)
        {
            _dbContext.Groups.Add(group);
            _dbContext.SaveChanges();
        }

        public void SaveMessage(Message message)
        {
            _dbContext.Messages.Add(message);
            _dbContext.SaveChanges();
        }

        public User GetUserByName(string name)
        {
            User userToReturn = _dbContext.Users.SingleOrDefault(u => u.Username == name);
            return userToReturn;
        }

        public Group GetGroupByName(string name)
        {
            Group groupToReturn = _dbContext.Groups.SingleOrDefault(g => g.GroupName == name);
            return groupToReturn;
        }
    }
}