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
            ProjectData newProject = new ProjectData("deleted_project11", "deleted_description")
            {
                Id = "3"
            };
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            IssueData issueData = new IssueData()
            {
                Category = "general",
                Summary = "asdasdas",
                Description = "sadasdasdasdasdasdasd"

            };
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Console.WriteLine(client.mc_projects_get_user_accessible(account.Name, account.Password));
        }
    }
}
