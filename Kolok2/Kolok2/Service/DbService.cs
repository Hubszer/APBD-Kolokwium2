using Kolok2.Data;
using Kolok2.DTOs;
using Kolok2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kolok2.Service;


public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    private IDbService _dbServiceImplementation;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    
    
    public async Task<ICollection<Characters>> GetCharacterData(int characterId)
    {
        return await _context.Characters
            .Include(e => e.CharacterTitlesCollection)
            .Where(e => characterId == null || e.Id == characterId)
            .ToListAsync();
        
    }

    public async Task<bool> DoesCharacterExist(int characterId)
    {
        return await _context.Characters.AnyAsync(e => e.Id == characterId);
    }

    public Task<bool> DoesBackPackExist(int backpackId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DoesItemExist(int itemId)
    {
        return await _context.Items.AnyAsync(e => e.Id == itemId);
    }

    public async Task<bool> DoesCharacterHasWeight(int maxWeight)
    {
        return await _context.Characters.AnyAsync(e => e.MaxWeight == maxWeight);
    }

    public async Task AddNewItem(Items items)
    {
        await _context.AddAsync(items);
        await _context.SaveChangesAsync();
    }

    public async Task<Items> FindItemById(int itemId)
    {
        return await _context.Items.FirstOrDefaultAsync(e => e.Id == itemId);
    }

    public Task AddItemToPackpack(IEnumerable<Backpacks> backpacksEnumerable)
    {
        return _dbServiceImplementation.AddItemToPackpack(backpacksEnumerable);
    }
    /*public async Task<CharacterDto> GetCharacterByIdAsync(int id)
    {
        var character = await _context.Characters
            .Include(c => c.Backpacks).ThenInclude(b => b.Item)
            .Include(c => c.CharacterTitles).ThenInclude(ct => ct.Title)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (character == null)
        {
            return null;
        }

        return new CharacterDto
        {
            FirstName = character.FirstName,
            LastName = character.LastName,
            CurrentWeight = character.CurrentWeight,
            MaxWeight = character.MaxWeight,
            BackpackItems = character.Backpacks.Select(b => new BackpackItemDto
            {
                ItemName = b.Item.Name,
                ItemWeight = b.Item.Weight,
                Amount = b.Amount
            }).ToList(),
            Titles = character.CharacterTitles.Select(ct => new TitleDto
            {
                Title = ct.Title.Name,
                AcquiredAt = ct.AcquiredAt
            }).ToList()
        };
    }
    */

    public async Task<IEnumerable<NewItemsToBackpackDTO>> AddItemsToBackpackAsync(int characterId, List<int> itemIds)
    {
        var character = await _context.Characters.Include(c => c.Backpacks).ThenInclude(b => b.Items).FirstOrDefaultAsync(c => c.Id == characterId);

        if (character == null)
        {
            return null;
        }

        var items = await _context.Items.Where(i => itemIds.Contains(i.Id)).ToListAsync();

        if (items.Count != itemIds.Count)
        {
            return null;
        }

        var totalWeightToAdd = items.Sum(i => i.Weight);

        if (character.CurrentWeight + totalWeightToAdd > character.MaxWeight)
        {
            return null;
        }

        foreach (var item in items)
        {
            var backpackItem = character.Backpacks.FirstOrDefault(b => b.ItemId == item.Id);
            if (backpackItem == null)
            {
                character.Backpacks.Add(new Backpacks { CharacterId = character.Id, ItemId = item.Id, Amount = 1 });
            }
            else
            {
                backpackItem.Amount++;
            }

            character.CurrentWeight += item.Weight;
        }

        await _context.SaveChangesAsync();

        return character.Backpacks.Select(b => new NewItemsToBackpackDTO
        {
            Amount = b.Amount,
            Id = b.ItemId,
            characterId = b.CharacterId
        }).ToList();
    }
}