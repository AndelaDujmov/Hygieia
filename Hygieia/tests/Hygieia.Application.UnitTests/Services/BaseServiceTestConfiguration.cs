using System;
using System.Collections.Generic;
using AutoMapper;
using Hygieia.Application.MappingProfiles;
using Hygieia.DataAccess.Repositories;
using Hygieia.Shared.Services;
using Microsoft.Extensions.Configuration;
using NSubstitute;

namespace Hygieia.Application.UnitTests.Services;

public class BaseServiceTestConfiguration
{
    protected readonly IClaimService ClaimService;
    protected readonly IConfiguration Configuration;
    protected readonly IMapper Mapper;
    protected readonly ITodoItemRepository TodoItemRepository;
    protected readonly ITodoListRepository TodoListRepository;

    protected BaseServiceTestConfiguration()
    {
        Mapper = new MapperConfiguration(cfg => { cfg.AddMaps(typeof(TodoItemProfile)); }).CreateMapper();

        var configurationBody = new Dictionary<string, string>
        {
            { "JwtConfiguration:SecretKey", "Super secret token key" }
        };

        Configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(configurationBody)
            .Build();

        TodoListRepository = Substitute.For<ITodoListRepository>();
        TodoItemRepository = Substitute.For<ITodoItemRepository>();

        ClaimService = Substitute.For<IClaimService>();
        ClaimService.GetUserId().Returns(new Guid().ToString());
    }
}
