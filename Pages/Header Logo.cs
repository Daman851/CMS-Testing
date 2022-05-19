using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMS_Testing.Pages
{
     public class Header_Logo
    {
        private IWebDriver driver;   //Web Elements are declared and defined in the Header_logo Class/
        public Header_Logo(IWebDriver driver)    //Driver initialisation of the web driver   //
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);       //Page Factory will initialize every WebElement variable with a reference to a corresponding element on the actual web page based on configured “locators”//
        }

        /*Menu  Initialse and define the constructor*/
        [FindsBy(How = How.Id, Using = "menuToggle")]
        private IWebElement menu;

        [FindsBy(How = How.CssSelector, Using = "a[title='Contact']")]
        private IWebElement contact;
        [FindsBy(How = How.CssSelector, Using = "div.logo")]
        private IWebElement Header;



        public void VerifyingHeader()
        {
            Thread.Sleep(2000);
            menu.Click();
            contact.Click();
            Thread.Sleep(2000);
            Header.Click();
            Thread.Sleep(2000);

            String expecttitle = "Home - typo11";
            Assert.AreEqual(expecttitle, driver.Title);
            Console.WriteLine(driver.Title);

        }
     
      

    }
}
