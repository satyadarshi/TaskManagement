using TaskManagementBlazor.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TaskManagementBlazor.Services
{
    public class TaskService : ITaskService
    {
        private readonly HttpClient _httpClient;

        public TaskService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<TaskViewModel> GetTasks()
        {
            List<TaskViewModel> lst = new List<TaskViewModel>();
            try
            {
                var result=  _httpClient.GetFromJsonAsync<List<TaskViewModel>>("GetTasks");
                lst = result.Result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return lst;
        }

        public async Task<bool> AddTask(CreateTaskDetailCommand task)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "Create")
            {
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(task), Encoding.UTF8, "application/json")
            };
            // Send the request
            var response = await _httpClient.SendAsync(request);
            return response.IsSuccessStatusCode;
            
        }

        public async Task<bool> UpdateTask(UpdateTaskDetailCommand task)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, "Update")
            {
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(task), Encoding.UTF8, "application/json")
            };
            // Send the request
            var response = await _httpClient.SendAsync(request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteTask(int taskId)
        {
            DeleteTaskDetailCommand deleteTaskCommand = new DeleteTaskDetailCommand { TaskDetailId = taskId };
            var request = new HttpRequestMessage(HttpMethod.Delete, "Delete")
            {
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(deleteTaskCommand), Encoding.UTF8, "application/json")
            };
            // Send the request
            var response = await _httpClient.SendAsync(request);
            return response.IsSuccessStatusCode;
        }

        public bool MarkTaskAsCompleted(int taskId)
        {
            DeleteTaskDetailCommand deleteTaskCommand = new DeleteTaskDetailCommand { TaskDetailId = taskId };
            var request = new HttpRequestMessage(HttpMethod.Post,"CompleteTask")
            {
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(deleteTaskCommand), Encoding.UTF8, "application/json")
            };
            // Send the request
            var response =  _httpClient.SendAsync(request).GetAwaiter().GetResult();
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> AddActivity(GetActivityListViewModel activity)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/tasks/activities", activity);
            return response.IsSuccessStatusCode;
        }
    }
    public class DeleteTaskDetailCommand
    {
        public int TaskDetailId { get; set; }
    }
}
