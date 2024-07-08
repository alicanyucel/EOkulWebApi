public sealed record Address
{
    public string City { get; set; } = default;
    public string Town { get; set; } = default;
    public string FullAddress { get; set; } = default;
}