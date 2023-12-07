using Partial.Application.Responses;

namespace Partial.Application.Features.Book.Command.CreateBook
{
    public class CreateBookCommandResponse : BaseResponse
    {
        public CreateBookCommandResponse() : base()
        {
        }

        public CreateBookDto Book { get; set; }
    }
}
