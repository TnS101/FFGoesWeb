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
        public const string LengthException = "{0} length must be between {1} and {2} characters.";
        public const string IdentityInUse = "{0} is in use, please choose another {0}.";
        public const string RequiredField = "This Field is required";
        public const string UsernameError = "Username must contain only letters or digits and must be at least 5 characters long.";
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
        public const string UsernameFilter = @"\b(\d*[a-z]+\d*)\b";
        public const string SwearFilter = @"^[a@][s\$][s\$]$[a@][s\$][s\$]h[o0][l1][e3][s\$]?b
                                            [a@][s\$][t\+][a@]rd b[e3][a@][s\$][t\+][i1][a@]?[l1]([i1][t\+]y)?b[e3][a@][s\$][t\+][i1][l1][i1][t\+]yb[e3][s\$][t\+][i1]
                                            [a@][l1]([i1][t\+]y)?b[i1][t\+]ch[s\$]?b[i1][t\+]ch[e3]r[s\$]?b[i1][t\+]ch[e3][s\$]b[i1][t\+]ch[i1]ng?b[l1][o0]wj[o0]b[s\$]?c[l1][i1][t\+]^(c|k|c
                                            k|q)[o0](c|k|ck|q)[s\$]?$(c|k|ck|q)[o0](c|k|ck|q)[s\$]u(c|k|ck|q)[o0](c|k|ck|q)[s\$]u(c|k|ck|q)[e3]d (c|k|ck|q)[o0](c|k|ck|q)[s\$]u(c|k|ck|q)[e3]r(c|k|
                                            ck|q)[o0](c|k|ck|q)[s\$]u(c|k|ck|q)[i1]ng(c|k|ck|q)[o0](c|k|ck|q)[s\$]u(c|k|ck|q)[s\$]^cum[s\$]?$cumm??[e3]rcumm?[i1]ngcock(c|k|ck|q)um[s\$]h[o0][t\+](c|k|ck
                                            |q)un[i1][l1][i1]ngu[s\$](c|k|ck|q)un[i1][l1][l1][i1]ngu[s\$](c|k|ck|q)unn[i1][l1][i1]ngu[s\$](c|k|ck|q)un[t\+][s\$]?(c|k|ck|q)un[t\+][l1][i1](c|k|ck|q)(c|k|ck
                                            |q)un[t\+][l1][i1](c|k|ck|q)[e3]r(c|k|ck|q)un[t\+][l1][i1](c|k|ck|q)[i1]ngcyb[e3]r(ph|f)u(c|k|ck|q)d[a@]mnd[i1]ckd[i1][l1]d[o0]d[i1][l1]d[o0][s\$]d[i1]n(c|k|ck|q)d[
                                            i1]n(c|k|ck|q)[s\$][e3]j[a@]cu[l1](ph|f)[a@]g[s\$]?(ph|f)[a@]gg[i1]ng(ph|f)[a@]gg?[o0][t\+][s\$]?(ph|f)[a@]gg[s\$](ph|f)[e3][l1][l1]?[a@][t\+][i1][o0](ph|f)u(c|k|ck|q)
                                            (ph|f)u(c|k|ck|q)[s\$]?g[a@]ngb[a@]ng[s\$]?g[a@]ngb[a@]ng[e3]dg[a@]yh[o0]m?m[o0]h[o0]rnyj[a@](c|k|ck|q)\-?[o0](ph|f)(ph|f)?j[e3]rk\-?[o0](ph|f)(ph|f)?j[i1][s\$z][s\$z]?m?[c
                                            k][o0]ndum[s\$]?mast(e|ur)b(8|ait|ate)n[i1]gg?[e3]r[s\$]?[o0]rg[a@][s\$][i1]m[s\$]?[o0]rg[a@][s\$]m[s\$]?p[e3]nn?[i1][s\$]p[i1][s\$][s\$]p[i1][s\$][s\$][o0](ph|f)(ph|f) p[
                                            o0]rnp[o0]rn[o0][s\$]?p[o0]rn[o0]gr[a@]phypr[i1]ck[s\$]?pu[s\$][s\$][i1][e3][s\$]pu[s\$][s\$]y[s\$]?[s\$][e3]x[s\$]h[i1][t\+][s\$]?[s\$][l1]u[t\+][s\$]?[s\$]mu[t\+][s\$]
                                            ?[s\$]punk[s\$]?[t\+]w[a@][t\+][s\$]?";
    }
}
