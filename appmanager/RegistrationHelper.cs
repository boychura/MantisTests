using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

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
            String url = GetConfirmationUrl(account);
            FillPasswordForm(url, account);
            SubmitPasswordForm();
        }

        private string GetConfirmationUrl(AccountData account)
        {
            String message = manager.Mail.GetLastMail(account);
            Match match = Regex.Match(message, @"http://\S*");
            return match.Value;
        }

        private void FillPasswordForm(string url, AccountData account)
        {
            driver.Url = url;
            driver.FindElement(By.Id("password")).SendKeys(account.Password);
            driver.FindElement(By.Id("password_confirm")).SendKeys(account.Password);
        }

        private void SubmitPasswordForm()
        {
            driver.FindElement(By.CssSelector(".btn")).Click();
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
