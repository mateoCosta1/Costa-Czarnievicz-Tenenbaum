using ArenaGestor.API.Controllers;
using ArenaGestor.APIContracts;
using ArenaGestor.APIContracts.Snack;
using ArenaGestor.BusinessInterface;
using ArenaGestor.Domain;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
namespace SpecflowTest.Steps.CompraSnacks
{
    [Binding, Scope(Feature = "CompraSnacksAPI")]
    public class CompraSnacksAPIStepDefinitions
    {
        private static Mock<ISnackService> _mockSnackService = new(MockBehavior.Strict);
        private ISnackAppService apiService = new SnackController(_mockSnackService.Object);
        private ObjectResult result;
        private Exception error;
        private string invalidAmountMessage = "No se puede comprar una cantidad de snacks menor o igual a 0";
        private string noSelectedErrorMessage = "Tiene que seleccionar al menos un snack";
        private SnackItemDto snackDto1 = new()
        {
            Id = 1,
            Amount = 1,
        };
        private SnackPurchase snackPurchase;
        private SnackPurchaseItem item;
        private Snack snack1= new()
        {
           SnackId = 1,
           Description= "Des",
           Price = 40
        };
        private PurchaseSnacksDto _purchaseSnacksPost;

        public CompraSnacksAPIStepDefinitions()
        {
            _purchaseSnacksPost = new()
            {
                TicketId = new Guid(),
                Snacks = new[] { snackDto1, snackDto1}
            };
            item = new()
            {
                Snack = snack1,
                Amount = snackDto1.Amount * 2
            };
            snackPurchase = new()
            {
                TicketId = _purchaseSnacksPost.TicketId,
                Snacks = new List<SnackPurchaseItem>(){item},
                TotalPrice = snackDto1.Amount * 2
            };
        }

        [Given(@"I have selected a \(non-empty\) set of snacks")]
        public void GivenIHaveSelectedANon_EmptySetOfSnacks()
        {
            _mockSnackService.Setup(x => x.PurchaseSnacks(It.IsAny<SnackPurchase>())).Returns(snackPurchase);
        }

        [Given(@"for any of the snacks I have selected a quantity of snacks less than or equal to (.*)")]
        public void GivenForAnyOfTheSnacksIHaveSelectedAQuantityOfSnacksLessThanOrEqualTo(int amount)
        {
            snackDto1.Amount = amount;
            _mockSnackService.Setup(x => x.PurchaseSnacks(It.IsAny<SnackPurchase>())).Throws(new Exception(invalidAmountMessage));
        }


        [When(@"I press the Confirm snack purchase button")]
        public void WhenIPressTheConfirmSnackPurchaseButton()
        {
            try
            {
                result = apiService.PostPurchaseSnacks(_purchaseSnacksPost) as ObjectResult;
            }
            catch (Exception e)
            {
                error = e;
            }

        }

        [Then(@"an error message is displayed that says ""([^""]*)""")]
        public void ThenAnErrorMessageIsDisplayedThatSays(string errorMessage)
        {
            error.Message.Should().Be(errorMessage);
        }

        [Given(@"that I didn't select any snacks")]
        public void GivenThatIDidntSelectAnySnacks()
        {
            _mockSnackService.Setup(x => x.PurchaseSnacks(It.IsAny<SnackPurchase>())).Throws(new Exception(noSelectedErrorMessage));
        }

        [Given(@"I have selected a quantity greater than (.*) for each selected snack")]
        public void GivenIHaveSelectedAQuantityGreaterThanForEachSelectedSnack(int amount)
        {
            snackDto1.Amount = amount+1;
            _mockSnackService.Setup(x => x.PurchaseSnacks(It.IsAny<SnackPurchase>())).Returns(snackPurchase);
        }

        [Then(@"the price corresponding to the selected quantity of snacks is added to the total price of the tickets\.")]
        public void ThenThePriceCorrespondingToTheSelectedQuantityOfSnacksIsAddedToTheTotalPriceOfTheTickets_()
        {
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}
