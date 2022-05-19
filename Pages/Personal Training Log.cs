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
    internal class Personal_Training_Log
    {

        private IWebDriver driver;    //Web Elements are declared and defined in the Personal Training log Class/
        public Personal_Training_Log(IWebDriver driver)    //Driver initialisation of the web driver   //
        {
            this.driver = driver;      
            PageFactory.InitElements(driver, this);      //Page Factory will initialize every WebElement variable with a reference to a corresponding element on the actual web page based on configured “locators”//
        }

        /* Menu  Initialse and define the constructor*/
        [FindsBy(How = How.Id, Using = "menuToggle")]
        private IWebElement menu;

        

        [FindsBy(How = How.CssSelector, Using = "button.sub-menu-toggle ")]
        private IWebElement submenutoggle;
        [FindsBy(How = How.CssSelector, Using = "nav>ul>li>a[title^='Personal']")]
        private IWebElement personaltraininglog;
        [FindsBy(How = How.CssSelector, Using = "nav>ul>li>ul>li>a[title^='Four']")]
        private IWebElement fourcolumntestpage;
        [FindsBy(How = How.CssSelector, Using = "nav>ul>li>ul>li>a[title^='Tile']")]
        private IWebElement tiletestpage;

        public void verifyingtraininglog()
{
    Thread.Sleep(2000);
    menu.Click();
    personaltraininglog.Click();
    String expecttitle = "Personal Training Log - typo11";
    Assert.AreEqual(expecttitle, driver.Title);
    Console.WriteLine(driver.Title);
    menu.Click();
    Thread.Sleep(2000);
    submenutoggle.Click();
    fourcolumntestpage.Click();
    String expectitle = "Four column test page - typo11";
    Assert.AreEqual(expectitle, driver.Title);
    Console.WriteLine(driver.Title);
    menu.Click();
    Thread.Sleep(2000);
    submenutoggle.Click();
    Thread.Sleep(2000);
    tiletestpage.Click();
    String expectitle1 = "Tile test page - typo11";
    Assert.AreEqual(expectitle1, driver.Title);
    Console.WriteLine(driver.Title);

}

    }
}