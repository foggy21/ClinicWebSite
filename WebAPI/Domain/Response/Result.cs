using Domain.Entities;

namespace Domain.Response
{
    public class Result<T> : IResult<T>
    {
        public string Description { get; set; }
        public StatusCode StatusCode { get; set; }

        public T? Value { get; set; }
    }

    public interface IResult<T>
    {
        public T? Value { get; set; }
        
    }
}
