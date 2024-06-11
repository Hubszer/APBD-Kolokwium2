using Kolok2.Models;

namespace Kolok2.DTOs;

public class NewItemsToBackpackDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Items> Items { get; set; }
    public int Amount { get; set; }
    public int characterId { get; set; }
}