namespace Application.Common.RegexFilters
{
    using System.ComponentModel.DataAnnotations;

    public abstract class RegexFilter
    {
        public class SwearFilter : RegularExpressionAttribute
        {
            public SwearFilter(string pattern)
                : base(pattern)
            {
            }
        }

        public class ContentFilter : RegularExpressionAttribute
        {
            public ContentFilter(string pattern)
                : base(pattern)
            {
            }
        }

        public class SpamFilter : RegularExpressionAttribute
        {
            public SpamFilter(string pattern)
                : base(pattern)
            {
            }
        }
    }
}
