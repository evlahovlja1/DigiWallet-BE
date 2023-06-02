using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdministrationAPI.Data;
using AdministrationAPI.Models;
using AdministrationAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AdministrationAPI.Contracts.Requests;
using AdministrationAPI.Contracts.Responses;
using AdministrationAPI.Controllers;
using Moq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Routing;
using Moq.EntityFrameworkCore;
using Xunit.Abstractions;
using AdministrationAPI.Services.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using AdministrationAPI.Contracts.Requests.Users;
using AutoMapper;
using Castle.Components.DictionaryAdapter.Xml;


namespace AdministrationAPI.Tests.Models
{
    public class AccountCreationRequestTests
    {

        [Fact]
        public void Approved_DefaultValue_IsNull()
        {
            // Arrange
            var request = new AccountCreationRequest();

            // Act

            // Assert
            Assert.Null(request.Approved);
        }

        [Fact]
        public void Currency_SetAndGetProperties_Match()
        {
            // Arrange
            var currency = new Currency { Id = "1", Name = "USD" };
            var request = new AccountCreationRequest { Currency = currency };

            // Act
            var result = request.Currency;

            // Assert
            Assert.Equal(currency, result);
        }

        [Fact]
        public void Description_SetAndGetProperties_Match()
        {
            // Arrange
            var description = "Test Description";
            var request = new AccountCreationRequest { Description = description };

            // Act
            var result = request.Description;

            // Assert
            Assert.Equal(description, result);
        }

        [Fact]
        public void RequestDocumentPath_SetAndGetProperties_Match()
        {
            // Arrange
            var path = "/path/to/document";
            var request = new AccountCreationRequest { RequestDocumentPath = path };

            // Act
            var result = request.RequestDocumentPath;

            // Assert
            Assert.Equal(path, result);
        }

        [Fact]
        public void Approved_SetAndGetProperties_Match()
        {
            // Arrange
            var approved = true;
            var request = new AccountCreationRequest { Approved = approved };

            // Act
            var result = request.Approved;

            // Assert
            Assert.Equal(approved, result);
        }



    }
}

