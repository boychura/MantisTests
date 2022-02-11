using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace MantisTests
{
    public class RegistrationHelper : BaseHelper
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();
        }

        private void OpenRegistrationForm()
        {
            driver.FindElement(By.CssSelector("a.back-to-login-link")).Click();
        }

        private void SubmitRegistration()
        {
            driver.FindElement(By.CssSelector(".btn")).Click();
        }

        private void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Id("username")).SendKeys(account.Name);
            driver.FindElement(By.Id("email-field")).SendKeys(account.Email);
        }

        private void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantis/login_page.php";
        }
    }
}
