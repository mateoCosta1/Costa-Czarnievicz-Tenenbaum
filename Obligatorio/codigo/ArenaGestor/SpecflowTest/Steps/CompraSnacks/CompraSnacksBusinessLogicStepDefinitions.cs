using ArenaGestor.Business;
using ArenaGestor.BusinessInterface;
using ArenaGestor.DataAccessInterface;
using ArenaGestor.Domain;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecflowTest.Steps.CompraSnacks
{
    [Binding, Scope(Feature = "CompraSnacksBusinessLogic")]
    public class CompraSnacksBusinessLogicStepDefinitions
    {
        private static Mock<ISnackManagement> mockDataAccess = new(MockBehavior.Strict);
        private ISnackService _snackService = new SnackService(mockDataAccess.Object);
        private Ticket ticket = new()
        {
            TicketId = new Guid(),
        };
        private Snack snack1 = new() 
        {
            SnackId = 1,
            Description = "Foo",
            Price = 10,
        };
        private SnackPurchaseItem snackAmount1 = new();
        private Snack snack2 = new()
        {
            SnackId = 2,
            Description = "Fi",
            Price = 77,
        };
        private SnackPurchaseItem snackAmount2 = new();
        private SnackPurchase purchase= new();
        private string errorMessage;
        private SnackPurchase result;
        private SnackPurchase expectedResult;

        public CompraSnacksBusinessLogicStepDefinitions()
        {
            snackAmount1.Snack = snack1;
            snackAmount2.Snack = snack2;
            purchase.TicketId = ticket.TicketId;
            mockDataAccess.Setup(x => x.InsertSnackPurchase(It.IsAny<SnackPurchase>()));
            mockDataAccess.Setup(x => x.GetSnack(snack1.SnackId)).Returns(snack1);
            mockDataAccess.Setup(x => x.GetSnack(snack2.SnackId)).Returns(snack2);
        }

        [Given(@"I have selected a \(non-empty\) set of snacks")]
        public void GivenIHaveSelectedANon_EmptySetOfSnacks()
        {
            purchase.Snacks = new SnackPurchaseItem[3] { snackAmount1, snackAmount2, snackAmount2};
        }

        [Given(@"for any of the snacks I have selected a quantity of snacks less than or equal to (.*)")]
        public void GivenForAnyOfTheSnacksIHaveSelectedAQuantityOfSnacksLessThanOrEqualTo(int minAmount)
        {
            snackAmount1.Amount = minAmount+1;
            snackAmount2.Amount = minAmount;
            purchase.Snacks = new SnackPurchaseItem[3] { snackAmount1, snackAmount2, snackAmount2 };
        }

        [When(@"I press the Confirm snack purchase button")]
        public void WhenIPressTheConfirmSnackPurchaseButton()
        {
            
            try
            {
                result = _snackService.PurchaseSnacks(purchase);
            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        [Then(@"an error message is displayed that says ""([^""]*)""")]
        public void ThenAnErrorMessageIsDisplayedThatSays(string p0)
        {
            errorMessage.Should().Be(p0);
        }

        [Given(@"that I didn't select any snacks")]
        public void GivenThatIDidntSelectAnySnacks()
        {
            purchase.Snacks = Array.Empty<SnackPurchaseItem>();
        }

        [Given(@"I have selected a quantity greater than (.*) for each selected snack")]
        public void GivenIHaveSelectedAQuantityGreaterThanForEachSelectedSnack(int minAcceptableAmount)
        {
            snackAmount1.Amount = minAcceptableAmount + 1;
            snackAmount2.Amount = minAcceptableAmount +2;
            purchase.Snacks = new SnackPurchaseItem[3] { snackAmount1, snackAmount2, snackAmount2 };
        }

        [Then(@"the price corresponding to the selected quantity of snacks is added to the total price of the tickets\.")]
        public void ThenThePriceCorrespondingToTheSelectedQuantityOfSnacksIsAddedToTheTotalPriceOfTheTickets_()
        {
            
        }

        [Then(@"the purchase is completed successfully")]
        public void ThenThePurchaseIsCompletedSuccessfully()
        {
            SnackPurchaseItem changedSnackAmount = new() { Snack =snack2, Amount = snackAmount2.Amount * 2 };
            expectedResult = new SnackPurchase()
            {
                TicketId = purchase.TicketId,
                Snacks = new SnackPurchaseItem[2] { snackAmount1, changedSnackAmount }
            };
            Assert.IsNotNull(result);
            bool sameTicket = expectedResult.TicketId.Equals(result.TicketId);
            bool hasCorrectAmountOfItems = result.Snacks.Count == 2;
            Assert.IsTrue(sameTicket && hasCorrectAmountOfItems);
        }
    }
}
