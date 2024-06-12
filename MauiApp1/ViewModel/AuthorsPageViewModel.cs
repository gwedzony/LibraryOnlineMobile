using System.Collections.ObjectModel;
using Database.Data.MobileApp;
using MauiApp1.Model.DTO;
using MauiApp1.Services;

namespace MauiApp1.ViewModel;

public class AuthorsPageViewModel: BaseViewModel
{
    
    private ObservableCollection<AuthorsCardDTO> _authorsCards;
    private readonly AuthorsCardsService _cardsService;
    public ObservableCollection<AuthorsCardDTO> AuthorsCards
    {
        get => _authorsCards;
        set
        {
            if (_authorsCards != value)
            {
                _authorsCards = value;
                OnPropertyChanged(nameof(AuthorsCards));
            }
        }
    }


    public AuthorsPageViewModel()
    {
        _cardsService = new AuthorsCardsService();
        _authorsCards = new ObservableCollection<AuthorsCardDTO>();
        GetAuthorsCardsFromApi();
    }
    
    private async Task GetAuthorsCardsFromApi()
    {
        
        List<MobileBooksAuthorCard> list = await _cardsService.GetItems();

        
        foreach (var item in list)
        {
           
            _authorsCards.Add(new AuthorsCardDTO()
            {
                Id = item.Id,
                Name = item.Author.Name,
                Surname = item.Author.Surname,
                Description= item.Author.Description,
                PhotoUrl = item.Author.PhotoUrl,
            });
        }
        
    }
    
}