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
    internal class Masonry_Layout
    {
        private IWebDriver driver;     //Web Elements are declared and defined in the Masonry layout Class/
        public Masonry_Layout(IWebDriver driver)    //Driver initialisation of the web driver   //
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);      //Page Factory will initialize every WebElement variable with a reference to a corresponding element on the actual web page based on configured “locators”//
        }

        /* Menu  Initialse and define the constructor*/
        [FindsBy(How = How.Id, Using = "menuToggle")]
        private IWebElement menu;

        [FindsBy(How = How.CssSelector, Using = "nav>ul>li>a[title^='Masonry']")]
        private IWebElement masonrylayout;
        public void verifyingmasonrylayout()
{
    Thread.Sleep(2000);
    menu.Click();
    masonrylayout.Click();
    String expecttitle = "Masonry Layout - typo11";
    Assert.AreEqual(expecttitle, driver.Title);
    Console.WriteLine(driver.Title);

}
    }
}