using System;
using System.Data;
using Task3.DoNotChange;

namespace Task3
{
    public class UserTaskController
    {
        private readonly IUserTaskService _taskService;

        public UserTaskController(IUserTaskService taskService)
        {
            _taskService = taskService;
        }

        public bool AddTaskForUser(int userId, string description, IResponseModel model)
        {
            var message = GetMessageForModel(userId, description);
            if (message == null) return true;
            model.AddAttribute("action_result", message);
            return false;

        }

        private string GetMessageForModel(int userId, string description)
        {

            try
            {
                var task = new UserTask(description);
                _taskService.AddTaskForUser(userId, task);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return "Invalid userId";

            }
            catch (ArgumentNullException ex)
            {
                return "User not found";

            }
            catch (Exception ex)
            {
                return "The task already exists";

            }

            return null;
        }
    }
}