using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MantisTests
{

    [TestFixture]
    public class TestTes : TestBase
    {
        [Test]
        public void Test1()
        {
            ProjectData newProject = new ProjectData("deleted_project", "deleted_description")
            {
                Id = "6"
            };
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            app.Api.DeleteProject(account, newProject);
        }
    }
}
