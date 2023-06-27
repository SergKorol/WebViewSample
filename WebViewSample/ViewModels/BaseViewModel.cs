using System.Runtime.CompilerServices;

namespace WebViewSample.ViewModels;

public abstract class BaseViewModel : BindableObject
{
    protected bool SetProperty<T>(ref T backingStore, T value,
        [CallerMemberName] string propertyName = "",
        Action onChanged = null)
    {
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
        {
            return false;
        }

        backingStore = value;
        onChanged?.Invoke();

        OnPropertyChanged(propertyName);
        return true;
    }
}