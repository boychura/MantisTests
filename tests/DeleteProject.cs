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

            List<ProjectData> oldProjects = app.Project.GetAllProjects();
            ProjectData existingProject = oldProjects.Find(x => x.Name == newProject.Name);
            if (existingProject == null)
            {
                app.Api.CreateProject(user,newProject);
            }

            app.Api.DeleteProject(user, newProject);
            List<ProjectData> newProjects = app.Project.GetAllProjects();
            Assert.AreEqual((oldProjects.Count - 1), newProjects.Count);
        }
    }
}
