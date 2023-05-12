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
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace SpecflowTest
{
    public class FactorySnackService
    {
        SnackManagement dataAccess;
        SnackService service;
        SnackController controller;
        DbContext context;
        private readonly string databaseName= Guid.NewGuid().ToString();
        public FactorySnackService(Snack[] snacksInDatabase)
        {
            dataAccess = new(CreateDataBase(snacksInDatabase,databaseName));
            service = new(dataAccess);
            controller = new(service);
        }
        public FactorySnackService(Snack[] snacksInDatabase, SnackPurchase[] purchasesInDatabase)
        {
            dataAccess = new(CreateDataBase(snacksInDatabase,databaseName));
            foreach(var p in purchasesInDatabase)
            {
                dataAccess.InsertSnackPurchase(p);
            }
            service = new(dataAccess);
            controller = new(service);
        }
        public ISnackAppService CreateAppService()
        {
            ReInitializeComponents();
            return controller;
        }

        public ISnackManagement GetDataAccess()
        {
            ReInitializeComponents();
            return dataAccess;
        }

        private void ReInitializeComponents()
        {
            dataAccess = new(CreateDbContext(databaseName));
            service = new(dataAccess);
            controller = new(service);
        }

        private DbContext CreateDataBase(Snack[] snacksInDatabase, string databaseName)
        {
            context = CreateDbContext(databaseName);

            foreach (var snack in snacksInDatabase)
            {
                context.Add(snack);
                context.SaveChanges();
                context.Entry(snack).State = EntityState.Detached;
                context.SaveChanges();
            }
            
            
            return context;
        }

        private DbContext CreateDbContext(string dbName)
        {

            var options = new DbContextOptionsBuilder<ArenaGestorContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;
            var context = new ArenaGestorContext(options);
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            return context;
        }
    }
}
