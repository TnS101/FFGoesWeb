namespace Application.GameCQ.Heroes.Commands.Create
{
    using System.ComponentModel.DataAnnotations;
    using Application.Common.StringProcessing.RegexFilters;
    using global::Common;
    using MediatR;

    public class CreateHeroCommand : RegexFilter, IRequest<string>
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = GConst.RequiredMessage)]
        [SpamFilter(GConst.SpamFilter, ErrorMessage = GConst.SpamMessage)]
        [SwearFilter(GConst.SwearFilter, ErrorMessage = GConst.SwearMessage)]
        [StringLength(20, ErrorMessage = GConst.LengthMessage, MinimumLength = 5)]
        public string Name { get; set; }

        [Required(ErrorMessage = GConst.RequiredMessage)]
        public string Race { get; set; }

        public int ClassId { get; set; }
    }
}
