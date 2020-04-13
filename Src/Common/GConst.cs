namespace Common
{
    public class GConst
    {
        // Areas and Roles
        public const string AdminRole = "Administrator";
        public const string UserRole = "User";
        public const string AdminArea = "Administrator";
        public const string UserArea = "Identity";
        public const string ModeratorRole = "Mod";
        public const string ModeratorArea = "Moderator";

        //CRUD
        public const string CreateOperationName = "Create";
        public const string ReadOperationName = "Read";
        public const string UpdateOperationName = "Update";
        public const string DeleteOperationName = "Delete";
        public const string ApproveOperationName = "Approve";
        public const string RejectOperationName = "Reject";

        //Application Sections
        public const string Forum = "Forum";
        public const string Game = "Game";

        public const string RegistrationSuccessful = "Almost there, {0}! Hopping to the login page.";

        // Redirects
        public const string CommentCommandRedirect = "/Forum/CurrentTopic/id?id={0}";
        public const string FriendCommandRedirect = "/Friends/All/";
        public const string TopicCommandRedirect = "/Forum/Home";
        public const string CreateTopicErrorRedirect = @"\Create";
        public const string CreateMessageCommandRedirect = "/Profile/Friends";
        public const string MessageCommandRedirect = "/Profile/Chats";
        public const string HomeRedirect = "/";
        public const string FeedbackRedirect = "/Admin/Feedbacks";
        public const string SendFeedbackRedirect = "Profile/Feedbacks";
        public const string OpenCommentTicketRedirect = "/Forum/CurrentTopic{0}";
        public const string OpenMessageTicketRedirect = "Profile/Friends/Chat{0}";
        public const string TicketCommandRedirect = "/Moderator/Tickets";
        public const string ToDoListRedirect = "/Admin/ToDoList";
        public const string UnitCommandRedirect = "/Unit/All";
        public const string WorldRedirect = "/World/Home";
        public const string ProfileRedirect = "/Profile/Panel";
        public const string AdminItemCommandRedirect = "/Items/id?id={0}";
        public const string NotEnoughEnergyRedirect = "/EnergyError";
        public const string TreasureEncounterRedirect = "/TreasureEncounter";
        public const string EnemyEncounterRedirect = "EnemyEncounter";
        public const string UnitCreationErrorRedirect = "/Unit/Create";
        public const string SuccesfulFeedbackRedirect = @"\FeedbackSuccess";
        public const string ErrorRedirect = "Error";

        // Errors
        public const string NullCommentError = "User {0} left a blank comment.";
        public const string ConfirmPasswordError = "Passwords must match.";
        public const string LengthException = "{0} length must be between {1} and {2} characters.";
        public const string IdentityInUse = "{0} is in use, please choose another {0}.";
        public const string RequiredField = "This Field is required";
        public const string UsernameError = "Username must contain only letters or digits and must be at least 5 characters long.";
        public const string PasswordError = "Password must contain only letters or digts, at least one uppercase letter, one digit, one non alphanumeric character and must be at least 8 characters long.";
        public const string EmailError = "Invalid Email Address.";
        public const string AllowedUnitsError = "You already have {0} Heroes! Delete a Hero or purchase more Hero Slots.";

        //Notification types
        public const string WarningType = "Warning";
        public const string PenaltyType = "Penalty";
        public const string RewardType = "Reward";

        // Routes
        public const string HomeRoute = "/Home";

        // Feedback
        public const string SendFeedback = "Thank you, {0} for your feedback! If your feedback is marked as useful, you will recieve a reward!" +
                                            "You can track your feedbacks in your Profile Panel.";
        public const string AcceptedFeedback = "Brilliant idea, {0}! Your feedback was accepted! You have been rewarded {1} Support Stars!";

        // Messages
        public const string WarningMessage = "{0}, you have reached {1} warnings! Recieving another warning will be a resulting a penalty!";
        public const string PenaltyMessage = "{0}, you have been muted for {1} day(s)!";

        // Moderation(tickets)
        public const string RemovedContentMessage = "This {0} was removed by violating our rules (Reason : {1}).";
        public const string ClosedTicket = "Thanks to you, {0} we are one step further of making our community perfectly clean! You have been rewarded {1} Support Stars!";

        //Ticket Types
        public const string CommentType = "Comment";
        public const string TopicType = "Topic";
        public const string MessageType = "Message";

        //Sample entity
        public const string SampleEntityDescription = "Sample {0}. This {0} does not reffer to any actual content!";

        // Battle Commands
        public const string EscapeCommand = @"\Escape";
        public const string BattleCommand = @"\Command";
        public const string LevelUp = @"Unit\LevelUp";
        public const string End = @"\End";
        public const string UnitKilled = @"\Unit/Killed";
    }
}
