﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Pages;

public partial class DetailsPage : ContentPage
{
    public DetailsPage()
    {
        InitializeComponent();
    }

    private async void HomePageClick(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}