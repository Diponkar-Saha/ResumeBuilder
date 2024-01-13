using CVBuilder.Application.features.ResumeInterfaces;
using CVBuilder.Domain.Entities;
using Moq;

namespace ResumeBuilderTeam2.Application.Test
{


    public class CoverLetterRepositoryTests
    {
        private Mock<ICoverLetterRepository> _coverLetterRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _coverLetterRepositoryMock = new Mock<ICoverLetterRepository>();
        }

        [Test]
        public async Task GetCoverLetterByUserId_ValidUserId_ReturnsCoverLetter()
        {
      
            Guid userId = Guid.NewGuid();
            UserCoverLetter expectedCoverLetter = new UserCoverLetter
            {
                UserId = userId,
                Heading = "Sample Heading",
                Date = DateTime.Now,
                HiringBody = "Sample Hiring Body Text",
                CompanyAddress = "Sample Company Address",
                Email = "sample@example.com",
                Body = "Sample Cover Letter Body Text",
                Footer = "Sample Cover Letter Footer Text",
                Id = 1 
            };

            _coverLetterRepositoryMock.Setup(x => x.GetCoverLetterByUserId(userId))
                .ReturnsAsync(expectedCoverLetter);

            var coverLetterRepository = _coverLetterRepositoryMock.Object;

           
            var result = await coverLetterRepository.GetCoverLetterByUserId(userId);

          
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedCoverLetter, result);
        }

        [Test]
        public async Task GetCoverLetterByUserId_InvalidUserId_ReturnsNull()
        {
          
            Guid userId = Guid.NewGuid();

            _coverLetterRepositoryMock.Setup(x => x.GetCoverLetterByUserId(userId)); 

            var coverLetterRepository = _coverLetterRepositoryMock.Object;

           
            var result = await coverLetterRepository.GetCoverLetterByUserId(userId);

            
            Assert.IsNull(result);
        }

        [Test]
        public async Task UpdateCoverLetterByUserId_ValidCoverLetter_ReturnsTrue()
        {
            
            UserCoverLetter coverLetter = new UserCoverLetter
            {
                UserId = Guid.NewGuid(),
                Heading = "Sample Heading Update",
               
                Date = DateTime.Now,
                HiringBody = "Sample Hiring Body Text Update",
                CompanyAddress = "Sample Company Address Update",
                Email = "sample@example.com Update",
                Body = "Sample Cover Letter Body Text Update",
                Footer = "Sample Cover Letter Footer Text Update",

            };

            _coverLetterRepositoryMock.Setup(x => x.UpdateCoverLetterByUserId(coverLetter))
                .ReturnsAsync(true);

            var coverLetterRepository = _coverLetterRepositoryMock.Object;

          
            var result = await coverLetterRepository.UpdateCoverLetterByUserId(coverLetter);

          
            Assert.IsTrue(result);
        }

        [Test]
        public async Task UpdateCoverLetterByUserId_InvalidCoverLetter_ReturnsFalse()
        {
           
            UserCoverLetter coverLetter = new UserCoverLetter
            {
                UserId = Guid.NewGuid(),
                Heading = "Sample Heading",
                Date = DateTime.Now,
                HiringBody = "Sample Hiring Body Text Update",
                CompanyAddress = "Sample Company Address Update",
                Email = "sample@example.com Update",
                Body = "Sample Cover Letter Body Text Update",
                Footer = "Sample Cover Letter Footer Text Update",

            };

            _coverLetterRepositoryMock.Setup(x => x.UpdateCoverLetterByUserId(coverLetter))
                .ReturnsAsync(false); 

            var coverLetterRepository = _coverLetterRepositoryMock.Object;

          
            var result = await coverLetterRepository.UpdateCoverLetterByUserId(coverLetter);

           
            Assert.IsFalse(result);
        }

        [Test]
        public async Task DeleteCoverLetter_ValidCoverLetter_ReturnsTrue()
        {
           
            UserCoverLetter coverLetter = new UserCoverLetter
            {
                UserId = Guid.NewGuid(),
                Heading = "Sample Heading",
                Date = DateTime.Now,
                HiringBody = "Sample Hiring Body Text Update",
                CompanyAddress = "Sample Company Address Update",
                Email = "sample@example.com Update",
                Body = "Sample Cover Letter Body Text Update",
                Footer = "Sample Cover Letter Footer Text Update",
            };

            _coverLetterRepositoryMock.Setup(x => x.DeleteCoverLetter(coverLetter))
                .ReturnsAsync(true);

            var coverLetterRepository = _coverLetterRepositoryMock.Object;

          
            var result = await coverLetterRepository.DeleteCoverLetter(coverLetter);

           
            Assert.IsTrue(result);
        }

        [Test]
        public async Task DeleteCoverLetter_InvalidCoverLetter_ReturnsFalse()
        {
           
            UserCoverLetter coverLetter = new UserCoverLetter
            {
                UserId = Guid.NewGuid(),
                Heading = "Sample Heading",
                Date = DateTime.Now,
                HiringBody = "Sample Hiring Body Text Update",
                CompanyAddress = "Sample Company Address Update",
                Email = "sample@example.com Update",
                Body = "Sample Cover Letter Body Text Update",
                Footer = "Sample Cover Letter Footer Text Update",
            };

            _coverLetterRepositoryMock.Setup(x => x.DeleteCoverLetter(coverLetter))
                .ReturnsAsync(false); 

            var coverLetterRepository = _coverLetterRepositoryMock.Object;

            
            var result = await coverLetterRepository.DeleteCoverLetter(coverLetter);

          
            Assert.IsFalse(result);
        }
    }


}
