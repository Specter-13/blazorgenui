namespace BlazorGenUI.Reflection.Interfaces
{
    public interface IBaseElement
    {
        IEntryBase Instance { get; set; }
        string Name { get; set; }
    }
}