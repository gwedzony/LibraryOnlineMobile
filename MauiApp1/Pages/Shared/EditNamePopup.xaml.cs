using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;
using MauiApp1.Model.DTO;
using MauiApp1.ViewModel;

namespace MauiApp1.Pages.Shared;

public partial class EditNamePopup : Popup
{
    private BookcasesViewModel vm;
    public EditNamePopup(BookcasesViewModel bookcasevm)
    {
        InitializeComponent();
        vm = bookcasevm;
        BindingContext = vm;
    }

   private void Button_OnClicked(object? sender, EventArgs e) => Close();

}