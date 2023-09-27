using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SemesterTest;
namespace TestProject1
{
    public class testFolder
    {
        private Folder folderTest;
        [SetUp]
        public void SetUp()
        {
            folderTest = new Folder("hi");
        }
        [Test]
        public void TestSize()
        {

        }
    }
}
