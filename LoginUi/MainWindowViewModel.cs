using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LoginUi;

public class MainWindowViewModel: BindableBase
{
    public string UserName { get; set; }
    public string Password { get; set; }



    private Visibility _loginPanelVisibility = Visibility.Visible;
    private Visibility _dashBoardPanelVisibility = Visibility.Collapsed;

    public Visibility LoginPanelVisibility
    {
        get => _loginPanelVisibility;
        set => SetProperty(ref _loginPanelVisibility, value);
    } 
    public Visibility DashBoardPanelVisibility
    {
        get => _dashBoardPanelVisibility;
        set => SetProperty(ref _dashBoardPanelVisibility, value);
    }


    public ICommand LoginButtonCommand => new DelegateCommand(LoginMethod);
    public ICommand LogoutButtonCommand => new DelegateCommand(LogoutMethod);

    private void LogoutMethod()
    {
        LoginPanelVisibility = Visibility.Visible;
        DashBoardPanelVisibility = Visibility.Collapsed;
    }

    public MainWindowViewModel()
    {
        UserName = "admin";
        Password = "admin";

        LoginPanelVisibility = Visibility.Visible;
        DashBoardPanelVisibility = Visibility.Collapsed;
    }

    private void LoginMethod()
    {
        if(UserName == "admin" && Password == "admin")
        {
            LoginPanelVisibility = Visibility.Collapsed;
            DashBoardPanelVisibility = Visibility.Visible;
        }
    }
}
