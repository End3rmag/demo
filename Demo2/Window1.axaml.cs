using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Demo2.Context;
using Demo2.Services;
using Microsoft.EntityFrameworkCore;

namespace Demo2;

public partial class Window1 : Window
{
    private readonly UserService _userService;
    private TextBox newemail;
    private TextBox newpassword;
    private TextBox repitnewpassword;
    private TextBox newFirstName;
    private TextBox newLastName;

    public Window1()
    {
        InitializeComponent();
        var optionsBuilder = new DbContextOptionsBuilder<Foruser002Context>();
        optionsBuilder.UseNpgsql("Host=lorksipt.ru;Database=foruser002;Username=user002;password=12232");
        var context = new Foruser002Context(optionsBuilder.Options);
        _userService = new UserService(context);
        newemail = this.FindControl<TextBox>("new_email");
        newpassword = this.FindControl<TextBox>("new_password");
        repitnewpassword = this.FindControl<TextBox>("repit_new_password");
        newFirstName = this.FindControl<TextBox>("new_FirstName");
        newLastName = this.FindControl<TextBox>("new_LastName");
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new MainWindow().Show();
        Close();
    }
        private void Registration_Click(object sender, RoutedEventArgs e)
    {
        var email = newemail.Text;
        var password = newpassword.Text;
        var confirmPassword = repitnewpassword.Text;
        var firstName = newFirstName.Text;
        var lastName = newLastName.Text;

        if (string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password) ||
            string.IsNullOrWhiteSpace(firstName) ||
            string.IsNullOrWhiteSpace(lastName))
        {
            new Window2("Заполните все обязательные поля").ShowDialog(this);
            return;
        }

        if (password != confirmPassword)
        {
            new Window2("Пароли не совпадают").ShowDialog(this);
            return;
        }

        var result = _userService.Register(email, password, confirmPassword, firstName, lastName);

        if (result.success)
        {
           new MainWindow().Show();
            this.Close();
        }
        else
        {
            new Window2("Произошла не известная ошибка").ShowDialog(this);
            return;
        }
    }
}
