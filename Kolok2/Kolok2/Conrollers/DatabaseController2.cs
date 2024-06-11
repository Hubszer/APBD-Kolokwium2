using System.Transactions;
using Kolok2.Data;
using Kolok2.DTOs;
using Kolok2.Models;
using Kolok2.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Kolok2.Conrollers;
[Route("api/[controller]")]
[ApiController]
public class DatabaseController2 : ControllerBase
{
    private readonly IDbService _dbService;
    /*private readonly DatabaseContext _context;*/
    public DatabaseController2(IDbService dbService)
    {
        _dbService = dbService;
    }
    /*[HttpGet("{id}")]
    public async Task<IActionResult> GetCharacter(int id)
    {
        
        return Ok();
    }*/
    
    /*[HttpPost("{id}/backpacks")]
    public async Task<IActionResult> AddItemsToBackpack(int id, [FromBody] List<int> itemIds,NewItemsToBackpackDTO newItemsToBackpackDto)
    {
       
        var chara = await _dbService.DoesCharacterExist(id);
        if (chara == null)
        {
            return NotFound();
        }

        var items = await _dbService.DoesItemExist(id);

        if ( items == null)
        {
            return BadRequest();
        }

        var item = new Items
        {
            Id = id,
            Name = newItemsToBackpackDto.Name
        };
        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            await _dbService.AddNewItem(item);
            
            
            scope.Complete();
        }
        */
    
       
        
        /*if (character.CurrentWeight + totalWeightToAdd > character.MaxWeight)
        {
            return BadRequest("Not enough carrying capacity.");
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

        await _dbService.SaveChangesAsync();

        var result = character.Backpacks.Select(b => new
        {
            amount = b.Amount,
            itemId = b.ItemId,
            characterId = b.CharacterId
        });*/
        

 
}

