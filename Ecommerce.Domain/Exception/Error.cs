namespace Ecommerce.Domain.Exception
{
    public sealed record Error(string error, string? description = null)
    {
        public static readonly Error None = new Error(string.Empty);
    }
}
