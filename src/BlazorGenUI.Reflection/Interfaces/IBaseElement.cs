namespace BlazorGenUI.Reflection.Interfaces
{
    public interface IBaseElement
    {
        string RawName { get; set; }
        bool IsIgnored { get; set; }

        bool IsValueElement {get; set;}
    }
}