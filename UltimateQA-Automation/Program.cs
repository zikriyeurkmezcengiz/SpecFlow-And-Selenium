using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UltimateQA_Automation
{

    public enum CarBrand
    {
        Volvo,
        Saab,
        Opel,
        Audi
    }

    class Program
    {
        private static IWebDriver _driver;
        static void Main(string[] args)
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");
            TestSelectElement();


            Console.ReadLine();


        }

        static void TestSelectElement()
        {
            var carBrands = _driver.FindElement(By.CssSelector("div.et_pb_blurb_description > select"));


            SelectElement selector = new SelectElement(carBrands);
            selector.SelectByIndex((int)CarBrand.Audi);
            Thread.Sleep(3000);

            selector.SelectByValue("saab");
            Thread.Sleep(3000);

            selector.SelectByText("Opel");
            Thread.Sleep(3000);

        }
           

        static void LogIn()
        {
            var login = _driver.FindElement(By.Id("et_pb_contact_name_0"));
            login.SendKeys("John Snow");

            var email = _driver.FindElement(By.Id("et_pb_contact_email_0"));
            email.SendKeys("johnsnow@gameofthrones.com");

            var submit = _driver.FindElement(By.CssSelector("button[type='submit'][class='et_pb_contact_submit et_pb_button']"));
            submit.Click();
        }

        static void ClickOnRadioButtons()
        {
            var genders = _driver.FindElements(By.CssSelector("input[type='radio'][name='gender']"));
            //var male = genders[0];
            //var female = genders[1];
            //var other = genders[2];

            foreach (var gender in genders)
            {
                gender.Click();
                if (gender.Selected)
                {
                    Console.WriteLine($"Gender {gender.Text} is selecte");
                }
                Thread.Sleep(2000);
            }
        }

        static void ClickonCheckBoxes()
        {
            var vehicles = _driver.FindElements(By.CssSelector("input[type='checkbox'][name='vehicle']"));

            //var bike = vehicles[0];
            //var car = vehicles[1];

            foreach (var vehicle in vehicles)
            {
                vehicle.Click();
                if (vehicle.Selected)
                {
                    Console.WriteLine($"Vehicle {vehicle.Text} is selected");
                }
                Thread.Sleep(2000);
                //to unselect click once again
            }

        }

        static void TestCssSelectors()
        {
            //tagname[attribute='value']

            var byName = _driver.FindElement(By.CssSelector("button[name='button1']"));

            //below lines get same result.
            var byClass1 = _driver.FindElement(By.CssSelector("button[class='buttonClass']"));
            var byClass2 = _driver.FindElement(By.CssSelector("button.buttonClass"));

            //if the class name has spaces and you use short form. 
            //<button class="btn super style"/>
            //By.CssSelector("button.btn.super.style");

            var allWithClassName = By.CssSelector(".buttonClass");

            var byIDLongForm = _driver.FindElement(By.CssSelector("a[id='idExample']"));

            var byIDShortForm= _driver.FindElement(By.CssSelector("#idExample"));


        }



        static void TestXPathLocators()
        {
            var byId = _driver.FindElement(By.XPath("//a[@id=\"idExample\"]"));
            var byName = _driver.FindElement(By.XPath("//button[@name=\"button1\"]"));
            var byName2 = _driver.FindElement(By.XPath("//*[@name=\"button1\"]"));

            //var byName3 = _driver.FindElement(
                //By.XPath("/html/body/div/div/div/article/div/div/div/div/div/div/div/div/form/button"));

            var el1 = _driver.FindElement(
                 By.XPath("/html/body/div[1]/div/div/article/div/div[1]/div/div/div/div[4]/div[1]/div/div[1]/div/div/div/form/button"));

          //  var el2 = _driver.FindElement(
               // By.XPath("//*[@id=\"et-boc\"]/div/div[4]/div[1]/div/div[2]//following::button"));
        }

        static void TestSimpleLocators()
        {

            IWebElement element = _driver.FindElement(By.Id("idElement"));
            element.Click();

            Clickon(By.Name("button1"));
            Clickon(By.ClassName("buttonClass"));
            Clickon(By.LinkText("Click me using this link text!"));
            Clickon(By.PartialLinkText("Click me using"));

            var buttons = _driver.FindElements(By.TagName("button"));

            foreach (var button in buttons)
            {
                Console.WriteLine(button.Text);
            }
        }

        static void Clickon(By locator)
        {
            var element = _driver.FindElement(locator);

            element.Click();

            Thread.Sleep(TimeSpan.FromSeconds(5));

            _driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");
        }
    }
}
