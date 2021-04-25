using System.ComponentModel;
using System.Runtime.CompilerServices;
using BlazorGenUI.Reflection.Annotations;

namespace BlazorGenUI.Reflection.ValueElementTypes
{
    public abstract class ValueElementBase : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}