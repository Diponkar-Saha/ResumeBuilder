using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVBuilder.Application.features.Services;
using CVBuilder.Domain.CVEntites;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace ResumeBuilderTeam2.Application.Test
{
 

    [TestFixture]
    public class ResumeTemplateServiceTests
    {
        private Mock<IResumeTemplateService> _resumeTemplateServiceMock;

        [SetUp]
        public void Setup()
        {
            _resumeTemplateServiceMock = new Mock<IResumeTemplateService>();
        }

        [Test]
        public void AddTemplate_ValidTemplate_Success()
        {
     
            string templateName = "Sample Template";
            string templateThumbnail = "thumbnail.jpg";

            _resumeTemplateServiceMock.Setup(x => x.AddTemplate(templateName, templateThumbnail));

            var service = _resumeTemplateServiceMock.Object;

          
            service.AddTemplate(templateName, templateThumbnail);

   
            _resumeTemplateServiceMock.Verify(x => x.AddTemplate(templateName, templateThumbnail), Times.Once);
        }

        [Test]
        public void DeleteTemplate_ValidId_Success()
        {
     
            int templateId = 1;

            _resumeTemplateServiceMock.Setup(x => x.DeleteTemplate(templateId));

            var service = _resumeTemplateServiceMock.Object;

     
            service.DeleteTemplate(templateId);

            _resumeTemplateServiceMock.Verify(x => x.DeleteTemplate(templateId), Times.Once);
        }

        [Test]
        public void GetTemplate_ValidId_ReturnsTemplate()
        {
      
            int templateId = 1;
            ResumeTemplate expectedTemplate = new ResumeTemplate { Id = templateId, TemplateName = "Sample Template" };

            _resumeTemplateServiceMock.Setup(x => x.GetTemplate(templateId))
                .Returns(expectedTemplate);

            var service = _resumeTemplateServiceMock.Object;

      
            var result = service.GetTemplate(templateId);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedTemplate, result);
        }

        [Test]
        public void GetTemplates_ReturnsTemplateList()
        {
        
            List<ResumeTemplate> expectedTemplates = new List<ResumeTemplate>
        {
            new ResumeTemplate { Id = 1, TemplateName = "Template 1" },
            new ResumeTemplate { Id = 2, TemplateName = "Template 2" }
        };

            _resumeTemplateServiceMock.Setup(x => x.GetTemplates())
                .Returns(expectedTemplates);

            var service = _resumeTemplateServiceMock.Object;

            var result = service.GetTemplates();

     
            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(expectedTemplates, result);
        }

        [Test]
        public void UpdateTemplate_ValidId_Success()
        {
     
            int templateId = 1;
            string templateName = "Updated Template";
            string templateThumbnail = "updated_thumbnail.jpg";

            _resumeTemplateServiceMock.Setup(x => x.UpdateTemplate(templateId, templateName, templateThumbnail));

            var service = _resumeTemplateServiceMock.Object;

       
            service.UpdateTemplate(templateId, templateName, templateThumbnail);

    
            _resumeTemplateServiceMock.Verify(x => x.UpdateTemplate(templateId, templateName, templateThumbnail), Times.Once);
        }
    }

}
