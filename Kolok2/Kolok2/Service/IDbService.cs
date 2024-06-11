using Kolok2.Models;

namespace Kolok2.Service;

public interface IDbService
{
    Task<ICollection<Characters>> GetCharacterData(int characterId);
    Task<bool> DoesCharacterExist(int characterId);
    Task<bool> DoesBackPackExist(int backpackId);
    Task<bool> DoesItemExist(int itemId);
    Task<bool> DoesCharacterHasWeight(int weight);
    Task AddNewItem(Items items);
    Task<Items> FindItemById(int itemId);
    Task AddItemToPackpack(IEnumerable<Backpacks> backpacksEnumerable);


}