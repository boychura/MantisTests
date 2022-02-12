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
    public class LoginHelper : BaseHelper
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }
        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }

                LogOut();
            }
            Type(By.Id("username"), account.Name);
            driver.FindElement(By.CssSelector(".btn")).Click();
            Type(By.Id("password"), account.Password);
            driver.FindElement(By.CssSelector(".btn")).Click();
        }
        public void LogOut()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.CssSelector("i.fa-angle-down")).Click();
                driver.FindElement(By.CssSelector("i.fa-sign-out")).Click();
            }
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.CssSelector("i.fa-sign-out"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggedUserName() == account.Name;
        }

        private string GetLoggedUserName()
        {
            string text = driver.FindElement(By.CssSelector("span.user-info")).Text;
            return text;
        }
    }
}
