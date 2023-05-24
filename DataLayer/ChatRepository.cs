﻿using DataLayer.Context;
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
    }
}