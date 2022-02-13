using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MantisTests
{
    [TestFixture]
    public class DelTest
    {
        public void DeleteProject(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            client.mc_project_delete(account.Name, account.Password, project.Id);
        }
        [Test]
        public void DelTK()
        {
            ProjectData newProject = new ProjectData()
            {
                Id = "6"
            };
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            IssueData issueData = new IssueData()
            {
                Description = "asdasd",
                Category = "General",
                Summary = "asdasd"
            };

            DeleteProject(account, newProject);
        }
    }
}