namespace TodoTasksServer.Models
{
    public class TaskModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public bool isDone { get; set; }

        public TaskModel(string title, string description)
        {
            if (string.IsNullOrWhiteSpace(title) || title.Length > 50) throw new Exception("Title length is should less than 50 characters.");
            if (Description != null && Description.Length > 1000) throw new Exception("Maximun descriptixn is 1000 characters. ");
            Description = description;
            Title = title;
        }
    }
}
