using WebApplication1.Repository;
using System.Collections.Generic;
using WebApplication1.Services;
using System.Threading.Tasks;
using WebApplication1.Models;
using NUnit.Framework;
using System.Linq;
using Microsoft.Extensions.Logging;
using Moq;

namespace TestProject1
{

    public class ProfileHandlerTests
    {
        private Profile _testProfile;
        private Profile _testProfile2;
        private Mock<IRepository<Profile>> _mockRepository;
        private Mock<ILogger<ProfileHandler>> _mockLogger;

        [SetUp]
        public void Setup()
        {
            _testProfile = new Profile()
            {
                Id = 1,
                ProfileName = "ProfileNameTest"
            };
            _testProfile2 = new Profile()
            {
                Id = 2,
                ProfileName = "ProfileNameTest2"
            };
            
            _mockRepository = new Mock<IRepository<Profile>>();
            _mockLogger = new Mock<ILogger<ProfileHandler>>();
        }

        [Test]
        public async Task TestCreateProfile()
        {
            var profileHandler = new ProfileHandler(_mockRepository.Object, _mockLogger.Object);

            var response = await profileHandler.CreateProfile(_testProfile);

            Assert.AreEqual(_testProfile.Id, response.Data.Id);
            Assert.AreEqual(_testProfile.ProfileName, response.Data.ProfileName);
        }

        [Test]
        public async Task TestGetProfileById()
        {
            _mockRepository.Setup(pr => pr.GetById(1)).ReturnsAsync(_testProfile);
            
            var profileHandler = new ProfileHandler(_mockRepository.Object, _mockLogger.Object);

            var response = await profileHandler.GetProfileById(1);
            
            Assert.AreEqual(_testProfile.Id, response.Data.Id);
            Assert.AreEqual(_testProfile.ProfileName, response.Data.ProfileName);
        }

        [Test]
        public async Task TestGetAllProfiles()
        {
            _mockRepository.Setup(rp => rp.GetAll()).ReturnsAsync(
                new List<Profile>()
                {
                    _testProfile, _testProfile2
                });

            var profileHandler = new ProfileHandler(_mockRepository.Object, _mockLogger.Object);

            var response = await profileHandler.GetAllProfiles();
            
            Assert.AreEqual(2, response.Data.Count);
            Assert.AreEqual(_testProfile.ProfileName, response.Data.FirstOrDefault(p=> p.Id == _testProfile.Id)?.ProfileName);
        }
    }
}