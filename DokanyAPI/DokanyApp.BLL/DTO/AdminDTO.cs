namespace DokanyApp.BLL
{
    public class AdminDTO
    {
        public int AdminId { get; set; }
        public string UserName { get; set; } // Be Careful of NullPointerException
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string AdminStatus { get; set; }

        public UserType UserType
        {
            get { return UserType; }
            set { UserType = UserType.Admin; }
        }
    }
}
