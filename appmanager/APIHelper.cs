﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTests
{
    public class APIHelper : BaseHelper
    {
        public APIHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public void DeleteProject(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            client.mc_project_delete(account.Name, account.Password, project.Id);
        }
        public void CreateProject(AccountData account, ProjectData projectData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData project = new Mantis.ProjectData();
            project.name = projectData.Name;
            project.description = projectData.Description;
            project.status = new Mantis.ObjectRef();
            project.status.name = projectData.Status;
            client.mc_project_add(account.Name, account.Password, project);
        }

        public ProjectData GetAllProjectsApi(AccountData account)
        {
            ProjectData projects = new ProjectData();
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData projectData = new Mantis.ProjectData();
            projectData.name = projects.Name;
            projectData.description = projects.Description;
            projectData.id = projects.Id;
            //projects = client.mc_projects_get_user_accessible(account.Name, account.Password);

            return projects;
        }
    }
}
