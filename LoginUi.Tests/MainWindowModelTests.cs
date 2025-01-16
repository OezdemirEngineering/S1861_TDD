using FluentAssertions;
using System.Windows;

namespace LoginUi.Tests;

public class MainWindowModelTests
{
    [Fact]
    public void LoginButtonCommand_UserNamePassword_DashBoardPanelVisible()
    {
        // Arrange
        var mainWindowViewModel = new MainWindowViewModel
        {
            UserName = "admin",
            Password = "admin"
        };
        // Act
        mainWindowViewModel.LoginButtonCommand.Execute(null);
        // Assert
        mainWindowViewModel.LoginPanelVisibility.Should().Be(Visibility.Collapsed);
        mainWindowViewModel.DashBoardPanelVisibility.Should().Be(Visibility.Visible);
    }

    [Fact]
    public void LoginButtonCommand_InvalidUserNamePassword_LoginPanelVisible()
    {
        // Arrange
        var mainWindowViewModel = new MainWindowViewModel
        {
            UserName = "invalid",
            Password = "invalid"
        };
        // Act
        mainWindowViewModel.LoginButtonCommand.Execute(null);
        // Assert
        mainWindowViewModel.LoginPanelVisibility.Should().Be(Visibility.Visible);
        mainWindowViewModel.DashBoardPanelVisibility.Should().Be(Visibility.Collapsed);
    }

    [Fact]
    public void LogoutButtonCommand_Always_LoginPanelVisible()
    {
        // Arrange
        var mainWindowViewModel = new MainWindowViewModel();
        mainWindowViewModel.LoginPanelVisibility = Visibility.Collapsed;
        mainWindowViewModel.DashBoardPanelVisibility = Visibility.Visible;

        // Act
        mainWindowViewModel.LogoutButtonCommand.Execute(null);

        // Assert
        mainWindowViewModel.LoginPanelVisibility.Should().Be(Visibility.Visible);
        mainWindowViewModel.DashBoardPanelVisibility.Should().Be(Visibility.Collapsed);
    }

    [Fact]
    public void InitialState_LoginPanelVisible()
    {
        // Arrange & Act
        var mainWindowViewModel = new MainWindowViewModel();
        // Assert
        mainWindowViewModel.LoginPanelVisibility.Should().Be(Visibility.Visible);
        mainWindowViewModel.DashBoardPanelVisibility.Should().Be(Visibility.Collapsed);
    }
}
