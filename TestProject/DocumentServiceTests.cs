using AdministrationAPI.Contracts.Requests;
using AdministrationAPI.Contracts.Responses;
using AdministrationAPI.Controllers;
using AdministrationAPI.Data;
using AdministrationAPI.Models;
using AdministrationAPI.Models.Voucher;
using AdministrationAPI.Services;
using AdministrationAPI.Services.Interfaces;
using AutoFixture;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Microsoft.AspNetCore.Components.Routing;

namespace TestProject
{
    public class DocumentServiceTests
    {


        [Fact]
        public void GetAllDocuments_ReturnsListOfDocuments()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            var contextMock = new Mock<AppDbContext>();
            var documentService = new DocumentService(configurationMock.Object, contextMock.Object);

            var expectedDocuments = new List<Document> { new Document(), new Document(), new Document() };

            contextMock.Setup(c => c.Documents.ToList()).Returns(expectedDocuments);

            // Act
            var result = documentService.GetAllDocuments();

            // Assert
            Assert.Equal(expectedDocuments, result);
        }


        [Fact]
        public void GetDocument_ExistingId_ReturnsDocument()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            var contextMock = new Mock<AppDbContext>();
            var documentService = new DocumentService(configurationMock.Object, contextMock.Object);

            var documentId = 1;
            var expectedDocument = new Document { Id = documentId };

            contextMock.Setup(c => c.Documents.FirstOrDefault(d => d.Id == documentId)).Returns(expectedDocument);

            // Act
            var result = documentService.GetDocument(documentId);

            // Assert
            Assert.Equal(expectedDocument, result);
        }

        [Fact]
        public void DocumentDelete_ExistingId_DeletesDocumentAndReturnsTrue()
        {
            // Arrange
            var configurationMock = new Mock<IConfiguration>();
            var contextMock = new Mock<AppDbContext>();
            var documentService = new DocumentService(configurationMock.Object, contextMock.Object);

            var documentId = 1;
            var existingDocument = new Document { Id = documentId };

            contextMock.Setup(c => c.Documents.FirstOrDefault(d => d.Id == documentId)).Returns(existingDocument);

            // Act
            var result = documentService.DocumentDelete(documentId);

            // Assert
            Assert.True(result); // Document should be deleted and true should be returned
            contextMock.Verify(c => c.SaveChanges(), Times.Once); // Ensure that SaveChanges method is called once
        }



    }
}
