using AdministrationAPI.Contracts.Requests;
using AdministrationAPI.Data;
using AdministrationAPI.Models;
using AdministrationAPI.Models.Vendor;
using AdministrationAPI.Services;
using AutoMapper;
using Moq;
using Xunit.Abstractions;

namespace TestProject
{
    public class VendorTest
    {
        private User user;
        private readonly ITestOutputHelper _output;
        private Mock<AppDbContext> _context = new Mock<AppDbContext>();
        public VendorTest(ITestOutputHelper output)
        {
            _output = output;
            user = new User() { FirstName = "Testing", LastName = "User", UserName = "testingUser", NormalizedUserName = "TESTINGUSER", ConcurrencyStamp = "1", Email = "kfejzic1@etf.unsa.ba", NormalizedEmail = "KFEJZIC1@ETF.UNSA.BA", EmailConfirmed = true, PasswordHash = "AQAAAAIAAYagAAAAENao66CqvIXroh/6aTaoJ/uThFfjLemBtjLfuiJpP/NoWXkhJO/G8wspnWhjLJx9WQ==", PhoneNumber = "062229993", PhoneNumberConfirmed = true, Address = "Tamo negdje 1", TwoFactorEnabled = true, LockoutEnabled = false };

        }
        [Fact]
        public void CreateVendorTest()
        {
            var service = new VendorService(_context.Object);
            VendorCreateRequest req = new VendorCreateRequest{ Id=1, Name="Merkator", Address="Lozionicka", CompanyDetails="Detalji", Phone="033/222-333", Created=null, CreatedBy=user.Id, Modified=null, ModifiedBy=null, AssignedUserIds=new List<string>()};
            var created = service.Create(req);

            Assert.NotNull(created);
            Assert.True(created);
            _context.Verify(x => x.SaveChanges(), Times.Once);
            _context.Verify(x => x.Vendors.Add(It.IsAny<Vendors>()), Times.Once);            
        }

    }
}