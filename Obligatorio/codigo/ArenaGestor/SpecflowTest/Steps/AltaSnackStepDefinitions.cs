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

namespace SpecflowTest.Steps
{
    [Binding]
    public class AltaSnackStepDefinitions
    {
        private ISnackAppService controller;
        private SnackPostDto snack;
        private string errorMessage;
        private IActionResult result;
        private const string alreadyUsedDescription = "usada";
        private Snack snackWithUsedDescription = new()
        {
            Price = 10,
            Description =alreadyUsedDescription
        };

        [Given(@"me encuentro en la pestaña de creación de los snacks")]
        public void GivenMeEncuentroEnLaPestanaDeCreacionDeLosSnacks()
        {
            var factory = new FactorySnackService(new[] { snackWithUsedDescription });
            controller = factory.CreateAppService();
            snack = new();
        }


        [Given(@"escribo un precio")]
        public void GivenEscriboUnPrecio()
        {
            snack.Price = 0;
        }

        [When(@"apreto el boton de Confirmar")]
        public void WhenApretoElBotonDeConfirmar()
        {
            try
            {
                result = controller.PostSnack(snack);
            }catch(Exception e)
            {
                errorMessage = e.Message;
            }
            
        }

        [Then(@"me sale un mensaje de error que dice ""([^""]*)""")]
        public void ThenMeSaleUnMensajeDeErrorQueDice(string p0)
        {
            errorMessage.Should().Be(p0);
        }

        [Given(@"escribo una descripción")]
        public void GivenEscriboUnaDescripcion()
        {
            snack.Description = "Papas fritas";
        }

        [Given(@"escribo un precio negativo")]
        public void GivenEscriboUnPrecioNegativo()
        {
            snack.Price = -1;
        }

        [Given(@"escribo un precio positivo")]
        public void GivenEscriboUnPrecioPositivo()
        {
            snack.Price = 30;
        }

        [Then(@"me sale un mensaje que dice ""([^""]*)""")]
        public void ThenMeSaleUnMensajeQueDice(string p0)
        {
            var objectResult = result as ObjectResult;
            var createdSnack = objectResult.Value as SnackPostResultDto;
            createdSnack.Description.Should().Be("Papas fritas");
            createdSnack.Price.Should().Be(30);
            objectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Given(@"escribo una descripción que ya existe previamente")]
        public void GivenEscriboUnaDescripcionQueYaExistePreviamente()
        {
            snack.Description = alreadyUsedDescription;
        }

        private ISnackAppService CreateAppService()
        {
            SnackManagement dataAccess = new(CreateDataBase());
            SnackService service = new(dataAccess);
            SnackController controller = new(service);
            return controller;
        }

        private DbContext CreateDataBase()
        {
            var context = CreateDbContext();
            context.Add(snackWithUsedDescription);
            context.SaveChanges();
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            return context;
        }
        public DbContext CreateDbContext()
        {
            var dbName = Guid.NewGuid().ToString();

            var options = new DbContextOptionsBuilder<ArenaGestorContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            return new ArenaGestorContext(options);
        }
    }
}
