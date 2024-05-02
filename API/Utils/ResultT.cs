namespace API.Utils
{
    public class Result<T> : Result
    {
        protected internal Result(T value, bool success, string error)
            : base(success, error)
        {
            Value = value;
        }
        public T Value { get; set; }
    }
}
