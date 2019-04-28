using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using MyImages.Models;
using MyImages.Repository;
using MyImages.Services;
using MyImages.Uow;
using System.IO;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using MyImages.Data;
//Microsoft.VisualStudio.QualityTools.UnitTestFrameWork 
//at C:\Program Files\Microsoft Visual Studio 10.0\Common7\IDE\PublicAssemblies\

namespace MyImagesUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private IImageServices service;
        private ImageUow uow;

        [TestInitialize]
        public void TestInitalize()
        {
            service = new ImageServices();
            uow = new ImageUow();

            /*  
             public static T GenerateStub<T>(params object[] argumentsForConstructor) where T : class;
            */
            //uow.Repository = new MockRepository.GenerateStub<IRepository<ImageModel>>(new ContextApp());

        }

        [TestMethod]
        public void TestReturnOfRenderImageIsByteArray()
        {
            //arrange
            byte[] array = File.ReadAllBytes("Captura.png");

            //act
            var result = service.RenderImage200PX(array, 100, 100);

            //arrange
            Xunit.Assert.IsType(typeof(byte[]), result);
        }

        [TestMethod]
        public void TestValidPngFile()
        {
            //arrange
            FormFile file = buildFile("Captura.png");

            //act
            var result = service.ValidPngFile(file);

            //arrange
            Xunit.Assert.True(result);
        }

        [TestMethod]
        public void TestNotValidJpgFile()
        {
            //arrange
            FormFile file = buildFile("Captura2.jpg");

            //act
            var result = service.ValidPngFile(file);

            //arrange
            Xunit.Assert.False(result);
        }

        [TestMethod]
        public void TestNumberOfImages()
        {
            //uow.Repository.Stub(x => x.FindAll().Count()).Return(8);
            //Assert.IsTrue(service.ValidNumberOfImagesUploaded(uow));
        }


        private FormFile buildFile(string name)
        {
            using (var stream = File.OpenRead(name))
            {
                return new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name));
            }
        }

    }
}
