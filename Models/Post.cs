namespace PostManagementSystem.Models
{
    public class Post
    {
        public long ID { get; set; }
        public long UserID { get; set; }
        public string urlImage { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }= DateTime.Now;
        public bool IsDeleted { get; set; }=false;
        public User User { get; set; }
    }
}
