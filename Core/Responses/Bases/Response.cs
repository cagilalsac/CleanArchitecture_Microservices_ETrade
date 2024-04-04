using Core.Records.Bases;

namespace Core.Responses.Bases
{
    public record Response : Record
    {
        public bool IsSuccessful { get; }
        public string Message { get; }
        public int Id { get; set; }

        public Response(bool isSuccessful, string message, int id)
        {
            IsSuccessful = isSuccessful;
            Message = message;
            Id = id;
        }

        public Response()
        {
            Message = string.Empty;
        }
    }
}
