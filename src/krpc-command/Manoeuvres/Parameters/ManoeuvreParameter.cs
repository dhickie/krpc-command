namespace KrpcCommand.Manoeuvres.Parameters
{
    public abstract class ManoeuvreParameter(string name, string label)
    {
        public string Name { get; } = name;
        public string Label { get; } = label;
        public abstract string ValueAsString { get; }

        public abstract void Set(string value);
    }
}
