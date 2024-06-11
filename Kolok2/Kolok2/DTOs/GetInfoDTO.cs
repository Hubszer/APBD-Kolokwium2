using Kolok2.Models;

namespace Kolok2.DTOs;

public class GetInfoDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int CurrentWeight { get; set; }
    public int maxWeight { get; set; }
    public ICollection<GetBackPackItemsDTO> BackPackItems { get; set; } = null;
    public ICollection<Titles> TitlesCollection { get; set; }
    public ICollection<CharacterTitles> CharacterTitlesCollection { get; set; }
}

public class GetBackPackItemsDTO
{
    public string ItemName { get; set; }
    public int ItemWeight { get; set; }
    public int Amount { get; set; }
}

public class GetTitleDTO
{
    public string Title { get; set; }
    public DateTime AcquiredAt { get; set; }
}