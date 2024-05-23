using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp1.ViewModel;
using Microsoft.EntityFrameworkCore.Query;

namespace MauiApp1.Pages;

[QueryProperty(nameof(BookId), "BookId")]
public partial class DetailsPage : ContentPage
{
    private int id;
    private DetailPageViewModel vm;
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
    }
    private void setProperPage(int id)
    {
        vm.GetItem(id);
    }
    
}