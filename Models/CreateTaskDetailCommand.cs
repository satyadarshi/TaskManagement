namespace TaskManagementBlazor.Models
{
    public class CreateTaskModel
    {
        public string task_name { get; set; }
        public List<string> tags { get; set; }
        public DateTime? due_date { get; set; }
        public string color { get; set; }
        public string assigned_to { get; set; }
        public string status { get; set; } = "PENDING";
    }

    public class CreateTaskDetailCommand 
    {
        public List<CreateTaskModel> Details { get; set; }
    }
}
