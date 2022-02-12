using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MantisTests
{
    [TestFixture]
    public class DeleteProject : AuthTestBase
    {
        [Test]
        public void TestDeleteProject()
        {
            ProjectData newProject = new ProjectData("deleted_project", "deleted_description");

            app.Project.Delete(0, newProject);
            app.Navigator.GoToMainPage();
        }
    }
}
