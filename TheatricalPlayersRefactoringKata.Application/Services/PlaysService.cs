using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheatricalPlayersRefactoringKata.Data;
using TheatricalPlayersRefactoringKata.Data.Domain;
using TheatricalPlayersRefactoringKata.Data.Errors;
using TheatricalPlayersRefactoringKata.Data.Errors.Exceptions.Play;
using TheatricalPlayersRefactoringKata.Data.Model.Input;
using TheatricalPlayersRefactoringKata.Data.Model.Output;

namespace TheatricalPlayersRefactoringKata.Application.Services;
public class PlaysService
{
    private readonly AppDbContext _appDbContext;

    public PlaysService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Play> CreateAsync(CreatePlayDTO createPlayDto)
    {

        var play = await _appDbContext.Plays.AsNoTracking().FirstOrDefaultAsync(x => x.Slug == createPlayDto.slug);
        if (play != null)
        {
            throw new InvalidPlayException(DomainErrors.Play.PlayExists);

        }

        play = new Play(createPlayDto.name, createPlayDto.lines, createPlayDto.type, createPlayDto.slug);
        await _appDbContext.Plays.AddAsync(play);
        await _appDbContext.SaveChangesAsync();

        return play;
    }

    public async Task<List<PlayOutputDTO>> ListAsync()
    {
        var plays = await _appDbContext.Plays.AsNoTracking().Where(x => x.DeletedAt == null).ToListAsync();
        
        var output = new List<PlayOutputDTO>();
        
        foreach(var play in plays)
        {
            output.Add(new PlayOutputDTO(play.Name, play.Lines, play.Type, play.Slug));
        }

        return output;
    }
}
