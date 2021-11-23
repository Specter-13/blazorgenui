namespace BlazorGenUI.Reflection.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class AttributeName : System.Attribute
    {
        private string _customName { get; }
        public AttributeName(string customName)
        {
            this._customName = customName;
        }
        public string GetCustomName()
        {
            return _customName;
        }
    }
}
