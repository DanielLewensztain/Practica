using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticaExamen1.Controllers;
using PracticaExamen1.Models;

namespace UnitTestPractica1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodGet()
        {
            //arrange
            lewensztainsController controlador = new lewensztainsController();
            //act
            var lista = controlador.Getlewensztains();
            //assert
            Assert.IsNotNull(lista);   
        }
        [TestMethod]
        public void TestMethodPost()
        {
            //arrange
            lewensztainsController controlador = new lewensztainsController();
            lewensztain esperado = new lewensztain()
            {
                lewensztainID = 1,
                Friendoflewensztain = "daniel",
                birthdate = DateTime.Now,
                email = "daniel@upsa.com",
                place = placeType.kfc
            };
            //act
            IHttpActionResult actionResult = controlador.Postlewensztain(esperado);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<lewensztain>;
            //assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.IsNotNull(createdResult.RouteValues["id"]);
        }
        [TestMethod]
        public void TestMethodPut()
        {
            //arrange
            lewensztainsController controlador = new lewensztainsController();
            lewensztain esperado = new lewensztain()
            {
                lewensztainID = 1,
                Friendoflewensztain = "daniel",
                birthdate = DateTime.Now,
                email = "daniel@upsa.com",
                place = placeType.kfc
            };
            //act
            IHttpActionResult actionResult = controlador.Postlewensztain(esperado);
            var result = controlador.Putlewensztain(esperado.lewensztainID, esperado) as StatusCodeResult;
            //assert
            Assert.IsNotNull(esperado);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }
        [TestMethod]
        public void TestMethodDelete()
        {
            //arrange
            lewensztainsController controlador = new lewensztainsController();
            lewensztain esperado = new lewensztain()
            {
                lewensztainID = 1,
                Friendoflewensztain = "daniel",
                birthdate = DateTime.Now,
                email = "daniel@upsa.com",
                place = placeType.kfc
            };
            //act
            IHttpActionResult actionResult = controlador.Postlewensztain(esperado);
            IHttpActionResult ActionResultDelete = controlador.Deletelewensztain(esperado.lewensztainID);
            //accert
            Assert.IsInstanceOfType(ActionResultDelete, typeof(OkNegotiatedContentResult<lewensztain>));




        }
    }

}
