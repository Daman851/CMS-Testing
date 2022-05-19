using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMS_Testing.Pages
{
    internal class Resouces
    {
        private IWebDriver driver;     //Web Elements are declared and defined in the Resouces Class/
        public Resouces(IWebDriver driver)     //Driver initialisation of the web driver   //
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);      //Page Factory will initialize every WebElement variable with a reference to a corresponding element on the actual web page based on configured “locators”//
        }
        /* Menu  Initialse and define the constructor*/

        [FindsBy(How = How.Id, Using = "menuToggle")]
        private IWebElement menu;
        [FindsBy(How = How.CssSelector, Using = "a[title='Resouces']")]
        private IWebElement resources;
        [FindsBy(How = How.CssSelector, Using = "button.btn")]
        private IWebElement filterdropdown;
        [FindsBy(How = How.CssSelector, Using = "a#category-3.dropdown-item")]
        private IWebElement news;
        [FindsBy(How = How.CssSelector, Using = "ul.pagination.pagination-block")]
        private IWebElement pagebar;
        /* Pagination to go ahead , because of same class, needs to give the parent directory, so it should pick the right path */
       /* [FindsBy(How = How.XPath, Using = "//div//div//div//div//ul//li[@class='active' or @class='waves-effect']" )]
        private IWebElement resouce_pagination;*/
        /*  becuase there was no class or id */
        [FindsBy(How = How.XPath, Using = "//span[text()='next']" )]
            private IWebElement nextbutton;
        [FindsBy(How = How.XPath, Using = "//span[text()='previous']")]
        private IWebElement previousbutton;
        [FindsBy(How = How.XPath, Using = "//*[@id='c7']/div/div/div/div/div/div/div[2]/small")]
        private IWebElement currentpagenumber;



        public void verifyingresources()
        {

            Thread.Sleep(2000);
            menu.Click();
            resources.Click();
            String expecttitle = "Resouces - typo11";
            Assert.AreEqual(expecttitle, driver.Title);
            Console.WriteLine(driver.Title);
        }
        public void resourcedropdown()
        {
            Thread.Sleep(2000);
            /* username.SendKeys("client");
             password.SendKeys("ocular");
             loginbutton.Click();*/

            menu.Click();
            Thread.Sleep(2000);
            resources.Click();
            Thread.Sleep(2000);
            filterdropdown.Click();
            news.Click();
            Console.WriteLine(pagebar.Text);
        }
        public void pagination()
        {
            menu.Click();
            Thread.Sleep(2000);
            resources.Click();
            /* Window scroll down*/
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0,700)");

            /* Number of pages check mutiple elements added */
            IList<IWebElement> totalpages = driver.FindElements(By.XPath("//div//div//div//div//ul//li[@class='active' or @class='waves-effect']"));
            int totalpages1 = totalpages.Count();

            driver.Manage().Window.Maximize();

            Thread.Sleep(4000);
            Console.WriteLine("Totalnumber of pages:" + totalpages1);
            /* Jvascript helps in loading the next pages , to interacting with the web element, , easily loacate to next, otherwise it's not interactable */
            OpenQA.Selenium.IJavaScriptExecutor jse = (OpenQA.Selenium.IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].click()", nextbutton);
            Thread.Sleep(4000);
            /* Window scroll down*/
            IJavaScriptExecutor js4 = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0,700)");
            Console.WriteLine("Current Page number:" + currentpagenumber.Text);
            Thread.Sleep(4000);
            OpenQA.Selenium.IJavaScriptExecutor jse1 = (OpenQA.Selenium.IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].click()", previousbutton);
            Thread.Sleep(2000);
            Console.WriteLine("Current Page number:" + currentpagenumber.Text);
            Thread.Sleep(4000);



        }

    }
    }
