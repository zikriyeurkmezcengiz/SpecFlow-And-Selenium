using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SkillShare
{
    public class AutoSkillShare
    {
        private IWebDriver _driver;

        public AutoSkillShare()
        {
            _driver = new ChromeDriver();
        }

        public void UploadCourse()
        {
            var loginPage = LoginPage.NavigateTo(_driver);
            loginPage.SignIn();

            var classpage = ClassPage.NewClass(_driver);
          
        }
    }
    public class ClassPage
    {
        private readonly IWebDriver _driver;

        private ClassPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public static ClassPage NewClass(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://www.skillshare.com/teach?via=teach-dropdown");
            var startClass = driver.FindElement(By.CssSelector("form.start-class-creation-form > button[type='submit']"));
            startClass.Click();
            
            return new ClassPage(driver);
        }
    }

    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public static LoginPage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://www.skillshare.com/login");
            return new LoginPage(driver);
        }

        public void SignIn()
        {
            FillCredentials();
            ClickSignIn();
        }

        private void ClickSignIn()
        {
            var submit = _driver.FindElement(By.CssSelector("input[type='submit']"));
            submit.Click();
        }

        private void FillCredentials()
        {
            var email = _driver.FindElement(By.Name("LoginForm[email]"));
            email.SendKeys("sarofe1547@katamo1.com");

            var pwd = _driver.FindElement(By.Name("LoginForm[password]"));
            pwd.SendKeys("wasd123456");
        }
    }
}
