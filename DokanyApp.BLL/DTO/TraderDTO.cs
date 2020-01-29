namespace DokanyApp.BLL
{
    public class TraderDTO
    {
        public int TraderId { get; set; }
        public string UserName { get; set; } // Be Careful of NullPointerException
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string TraderStatus { get; set; }

        public UserType UserType
        {
            get { return UserType; }
            set { UserType = UserType.Trader; }
        }

    }
}
