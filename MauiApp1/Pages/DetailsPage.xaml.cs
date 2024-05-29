using System.Diagnostics;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using Database.Data.BookStructure;
using MauiApp1.Pages.Shared;
using MauiApp1.ViewModel;
using Microsoft.EntityFrameworkCore.Query;

namespace MauiApp1.Pages;

[QueryProperty(nameof(BookId), "BookId")]
public partial class DetailsPage : ContentPage
{
    private int id;
    private DetailPageViewModel vm;
    private BookcasesViewModel vmcase;
    public int BookId
    {
        get => id;
        set
        {
            id = value;
            OnPropertyChanged();
            setProperPage(id);
        }
       
    }
    public DetailsPage()
    {
        InitializeComponent();
        BindingContext = vm = new DetailPageViewModel();
        vmcase = new BookcasesViewModel();
    }
    private void setProperPage(int id)
    {
        vm.GetItem(id);
    }

    private void Button_OnClicked(object? sender, EventArgs e)
    {
        var pops = new PickABookcase(vmcase);
        this.ShowPopup(pops);
    }
}