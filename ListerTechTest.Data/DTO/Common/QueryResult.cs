
namespace ListerTechTest.Data.Models.Common
{
    public sealed class QueryResult
    {
        public bool Succeeded { get; private set; }

        public string Error { get; private set; }

        public static QueryResult Success() => new() { Succeeded = true };

        public static QueryResult Failure(string error) => new() { Error = error };
    }
}
