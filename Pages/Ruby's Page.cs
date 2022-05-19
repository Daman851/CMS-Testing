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
     class Class1
    {


        private IWebDriver driver;     //Web Elements are declared and defined in the Ruby's Page Class/
        public Class1(IWebDriver driver)    //Driver initialisation of the web driver   //
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);      //Page Factory will initialize every WebElement variable with a reference to a corresponding element on the actual web page based on configured “locators”//
        }

        /* Menu  Initialse and define the constructor*/
        [FindsBy(How = How.Id, Using = "menuToggle")]
        private IWebElement menu;
        [FindsBy(How = How.CssSelector, Using = "nav>ul>li>a[title^='Ruby']")]
        private IWebElement rubyspage;
        public void verifyingrubypage()
        {
            Thread.Sleep(2000);
            menu.Click();
            rubyspage.Click();
            String expecttitle = "Ruby's page - typo11";
            Assert.AreEqual(expecttitle, driver.Title);
            Console.WriteLine(driver.Title);




        }
    }
}