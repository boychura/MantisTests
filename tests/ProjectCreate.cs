using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MantisTests
{
    [TestFixture]
    public class ProjectCreate : AuthTestBase
    {
        [Test]
        public void TestProjectCreation()
        {
            ProjectData newProject = new ProjectData("Project" + DateTime.Now, "a lot of description1");

            app.Project.Create(newProject);
            app.Navigator.GoToMainPage();
        }
    }
}
