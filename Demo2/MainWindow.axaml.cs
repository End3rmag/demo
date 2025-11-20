using Avalonia.Controls;
using Avalonia.Interactivity;
using Demo2.Context;
using Demo2.Services;
using Microsoft.EntityFrameworkCore;

namespace Demo2;

public partial class MainWindow : Window
{
    private readonly UserService _userService;
    private TextBox authEmailTextBox;
    private TextBox authPasswordTextBox;

    public MainWindow()
    {
        InitializeComponent();
        var optionsBuilder = new DbContextOptionsBuilder<Foruser002Context>();
        optionsBuilder.UseNpgsql("Host=lorksipt.ru;Database=foruser002;Username=user002;password=12232");
        var context = new Foruser002Context(optionsBuilder.Options);
        _userService = new UserService(context);
        authEmailTextBox = this.FindControl<TextBox>("auth_email");
        authPasswordTextBox = this.FindControl<TextBox>("auth_password");
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new Window1().Show();
        Close();
    }

    private void Authification_Click(object sender, RoutedEventArgs e)
    {
        var email = authEmailTextBox.Text;
        var password = authPasswordTextBox.Text;

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            new Window2("Заполните все поля").ShowDialog(this);
            return;
        }

        var result = _userService.Login(email, password);

        if (result.success)
        {
            new Window3().Show();
            Close();
        }
        else
        {
            new Window2("Произошла не известная ошибка").ShowDialog(this);
            return;
        }
    }
}

    
