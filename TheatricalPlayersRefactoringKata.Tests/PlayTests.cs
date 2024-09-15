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
}
