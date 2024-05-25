using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;
using MauiApp1.Pages.Shared;

namespace MauiApp1.Pages;

public partial class BookcasesPage : ContentPage
{
    public BookcasesPage()
    {
        
        InitializeComponent();
    }
    private void ImageButton_OnClicked(object? sender, EventArgs e)
    {
        var pops = new EditPopup();
        this.ShowPopup(pops);
    }
}