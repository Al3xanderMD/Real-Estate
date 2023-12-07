using Partial.Application.Responses;

namespace Partial.Application.Features.Book.Command.UpdateBook
{
    public class UpdateBookCommandResponse : BaseResponse
    {
        public UpdateBookCommandResponse() : base()
        {
        }

        public UpdateBookDto Book { get; set; } = default!;
    }
}
