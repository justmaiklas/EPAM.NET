using System;
using System.Data;
using System.Linq;
using Task3.DoNotChange;

namespace Task3
{
    public class UserTaskService : IUserTaskService
    {
        private readonly IUserDao _userDao;

        public UserTaskService(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public void AddTaskForUser(int userId, UserTask task)
        {
            if (userId < 0)
                throw new ArgumentOutOfRangeException("User id must be greater than zero");

            var user = _userDao.GetUser(userId);
            if (user == null)
                throw new ArgumentNullException("User not found");

            var tasks = user.Tasks;
            if (tasks.Any(t => string.Equals(task.Description, t.Description, StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception("Task already exists");
            }

            tasks.Add(task);
        }
    }
}