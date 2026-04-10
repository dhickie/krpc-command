namespace KrpcCommand.Manoeuvres
{
    public abstract class ManoeuvreParameterBase
    {
        public string Name { get; }
        public string Label { get; }
        public abstract string ValueAsString { get; }

        public ManoeuvreParameterBase(string name, string label)
        {
            Name = name;
            Label = label;
        }

        public abstract void SetFromString(string value);
    }
}
