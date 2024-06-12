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
    private BookcasesViewModel vm;
    
    public BookcasesPage(BookcasesViewModel bookcasevm)
    {
        InitializeComponent();
        vm = bookcasevm;
        BindingContext = vm;

    }

    private async void ImageButton_OnClicked(object? sender, EventArgs e)
    {
        var imageButton = (ImageButton)sender;
        var item = (BookcasesDTO)imageButton.BindingContext;
        vm.IdFromPrompt = item.Id;
       
        var pops = new EditNamePopup(vm);
        this.ShowPopup(pops);

    }

    
}