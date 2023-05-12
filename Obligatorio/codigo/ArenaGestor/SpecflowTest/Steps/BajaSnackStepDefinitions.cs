using ArenaGestor.APIContracts;
using ArenaGestor.APIContracts.Snack;
using ArenaGestor.DataAccessInterface;
using ArenaGestor.Domain;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SpecflowTest.Steps
{
    [Binding]
    public class BajaSnackStepDefinitions
    {
        private ISnackAppService controller;
        private FactorySnackService factory;
        private ISnackManagement dataAccess;

        private Guid ticketId;
        private Snack snackToDelete = new()
        {
            SnackId = 1,
            Description = "Delete",
            Price = 2
        };
        private SnackPurchaseItem item;

        private SnackPurchase purchase;
        [Given(@"me encuentro en la pestaña de los snacks")]
        public void GivenMeEncuentroEnLaPestanaDeLosSnacks()
        {
            ticketId = Guid.NewGuid();
            item = new()
            {
                Snack = snackToDelete,
                Amount = 1,

            };
            purchase = new SnackPurchase()
            {
                TicketId = ticketId,
                Snacks = new List<SnackPurchaseItem>() { item }
            };
            factory = new FactorySnackService(new[] { snackToDelete });

            controller = factory.CreateAppService();
            
            dataAccess = factory.GetDataAccess();
            dataAccess.InsertSnackPurchase(purchase); 
        }

        [When(@"apreto el boton de Eliminar")]
        public void WhenApretoElBotonDeEliminar()
        {
            controller.DeleteSnack(snackToDelete.SnackId);
        }

        [Then(@"el snack se eliminó del listado")]
        public void ThenElSnackSeEliminoDelListado()
        {
            var objectResult = controller.GetAllSnacks() as ObjectResult;
            var snacks = objectResult.Value as ICollection<SnackGetDto>;
            var snackIsInGetAll = snacks.Contains(new SnackGetDto(snackToDelete));
            snackIsInGetAll.Should().Be(false);
        }

        [Then(@"las personas que compraron este snack pueden consumir las unidades que compraron")]
        public void ThenLasPersonasQueCompraronEsteSnackPuedenConsumirLasUnidadesQueCompraron()
        {
            var purchaseFromDatabase = dataAccess.GetPurchaseById(ticketId);
            AssertDeletedSnackIsPresent(purchaseFromDatabase);
        }

        private void AssertDeletedSnackIsPresent(SnackPurchase purchaseFromDatabase)
        {
            foreach(var item in purchaseFromDatabase.Snacks)
            {
                item.Snack.Should().NotBeNull();
            }
        }

        [Then(@"los espectadores no pueden comprar de ahora en adelante unidades de este producto")]
        public void ThenLosEspectadoresNoPuedenComprarDeAhoraEnAdelanteUnidadesDeEsteProducto()
        {
            string errorMessage=null;
            SnackItemDto itemDto = new()
            {
                Id = snackToDelete.SnackId,
                Amount = 2
            };
            PurchaseSnacksDto purchaseSnacksDto = new()
            {
                TicketId = new Guid(),
                Snacks = new[]{itemDto}
            };
            try
            {
                controller.PostPurchaseSnacks(purchaseSnacksDto);
            }
            catch (Exception ex) 
            {
                errorMessage = ex.Message;
            }
            errorMessage.Should().Be($"El snack {snackToDelete.SnackId} no existe");
        }
    }
}
