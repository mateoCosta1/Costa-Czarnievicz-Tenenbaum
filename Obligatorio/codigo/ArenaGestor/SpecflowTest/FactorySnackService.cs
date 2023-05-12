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
        DbContext context;

        public FactorySnackService(Snack[] snacksInDatabase)
        {
            dataAccess = new(CreateDataBase(snacksInDatabase));
            service = new(dataAccess);
            controller = new(service);
        }
        public FactorySnackService(Snack[] snacksInDatabase, SnackPurchase[] purchasesInDatabase)
        {
            dataAccess = new(CreateDataBase(snacksInDatabase));
            foreach(var p in purchasesInDatabase)
            {
                dataAccess.InsertSnackPurchase(p);
            }
            service = new(dataAccess);
            controller = new(service);
        }
        public ISnackAppService CreateAppService()
        {
            return controller;
        }

        public ISnackManagement GetDataAccess()
        {
            return dataAccess;
        }

        public void AddObjectToContext(object obj)
        {
            context.Entry(obj).State = EntityState.Added;
            context.SaveChanges();
        }

        private DbContext CreateDataBase(Snack[] snacksInDatabase)
        {
            context = CreateDbContext();
            foreach (var snack in snacksInDatabase)
            {
                context.Add(snack);
                context.SaveChanges();
                context.Entry(snack).State = EntityState.Detached;
                context.SaveChanges();
            }
            
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
