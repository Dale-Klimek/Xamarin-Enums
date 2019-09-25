namespace XamarinEnums.ViewModels
{
    using Enums;

    class MainPageViewModel : BaseViewModel
    {
        private Servers _servers;

        public Servers Servers
        {
            get => _servers;
            set
            {
                SetProperty(ref _servers, value);
                OnPropertyChanged(nameof(ServerName));
            }
        }

        public string ServerName => Servers.ToString();
    }
}
