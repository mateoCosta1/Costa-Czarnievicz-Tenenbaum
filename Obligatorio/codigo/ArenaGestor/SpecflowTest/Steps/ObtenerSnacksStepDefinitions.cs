using System;
using TechTalk.SpecFlow;
using ArenaGestor.API;
using ArenaGestor.APIContracts;
using ArenaGestor.Domain;
using ArenaGestor.Business;
using ArenaGestor.DataAccess;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Http;
using System.Linq;
using ArenaGestor.API.Controllers;
using ArenaGestor.DataAccess.Managements;
using Microsoft.EntityFrameworkCore;
using ArenaGestor.APIContracts.Snack;

namespace SpecflowTest.Steps
{
    [Binding]
    public class ObtenerSnacksStepDefinitions
    {
        private ISnackAppService _snackAppService;
        private Snack snack1 = new()
        {
            SnackId = 1,
            Description = "Snack1",
            Price = 10,
        };
        private Snack snack2 = new()
        {
            SnackId = 2,
            Description = "Snack2",
            Price = 15,
        };

        private IActionResult result;

        [Given(@"que realice los pasos de compra de tickets correctamente")]
        public void GivenQueRealiceLosPasosDeCompraDeTicketsCorrectamente()
        {
            var factory = new FactorySnackService(new[] { snack1, snack2 });
            _snackAppService = factory.CreateAppService();
        }

        [When(@"apreto el boton de “Comprar tickets”")]
        public void WhenApretoElBotonDeComprarTickets()
        {
            result = _snackAppService.GetAllSnacks();
        }

        [Then(@"se muestra un menú del cual puedo seleccionar distintos snacks y distintas cantidades")]
        public void ThenSeMuestraUnMenuDelCualPuedoSeleccionarDistintosSnacksYDistintasCantidades()
        {
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            var snacksFromDatabase = (ICollection<SnackGetDto>)objectResult.Value;
            var snackDto1 = new SnackGetDto(snack1);
            var snackDto2 = new SnackGetDto(snack2);
            SnackGetDto[] expectedSnacks = { snackDto1, snackDto2 };
            Assert.AreEqual(StatusCodes.Status200OK, statusCode);
            CollectionAssert.AreEquivalent(expectedSnacks, snacksFromDatabase.ToArray());
        }

        
    }
}
