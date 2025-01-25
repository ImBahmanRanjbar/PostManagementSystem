namespace PostManagementSystem.Models
{
    public class User
    {
        public long ID { get; set; }
        public string Name   { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime JoinTime { get; set; }= DateTime.Now;
        public bool IsDeleted { get; set; }=false;
        public List<Post> Post { get; set; }=new List<Post>();


    }
}
