using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Demo2.Services;

namespace Demo2;

public partial class Window2 : Window
{
    
    public Window2(string a)
    {
        InitializeComponent();
        Eror.Text = a;
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }
}