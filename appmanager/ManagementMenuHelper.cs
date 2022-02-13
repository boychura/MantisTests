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
    public class ManagementMenuHelper : BaseHelper
    {
        private string baseURL;
        public ManagementMenuHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToMainPage()
        {
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToSettings()
        {
            driver.FindElement(By.CssSelector("i.fa-gears")).Click();
        }

        public void OpenProjectsTab()
        {
            driver.FindElement(By.CssSelector(".nav-tabs li:nth-child(3)")).Click();
        }
    }
}
