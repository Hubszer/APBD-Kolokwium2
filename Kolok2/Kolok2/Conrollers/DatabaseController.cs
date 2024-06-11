using Kolok2.DTOs;
using Kolok2.Models;
using Kolok2.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Kolok2.Conrollers;

[Route("api/[controller]")]
[ApiController]
public class DatabaseController : ControllerBase
{
    private readonly IDbService _dbService;
    public DatabaseController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("api/characters/{characterId}")]
    public async Task<IActionResult> GetCharacterData(int characterId)
    {
        var character = await _dbService.GetCharacterData(characterId);
        
        return Ok(character.Select(e => new GetInfoDTO()
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            CurrentWeight = e.CurrentWeight,
            maxWeight = e.MaxWeight,
            BackPackItems = e.Backpacks.Select(b => new GetBackPackItemsDTO
            {
                ItemName = b.Items.Name,
                ItemWeight = b.Items.Weight,
                Amount = b.Amount
            }).ToList()
            /*TitlesCollection = e.CharacterTitlesCollection.Select(c => new GetTitleDTO
            {
                Title = c.Titles.Name,
                AcquiredAt = c.AcquiredAt
            }).ToList()*/
            
          
        }));
    }
}