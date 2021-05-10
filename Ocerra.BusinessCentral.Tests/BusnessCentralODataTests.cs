using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ocerra.BusinessCentral.Api;
using System;
using System.Linq;

namespace Ocerra.BusinessCentral.Tests
{
    [TestClass]
    public class BusnessCentralODataTests
    {
        //url in format https://api.businesscentral.dynamics.com/v2.0/Production/api/v2.0/companies(00000000-0000-0000-0000-000000000000)/ - where 00000000-0000-0000-0000-000000000000 is your BC company ID
        private Uri url = new Uri("");

        //access token using ConfidentialClientApplicationBuilder and AcquireTokenByAuthorizationCode https://docs.microsoft.com/en-us/azure/active-directory/develop/scenario-web-app-call-api-app-configuration 
        private string accessToken = "";

        [TestMethod]
        public void ReadContacts()
        {
            var odata = new BusinessCentralOData(url, accessToken);

            var response = odata.Contacts.Take(3).ToList();

            Assert.IsNotNull(response);
            Assert.AreEqual(3, response.Count);
        }
    }
}
