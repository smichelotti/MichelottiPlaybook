using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MichelottiPlaybook.Models
{
    public class UserRepository : IUserRepository
    {
        private const string partitionKey = "MichelottiPlaybook";
        private PlaybookTableContext context = ContextFactory.CreateContext();

        public User GetUserByUserId(string userId)
        {
            var user = this.context.Users.Where(x => x.PartitionKey == partitionKey && x.UserId == userId).FirstOrDefault();
            return user;
        }

        public List<User> GetAllUsers()
        {
            return this.context.Users.Where(x => x.PartitionKey == partitionKey).ToList().OrderBy(x => x.Name).ToList();
        }

        public User InsertUser(User user)
        {
            user.RowKey = Guid.NewGuid().ToString();
            user.PartitionKey = partitionKey;
            user.Timestamp = DateTime.Now;
            
            this.context.AddObject("Users", user);
            this.context.SaveChangesWithRetries();
            return user;
        }

        public UserActivity InsertUserActivity(UserActivity userActivity)
        {
            userActivity.RowKey = Guid.NewGuid().ToString();
            userActivity.PartitionKey = partitionKey;
            userActivity.Timestamp = DateTime.Now;

            this.context.AddObject("UserActivities", userActivity);
            this.context.SaveChangesWithRetries();
            return userActivity;
        }

        public User SetUserApproval(string userId, bool isApproved)
        {
            var user = this.GetUserByUserId(userId);
            user.IsApproved = isApproved;
            this.context.UpdateObject(user);
            this.context.SaveChangesWithRetries();
            return user;
        }
    }

    public interface IUserRepository
    {
        User GetUserByUserId(string userName);
        List<User> GetAllUsers();
        User InsertUser(User user);
        User SetUserApproval(string userId, bool isApproved);
        UserActivity InsertUserActivity(UserActivity userActivity);
    }
}