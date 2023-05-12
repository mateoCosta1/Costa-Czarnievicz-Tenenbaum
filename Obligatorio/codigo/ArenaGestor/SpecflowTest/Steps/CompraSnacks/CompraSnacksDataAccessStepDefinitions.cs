using ArenaGestor.Business;
using ArenaGestor.BusinessInterface;
using ArenaGestor.DataAccess;
using ArenaGestor.DataAccess.Managements;
using ArenaGestor.DataAccessInterface;
using ArenaGestor.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TechTalk.SpecFlow;

namespace SpecflowTest
{
    [Binding]
    public class CompraSnacksDataAccessStepDefinitions
    {
        private DbContext context;
        private ISnackManagement _snackManagement;
        private Mock<ITicketManagement> _mockTicketManagement=new(MockBehavior.Strict);
        private Ticket ticket;
        private Snack snack1;
        private SnackPurchaseItem snackAmount1;
        private Snack snack2;
        private SnackPurchaseItem snackAmount2;
        private SnackPurchase purchase;
        private string errorMessage;
        private SnackPurchase result;
        private SnackPurchase expectedResult;

        public CompraSnacksDataAccessStepDefinitions()
        {
            BeforeTest();
        }
        public void BeforeTest()
        {
            context = CreateDataBase();
            _snackManagement = new SnackManagement(context);
            ticket = new()
            {
                TicketId = new Guid(),
            };
            snack1 = new()
            {
                SnackId = 1,
                Description = "Foo",
                Price = 10,
            };
            snack2 = new()
            {
                SnackId = 2,
                Description = "Fi",
                Price = 77,
            };
            snackAmount1 = new() {Snack=snack1, Amount = 2};
            snackAmount2 = new() {Snack = snack2, Amount =3};
            purchase = new()
            {
                TicketId = ticket.TicketId
            };
        }

        private DbContext CreateDataBase()
        {
            context = CreateDbContext();
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

        [Given(@"I have selected a \(non-empty\) set of snacks")]
        public void GivenIHaveSelectedANon_EmptySetOfSnacks()
        {
            purchase.Snacks = new[] { snackAmount1, snackAmount2};
            purchase.TotalPrice = snackAmount1.Amount + snackAmount2.Amount;
        }

        [Given(@"I have selected a quantity greater than (.*) for each selected snack")]
        public void GivenIHaveSelectedAQuantityGreaterThanForEachSelectedSnack(int p0)
        {
            snackAmount1 = new() { Snack = snack1, Amount = 2 };
            snackAmount2 = new() { Snack = snack2, Amount = 3 };
        }

        [When(@"I press the Confirm snack purchase button")]
        public void WhenIPressTheConfirmSnackPurchaseButton()
        {
            _snackManagement.InsertSnackPurchase(purchase);
        }

        

        [Then(@"the purchase is completed successfully")]
        public void ThenThePurchaseIsCompletedSuccessfully()
        {
            SnackPurchase result = _snackManagement.GetPurchaseById(purchase.TicketId);
            Assert.AreEqual(result, purchase);
        }
    }
}
