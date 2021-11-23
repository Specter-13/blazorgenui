namespace BlazorGenUI.Reflection.Interfaces
{
    public interface IBaseElement
    {
        string AttributeName { get; set; }
        string RawName { get; set; }
        bool IsIgnored { get; set; }

        bool IsValueElement { get; set; }
    }
}
