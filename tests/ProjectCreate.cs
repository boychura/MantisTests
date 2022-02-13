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
            ProjectData newProject = new ProjectData("Project" + DateTime.Now, "a lot of description1")
            {
                Status = "release"
            };
            AccountData user = new AccountData("administrator", "root");

            List<ProjectData> oldProjects = app.Project.GetAllProjects();
            ProjectData existingProject = oldProjects.Find(x => x.Name == newProject.Name);
            if (existingProject != null)
            {
                app.Api.DeleteProject(user, newProject);
            }

            //app.Project.Create(newProject);
            app.Api.CreateProject(user, newProject);
            List<ProjectData> newProjects = app.Project.GetAllProjects();
            Assert.AreEqual((oldProjects.Count + 1), newProjects.Count);
        }
    }
}
