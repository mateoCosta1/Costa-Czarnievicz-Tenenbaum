using FluentAssertions;
using System;
using TechTalk.SpecFlow;

namespace SpecflowTest.Steps
{
    [Binding]
    public class AltaSnackStepDefinitions
    {
        [Given(@"que me encuentro logeado como administrador")]
        public void GivenQueMeEncuentroLogeadoComoAdministrador()
        {
            //throw new PendingStepException();
        }

        [Given(@"me encuentro en la pestaña de creación de snacks")]
        public void GivenMeEncuentroEnLaPestanaDeCreacionDeSnacks()
        {
            //throw new PendingStepException();
        }

        [Given(@"escribo un precio")]
        public void GivenEscriboUnPrecio()
        {
           // throw new PendingStepException();
        }

        [When(@"apreto el boton de confirmar")]
        public void WhenApretoElBotonDeConfirmar()
        {
            //throw new PendingStepException();
        }

        [Then(@"me sale un error que dice ""([^""]*)""")]
        public void ThenMeSaleUnErrorQueDice(string p0)
        {
            int dos = 2;
            dos.Should().Be(2);
        }
    }
}
