namespace LearnImmutable
{
    public record class SampleRecord(string ParamString, int ParamInt, DateTime ParamDate)
    {
        public string MutableProp { get; set; }
    }
}
