//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// <copyright company="SoftwareOne">Copyright(c) 2023 All Rights Reserved.</copyright>
// <author>Jessica Antía Hortúa</author>
// <email>mailto:jessica.antia@softwareone.com</email>
// <summary>Test class for the general init class [Program]</summary>
namespace SoftwareOne.BaseLine.TestApplication
{
    using Microsoft.AspNetCore.Mvc.Testing;
    using SoftwareOne.BaseLine.Api;

    public class ProgramTest
    {
        private const string REQUEST_URI = "/api/v1/Category";
        private const string AUTH_HEADER = "Authorization";
        private const string TOKEN = "123456";

        [Fact]
        public async void programWithoutAuthorization() {
            using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();

            var response = await client.GetAsync(REQUEST_URI);

            Assert.NotNull(response);
            Assert.False(response.IsSuccessStatusCode);
        }

        [Fact]
        public async void programWithToken() {
            using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            client.DefaultRequestHeaders.Add(AUTH_HEADER, TOKEN);

            var response = await client.GetAsync(REQUEST_URI);

            Assert.NotNull(response);
            Assert.False(response.IsSuccessStatusCode);
        }
    }
}