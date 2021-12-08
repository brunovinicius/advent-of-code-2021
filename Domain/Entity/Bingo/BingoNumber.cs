namespace Domain.Entity.Bingo
{
    public class BingoNumber
    {
        public byte Value { get; init; }

        public override bool Equals(object? obj)
        {
            return obj is BingoNumber number &&
                   Value == number.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        public override string? ToString()
        {
            return Value.ToString();
        }
    }
}
