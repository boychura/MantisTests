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
            AccountData user = new AccountData("administrator", "root");

            List<ProjectData> oldProjects = app.Api.GetAllProjectsApi(user);
            if (oldProjects.Count == 0)
            {
                app.Api.CreateProject(user,newProject);
            }
            oldProjects = app.Api.GetAllProjectsApi(user);

            //app.Api.DeleteProject(user, newProject);
            app.Project.Delete(0, newProject);
            List<ProjectData> newProjects = app.Api.GetAllProjectsApi(user);
            Assert.AreEqual((oldProjects.Count - 1), newProjects.Count);
        }
    }
}
