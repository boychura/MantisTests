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

            List<ProjectData> oldProjects = app.Project.GetAllProjects();
            ProjectData existingProject = oldProjects.Find(x => x.Name == newProject.Name);
            if (existingProject == null)
            {
                app.Project.Create(newProject);
            }

            app.Project.Delete(0, newProject);
            List<ProjectData> newProjects = app.Project.GetAllProjects();
            Assert.AreEqual((oldProjects.Count - 1), newProjects.Count);
        }
    }
}
