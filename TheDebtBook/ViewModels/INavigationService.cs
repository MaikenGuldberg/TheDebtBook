namespace TheDebtBook
{
    public interface INavigationService
    {
        void ShowView(object ViewModel);
        void HideView(object ViewModel);
        void CloseView(object ViewModel);
    }
}