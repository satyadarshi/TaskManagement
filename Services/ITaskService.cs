using TaskManagementBlazor.Models;

namespace TaskManagementBlazor.Services
{
    public interface ITaskService
    {
        List<TaskViewModel> GetTasks();
        Task<bool> AddTask(CreateTaskDetailCommand task);
        Task<bool> UpdateTask(UpdateTaskDetailCommand task);
        Task<bool> DeleteTask(int taskId);
        bool MarkTaskAsCompleted(int taskId);
        Task<bool> AddActivity(GetActivityListViewModel activity);
    }
}
