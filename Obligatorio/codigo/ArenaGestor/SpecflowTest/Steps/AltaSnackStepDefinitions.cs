using ArenaGestor.APIContracts;
using ArenaGestor.APIContracts.Snack;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TechTalk.SpecFlow;

namespace SpecflowTest.Steps
{
    [Binding]
    public class AltaSnackStepDefinitions
    {
        private ISnackAppService controller;
        private SnackPostDto snack;
        private string errorMessage;
        private IActionResult result;
        private string alreadyUsedDescription;

        [Given(@"me encuentro en la pestaña de creación de los snacks")]
        public void GivenMeEncuentroEnLaPestanaDeCreacionDeLosSnacks()
        {
            controller = BuildController();
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
            var createdSnack = objectResult.Value as SnackPostResult;
            createdSnack.Description.Should().Be("Papas fritas");
            createdSnack.Price.Should().Be(30);
            objectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Given(@"escribo una descripción que ya existe previamente")]
        public void GivenEscriboUnaDescripcionQueYaExistePreviamente()
        {
            snack.Description = alreadyUsedDescription;
        }

        private ISnackAppService BuildController()
        {
            throw new NotImplementedException();
        }
    }
}
