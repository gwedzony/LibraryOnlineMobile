using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;
using MauiApp1.Model.DTO;
using MauiApp1.Pages.Shared;
using MauiApp1.ViewModel;

namespace MauiApp1.Pages;

public partial class BookcasesPage : ContentPage
{
  
    public BookcasesPage()
    {
        InitializeComponent();
    }


    private void ImageButton_OnClicked(object? sender, EventArgs e)
    {
        Popup pops = new EditNamePopup();
        this.ShowPopup(pops);
    }
}