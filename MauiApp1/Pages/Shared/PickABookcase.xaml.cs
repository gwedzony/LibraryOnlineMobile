using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;
using MauiApp1.ViewModel;

namespace MauiApp1.Pages.Shared;

public partial class PickABookcase : Popup
{
    private BookcasesViewModel vm;
    
    public PickABookcase(BookcasesViewModel bookcasevm)
    {
        InitializeComponent();
        vm = bookcasevm;
        BindingContext = vm;
    }
    
    
}