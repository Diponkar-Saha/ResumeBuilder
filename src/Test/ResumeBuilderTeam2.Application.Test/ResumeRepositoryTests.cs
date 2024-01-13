using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVBuilder.Application.features.ResumeInterfaces;
using CVBuilder.Domain.CVEntites;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ResumeBuilderTeam2.Application.Test
{

    [TestFixture]
    public class ResumeRepositoryTests
    {
        private Mock<IResumeRepository> _resumeRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _resumeRepositoryMock = new Mock<IResumeRepository>();
        }

        [Test]
        public async Task GetCVByUserId_ValidUserId_ReturnsCV()
        {
      
            Guid userId = Guid.NewGuid();
            int templateId = 1;
            Resume expectedCV = new Resume { UserId = userId, ResumeTemplteId = templateId, ResumeName = "Test CV" };

            _resumeRepositoryMock.Setup(x => x.GetCVByUserId(userId, templateId))
                .ReturnsAsync(expectedCV);

            var repository = _resumeRepositoryMock.Object;

            var result = await repository.GetCVByUserId(userId, templateId);

         
            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(expectedCV));
        }

        [Test]
        public async Task UpdateCVByUserIdAndTempId_ValidCV_ReturnsTrue()
        {
    
            Resume cv = new Resume { UserId = Guid.NewGuid(), ResumeTemplteId = 1, ResumeName = "Test CV" };

            _resumeRepositoryMock.Setup(x => x.UpdateCVByUserIdAndTempId(cv))
                .ReturnsAsync(true);

            var repository = _resumeRepositoryMock.Object;


            var result = await repository.UpdateCVByUserIdAndTempId(cv);

        
            Assert.IsTrue(result);
        }

        [Test]
        public async Task DeleteResumeData_ValidCV_ReturnsTrue()
        {
            
            Resume cv = new Resume { UserId = Guid.NewGuid(), ResumeTemplteId = 1, ResumeName = "Test CV" };

            _resumeRepositoryMock.Setup(x => x.DeleteResumeData(cv))
                .ReturnsAsync(true);

            var repository = _resumeRepositoryMock.Object;

            var result = await repository.DeleteResumeData(cv);

      
            Assert.IsTrue(result);
        }
    }

}
