using ArenaGestor.API.Controllers;
using ArenaGestor.API.Filters;
using ArenaGestor.APIContracts.Security;
using ArenaGestor.BusinessInterface;
using ArenaGestor.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ArenaGestor.APITest
{
    [TestClass]
    public class SecurityControllerTest
    {
        private Mock<ISecurityService> mock;
        private Mock<IUsersService> usersServiceMock;
        private Mock<IMapper> mockMapper;

        private Mock<IUsersService> usersMock;
        private SecurityController api;

        private SecurityLoginDto loginDto;
        private string randomToken;

        [TestInitialize]
        public void InitTest()
        {
            mock = new Mock<ISecurityService>(MockBehavior.Strict);
            usersServiceMock = new Mock<IUsersService>(MockBehavior.Strict);
            mockMapper = new Mock<IMapper>(MockBehavior.Strict);

            api = new SecurityController(mock.Object, usersServiceMock.Object, mockMapper.Object);

            randomToken = BusinessHelpers.StringGenerator.GenerateRandomToken(64);
            loginDto = new SecurityLoginDto()
            {
                Email = "test@test.com",
                Password = "12345"
            };
        }

        [TestMethod]
        public void LoginOk()
        {
            mock.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(randomToken);
            var result = api.Login(loginDto);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;

            mock.VerifyAll();
            Assert.AreEqual(StatusCodes.Status200OK, statusCode);
        }

        [TestMethod]
        public void LogoutOk()
        {
            mock.Setup(x => x.Logout(It.IsAny<string>()));
            var result = api.Logout(randomToken);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;

            mock.VerifyAll();
            Assert.AreEqual(StatusCodes.Status200OK, statusCode);
        }

        [TestMethod]
        public void Logout_ShouldHaveCorrectAuthorizationRoles()
        {
            // Arrange
            var methodInfo = typeof(SecurityController).GetMethod(nameof(SecurityController.Logout));

            // Act
            var authAttributes = methodInfo.GetCustomAttributes(typeof(AuthorizationFilter), true);
            var authFilter = authAttributes[0] as AuthorizationFilter;

            // Assert
            CollectionAssert.AreEquivalent(new[] { RoleCode.Administrador, RoleCode.Vendedor, RoleCode.Acomodador, RoleCode.Espectador, RoleCode.Artista }, authFilter.roles);
        }
    }
}


