using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SimpleBrowser.WebDriver;

namespace MantisTests
{
    public class AdminHelper : BaseHelper
    {
        private string baseURL;
        public AdminHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public List<AccountData> GetAllAccounts()
        {
            List<AccountData> accounts = new List<AccountData>();

            //IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseURL + "/manage_user_page.php";
            IList<IWebElement> rows = driver.FindElements(By.CssSelector("table tbody tr"));
            foreach (IWebElement row in rows)
            {
                IWebElement link = row.FindElement(By.TagName("a"));
                string name = link.Text;
                string href = link.GetAttribute("href");
                Match m = Regex.Match(href, @"\d+$");
                string id = m.Value;

                accounts.Add(new AccountData()
                {
                    Name = name,
                    Id = id
                });
            }

            return accounts;
        }
        public void DeleteAccount(AccountData account)
        {
            //IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseURL + "/manage_user_edit_page.php?user_id=" + account.Id;
            driver.FindElement(By.CssSelector("input[value='Delete user']")).Click();
            driver.FindElement(By.CssSelector(".btn-white")).Click();
        }

        //public IWebDriver OpenAppAndLogin()
        //{
            //IWebDriver driver = new SimpleBrowserDriver();
            //driver.Url = baseURL + "/login_page.php";
            //Type(By.Id("username"), "administrator");
            //driver.FindElement(By.CssSelector(".btn")).Click();
            //Type(By.Id("password"), "1234");
            //driver.FindElement(By.CssSelector(".btn")).Click();
        //}
    }
}
