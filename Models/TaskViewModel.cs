namespace TaskManagementBlazor.Models
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public List<GetTagListViewModel> Tags { get; set; }
        public DateTime DueDate { get; set; }
        public string Color { get; set; }
        public string AssignedTo { get; set; }
        public string Status { get; set; } = "PENDING";

        public List<GetActivityListViewModel> Activities { get; set; }
        public string TagName { get; set; }
    }
}
