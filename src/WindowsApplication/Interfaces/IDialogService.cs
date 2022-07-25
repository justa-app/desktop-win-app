using WindowsApplication.Services;

namespace WindowsApplication.Interfaces
{
    public interface IDialogService
    {
        T OpenDialog<T>(DialogViewModelBase<T> viewModel);
    }
}