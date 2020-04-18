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

        // CRUD
        public const string CreateOperationName = "Create";
        public const string ReadOperationName = "Read";
        public const string UpdateOperationName = "Update";
        public const string DeleteOperationName = "Delete";
        public const string ApproveOperationName = "Approve";
        public const string RejectOperationName = "Reject";

        // Application Sections
        public const string Forum = "Forum";
        public const string Game = "Game";

        public const string RegistrationSuccessful = "Almost there, {0}! Hopping to the login page.";

        // Redirects
        public const string CommentCommandRedirect = "/Forum/CurrentTopic/id?id={0}";
        public const string FriendCommandRedirect = "/Friends/All/";
        public const string TopicCommandRedirect = @"\Forum\Home";
        public const string CreateTopicErrorRedirect = @"\Create";
        public const string CreateMessageCommandRedirect = "/Profile/Friends";
        public const string MessageCommandRedirect = "/Profile/Chats";
        public const string HomeRedirect = "/";
        public const string FeedbackCommandRedirect = "/Administrator/Feedback/Feedbacks";
        public const string SendFeedbackRedirect = "Profile/Feedbacks";
        public const string OpenCommentTicketRedirect = "/Social/TicketSent";
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
        public const string ErrorRedirect = @"\Error";
        public const string SpellCommandRedirect = @"\GameContent\Spells";
        public const string InModerationRedirect = @"\Topic\InModeration";

        // Errors
        public const string NullCommentError = "User {0} left a blank comment.";
        public const string ConfirmPasswordError = "Passwords must match.";
        public const string IdentityInUse = "{0} is in use, please choose another {0}.";
        public const string UsernameError = "Username must contain only letters or digits.";
        public const string PasswordError = "Password must contain only letters or digts, at least one uppercase letter, one digit, one non alphanumeric character and must be at least 8 characters long.";
        public const string EmailError = "Invalid Email Address.";
        public const string AllowedUnitsError = "You already have {0} Heroes! Delete a Hero or purchase more Hero Slots.";
        public const string UserNotFound = "User : {0} was not found.";
        public const string FillAllFieldsError = "Please, fill all fields";
        public const string TitleError = "Title should be between 5 and 30 characters";

        //Notification types
        public const string WarningType = "Warning";
        public const string PenaltyType = "Penalty";
        public const string RewardType = "Reward";

        // Routes
        public const string HomeRoute = "/Home";

        // Feedback
        public const string SendFeedback = "Thank you, {0} for your feedback! If your feedback is marked as useful, you will recieve a reward!" +
                                            "You can track your feedbacks in your Profile Panel.";
        public const string AcceptedFeedback = "Brilliant idea, {0}! Your feedback was accepted! You have been rewarded {1} Supporter Stars!";

        // Messages
        public const string WarningMessage = "{0}, you have reached {1} warnings! Recieving another warning will be a resulting a penalty!";
        public const string PenaltyMessage = "{0}, you have been muted for {1} day(s)!";
        public const string SwearMessage = "Please, keep things CLEAN!!!";
        public const string SpamMessage = "Please, do not SPAM duplicate characters!";
        public const string LengthMessage = "{0} length must be between {2} and {1} characters.";
        public const string RequiredMessage = "This Field is required";
        public const string ContentMessage = "{0} can only have upper case letters, lower case letters or digits.";


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

        // Filters (Regex)
        public const string UsernameFilter = @"(\d*[a-z]+\d*)";
        public const string ContentFilter = @"([A-Z]*[a-z]*[0-9]*\s*)";
        public const string SpamFilter = @"^((?!a{3,}|b{3,}|c{3,}|d{3,}|e{3,}|f{3,}g{3,}|h{3,}|i{3,}|j{3,}|k{3,}|l{3,}|m{3,}|n{3,}|o{3,}|p{3,}|q{3,}|
                                                    r{3,}|s{3,}|t{3,}|u{3,}|v{3,}|w{3,}|x{3,}|y{3,}|z{3,}|A{3,}|B{3,}|C{3,}|D{3,}|E{3,}|F{3,}G{3,}
                                                    |H{3,}|I{3,}|J{3,}|K{3,}|L{3,}|M{3,}|N{3,}|O{3,}|P{3,}|Q{3,}|R{3,}|S{3,}|T{3,}|U
                                                    {3,}|V{3,}|W{3,}|X{3,}|Y{3,}|Z{3,}|1{6,}|2{6,}|3{6,}|4{6,}|5{6,}|6{6,}|7{6,}|8{6,}|9{6,}).)*$";

        public const string SwearFilter = @"^((?!arse|asshole|orgy|squirt|threesome|fingering|fisting|hentai|masturbate|masturbation|gangbang|doublepenetration|creampie
                                            |cuckold|tits|bukkake|bitch|horseshit|bondage|bisexual|twat|crap|shitass|wank|cum|boobjob|dickhead|slut|whore|prostitute|suicide|shit|fuck|suicidal|anal|oral|sex|cunt|clitoris|
                                            deepthroat|cock|nigger|niger|nigor|nigra|nigre|nigar|niggur|nigga|niggah|niggar|nigguh|niggress|nigette|kys|hardon|testicle|scrote|schlong|prick|nutsack|fuckstick|asshat|idiot|
                                            dickhole|cockfucker|cockface|cockburger|cockbite|clitface|assshit|asssucker|assmunch|assmonkey|bigass|bigdick|asscock|asshead).)*$";
    }
}
