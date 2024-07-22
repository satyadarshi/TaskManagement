namespace TaskManagementBlazor.Models
{
    public class GetActivityListViewModel
    {
        public int Id { get; set; }
        public DateTime? ActivityDate { get; set; }
        public string DoneBy { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
    }
}
