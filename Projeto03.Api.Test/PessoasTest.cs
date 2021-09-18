using Bogus;
using FluentAssertions;
using Newtonsoft.Json;
using Projeto03.Api.Test.Helpers;
using Projeto03.Core.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Projeto03.Api.Test
{
    public class PessoasTest
    {
        private readonly string _endpoint;
        private readonly Faker _faker;

        public PessoasTest()
        {
            _endpoint = "api/pessoas";
            _faker = new Faker("pt_BR");
        }

        [Fact]
        public async Task Test_Post_Pessoas_Return_Ok()
        {
            var client = HttpClientHelper.Create();

            var model = new PessoaCreateModel
            {
                PrimeiroNome = _faker.Person.FirstName,
                Sobrenome = _faker.Person.LastName,
                Email = _faker.Person.Email
            };

            var request = RequestHelper.Create(model);
            var response = await client.PostAsync(_endpoint, request);

            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Test_Put_Pessoas_Return_Ok()
        {
            var pessoas = await Test_GetAll_Pessoas_Return_Ok();

            var client = HttpClientHelper.Create();

            var model = new PessoaUpdateModel
            {
                Id = pessoas.Last().Id,
                PrimeiroNome = _faker.Person.FirstName,
                Sobrenome = _faker.Person.LastName,
                Email = _faker.Person.Email
            };

            var request = RequestHelper.Create(model);
            var response = await client.PutAsync(_endpoint, request);

            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Test_Delete_Pessoas_Return_Ok()
        {
            var pessoas = await Test_GetAll_Pessoas_Return_Ok();

            var client = HttpClientHelper.Create();
            var response = await client.DeleteAsync($"{_endpoint}/{pessoas.First().Id}");

            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task<List<PessoaGetModel>> Test_GetAll_Pessoas_Return_Ok()
        {
            var client = HttpClientHelper.Create();
            var response = await client.GetAsync(_endpoint);

            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            var result = JsonConvert.DeserializeObject<List<PessoaGetModel>>
                (response.Content.ReadAsStringAsync().Result);

            return result;
        }

        [Fact]
        public async Task Test_GetById_Pessoas_Return_Ok()
        {
            var pessoas = await Test_GetAll_Pessoas_Return_Ok();

            var client = HttpClientHelper.Create();
            var response = await client.GetAsync($"{_endpoint}/{pessoas.First().Id}");

            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);
        }
    }
}
