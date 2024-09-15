using Bogus;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheatricalPlayersRefactoringKata.Application.Services;
using TheatricalPlayersRefactoringKata.Data.Errors;
using TheatricalPlayersRefactoringKata.Data.Errors.Exceptions;
using TheatricalPlayersRefactoringKata.Data.Errors.Exceptions.Play;
using TheatricalPlayersRefactoringKata.Data.Model.Input;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests;

public class PlayTests
{
    private readonly PlaysService _playsService;
    public PlayTests()
    {
        var serviceProvider = TestServiceProvider.CreateServiceProvider();
        _playsService = serviceProvider.GetRequiredService<PlaysService>();
    }


    private CreatePlayDTO CreateRandomPlayDTO()
    {
        
        var faker = new Faker<CreatePlayDTO>()
               .CustomInstantiator(f => new CreatePlayDTO(  f.Lorem.Word(), f.Random.Number(), "comedy", f.Lorem.Word()));

        return faker.Generate();
    }

    [Fact]
    public async Task TestShouldReturnPlayAfterCreate()
    {
        var dto = CreateRandomPlayDTO();

        var result = await _playsService.CreateAsync(dto);
        Assert.NotNull(result);
        Assert.Equal(dto.name, result.Name);
        Assert.Equal(dto.lines, result.Lines);
        Assert.Equal(dto.type, result.Type);
        Assert.Equal(dto.slug, result.Slug);


    }

    [Fact]
    public async Task TestShouldNotCreateMoreThanOnePlayWithSameName()
    {
        var dto = CreateRandomPlayDTO();

        await _playsService.CreateAsync(dto);

        var exception = await Assert.ThrowsAsync<InvalidPlayException>(async () =>
        {
            await _playsService.CreateAsync(dto);
        });
        Assert.Contains(DomainErrors.Play.PlayExists, exception.Message);

    }

    [Fact]
    public async Task TestShouldNotReturnEmptyListIfDatabaseIsNotEmpty()
    {
        var dto = CreateRandomPlayDTO();

        await _playsService.CreateAsync(dto);

        var list = await _playsService.ListAsync();

        Assert.True(list.Any());

    }

    [Fact]
    public async Task TestShouldReturnAPlayBySlug()
    {
        var dto = CreateRandomPlayDTO();

        await _playsService.CreateAsync(dto);

        var play = await _playsService.GetBySlugAsync(dto.slug);

        Assert.NotNull(play);
        Assert.Equal(dto.name, play.name);
        Assert.Equal(dto.lines, play.lines);
        Assert.Equal(dto.type, play.type);
        Assert.Equal(dto.slug, play.slug);
    }

    [Fact]
    public async Task TestShouldThrowExceptionIfSlugNotExists()
    {

        var exception = await Assert.ThrowsAsync<PlayNotFoundException>(async () =>
        {
            await _playsService.GetBySlugAsync("notexists");
        });
        Assert.Contains(DomainErrors.Play.PlayNotFound, exception.Message);
    }



}
