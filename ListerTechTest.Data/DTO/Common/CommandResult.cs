
namespace ListerTechTest.Data.Models.Common
{
    public sealed class CommandResult<T>
    {
        public bool Succeeded { get; private set; }

        public string Error { get; private set; }

        public T Content { get; private set; }

        public static CommandResult<T> Success(T Content) => new() { Succeeded = true, Content = Content };

        public static CommandResult<T> Failure(string error) => new() { Error = error };
    }
}
