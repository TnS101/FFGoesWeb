namespace Common
{
    public class GConst
    {
        //Areas
        public const string AdminRole = "Administrator";
        public const string UserRole = "User";
        public const string AdminArea = "Administrator";
        public string UserArea = "User";

        public const string RegistrationSuccessful = "Almost there, {0}! Hopping to the login page.";

        //Redirects
        public const string CommentCommandRedirect = "/Forum/Home/CurrentTopic/id={0}";
        public const string FriendCommandRedirect = "/Message/All/id={0}";
        public const string TopicCommandRedirect = "/Topic/PersonalTopics";
        public const string CreateTopicErrorRedirect = @"\Create";
        public const string CreateMessageCommandRedirect = "/Profile/Friends";
        public const string MessageCommandRedirect = "/Profile/Wall";

        //Errors
        public const string NullCommentError = "User {0} left a blank comment.";
        public const string ConfirmPasswordError = "Passwords must match.";
        public const string LengthException = "{0} length must be between {1} and {2} characters.";
        public const string IdentityInUse = "{0} is in use, please choose another {0}.";
        public const string RequiredField = "This Field is required";
        public const string UsernameError = "Username must contain only letters or digits and must be at least 5 characters long.";
        public const string PasswordError = "Password must contain only letters or digts, at least one uppercase letter, one digit, one non alphanumeric character and must be at least 8 characters long.";
        public const string EmailError = "Invalid Email Address.";


        //Routes
        public const string HomeRoute = "/Home";
    }
}
