using BenchmarkDotNet.Attributes;

namespace StringCoversionBenchmark;

[MemoryDiagnoser(false)]
public class GuidUtilBenchMarkers
{
    private static readonly Guid _guidForTest = Guid.Parse("827d6387-1532-4ce1-84b0-c0fb20f62203");
    private const string _idAsString = "h2N9gjIV4UyEsMD7IPYiAw";

    [Benchmark]
    public string ToStringFromGuid()
    {
        return GuidUtil.ToStringFromGuid(_guidForTest);
    }

    [Benchmark]
    public string ToStringFromGuidOptimized()
    {
        return GuidUtil.ToStringFromGuidOptimized(_guidForTest);
    }

    [Benchmark]
    public Guid ToGuidFromString()
    {
        return GuidUtil.ToGuidFromString(_idAsString);
    }

    [Benchmark]
    public Guid ToGuidFromStringOptimized()
    {
        return GuidUtil.ToGuidFromStringOptimized(_idAsString);
    }
}