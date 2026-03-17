public record ProfileUpdateDto
{
    public string? FullName { get; init; }
    public string? BiologicalSex { get; init; }
    public decimal? WeightKg { get; init; }
    public decimal? HeightCm { get; init; }

    public string? ActivityLevel { get; init; }
    public string? Goal { get; init; }

    public List<string>? Allergies { get; init; }     
}