namespace TaskManagementBlazor.Models
{
    public class UpdateTaskDetailCommand
    {
        public UpdateTaskDetail UpdateDetails { get; set; }
       
    }

    public class UpdateTaskDetail
    {
        public int Id { get; set; }
        public string task_name { get; set; }
        public List<string> tags { get; set; }
        public DateTime? due_date { get; set; }
        public string color { get; set; }
        public string assigned_to { get; set; }
        public string status { get; set; }
    }
}
