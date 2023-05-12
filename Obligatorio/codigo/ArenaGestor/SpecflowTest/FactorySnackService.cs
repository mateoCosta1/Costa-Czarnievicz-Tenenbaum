using ArenaGestor.API.Controllers;
using ArenaGestor.APIContracts;
using ArenaGestor.Business;
using ArenaGestor.DataAccess.Managements;
using ArenaGestor.API.Controllers;
using ArenaGestor.APIContracts;
using ArenaGestor.APIContracts.Snack;
using ArenaGestor.Business;
using ArenaGestor.DataAccess.Managements;
using ArenaGestor.DataAccess;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TechTalk.SpecFlow;
using ArenaGestor.Domain;
using ArenaGestor.DataAccessInterface;

namespace SpecflowTest
{
    public class FactorySnackService
    {
        SnackManagement dataAccess;
        SnackService service;
        SnackController controller;

        public ISnackAppService CreateAppService(Snack[] snacksInDatabase)
        {
            dataAccess = new(CreateDataBase(snacksInDatabase));
            service = new(dataAccess);
            controller = new(service);
            return controller;
        }

        public ISnackManagement GetDataAccess()
        {
            return dataAccess;
        }

        private DbContext CreateDataBase(Snack[] snacksInDatabase)
        {
            var context = CreateDbContext();
            foreach (var snack in snacksInDatabase)
            {
                context.Add(snack);
            }
            context.SaveChanges();
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            return context;
        }

        private DbContext CreateDbContext()
        {
            var dbName = Guid.NewGuid().ToString();

            var options = new DbContextOptionsBuilder<ArenaGestorContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            return new ArenaGestorContext(options);
        }
    }
}
