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

            List<ProjectData> oldProjects = app.Project.GetAllProjects();
            ProjectData existingProject = oldProjects.Find(x => x.Name == newProject.Name);
            if (existingProject != null)
            {
                app.Api.DeleteProject(new AccountData("administrator", "root"), newProject);
            }

            app.Project.Create(newProject);
            List<ProjectData> newProjects = app.Project.GetAllProjects();
            Assert.AreEqual((oldProjects.Count + 1), newProjects.Count);
        }
    }
}
