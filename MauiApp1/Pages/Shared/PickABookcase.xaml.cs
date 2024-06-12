using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;
using MauiApp1.ViewModel;

namespace MauiApp1.Pages.Shared;

public partial class PickABookcase : Popup
{
    private BookcasesViewModel vm;
    private string _bookId;

    public string BookId
    {
        get => _bookId;
        set
        {
            _bookId = value;
            OnPropertyChanged(nameof(BookId));
        }
    }
    


    public PickABookcase(BookcasesViewModel bookcasevm, int bookid)
    {
        InitializeComponent();
        vm = bookcasevm;
        BindingContext = vm;
        _bookId = bookid.ToString();
        Debug.WriteLine($"Bookid = {_bookId}");
    }

}