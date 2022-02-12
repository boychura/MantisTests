using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace MantisTests
{
    public class ProjectManagementHelper : BaseHelper
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ProjectManagementHelper Create(ProjectData newProject)
        {
            OpenProjectsPage();
            InitProjectCreation();
            FillProjectForm(newProject);
            SubmitProjectCreation();

            return this;
        }

        public ProjectManagementHelper Delete(int index, ProjectData project)
        {
            OpenProjectsPage();
            StartCheckProjects(index, project);
            SelectProject(index);
            InitProjectDeleting();
            SubmitProjectDeleting();

            return this;
        }

        private void SubmitProjectDeleting()
        {
            driver.FindElement(By.CssSelector(".btn.btn-primary.btn-white")).Click();
        }

        private void InitProjectDeleting()
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/div/div[2]/div/form/fieldset/input[3]")).Click();
        }

        private void OpenProjectsPage()
        {
            manager.Navigator.GoToMainPage();
            manager.Navigator.GoToSettings();
            manager.Navigator.OpenProjectsTab();
        }

        public void SubmitProjectCreation()
        {
            driver.FindElement(By.CssSelector(".btn.btn-primary.btn-white.btn-round")).Click();
        }

        public void FillProjectForm(ProjectData newProject)
        {
            Type(By.Id("project-name"), newProject.Name);
            Type(By.Id("project-description"), newProject.Description);
        }

        public void InitProjectCreation()
        {
            driver.FindElements(By.CssSelector(".single-button-form.form-inline.form-inline"))[0].Click();
        }

        public ProjectManagementHelper StartCheckProjects(int index, ProjectData project)
        {
            if (!IsProjectExist(index))
            {
                Create(project);
            }
            return this;
        }


        private void SelectProject(int index)
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr[1]/td[" + (index + 1) + "]/a")).Click();
        }
        private bool IsProjectExist(int index)
        {
            return IsElementPresent(By.XPath("/html/body/div[2]/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr[1]/td[" + (index + 1) + "]/a"));
        }
    }
}
