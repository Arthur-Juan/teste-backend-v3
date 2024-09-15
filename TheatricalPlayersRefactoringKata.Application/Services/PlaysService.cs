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
}
