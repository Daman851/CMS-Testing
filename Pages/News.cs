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
    internal class News
    {

        private IWebDriver driver;     //Web Elements are declared and defined in the News Class//
        public News(IWebDriver driver)     //Driver initialisation of the web driver   //
        {
            this.driver = driver;         
            PageFactory.InitElements(driver, this);       //Page Factory will initialize every WebElement variable with a reference to a corresponding element on the actual web page based on configured “locators”//
        }

        /*Menu  Initialse and define the constructor*/
        [FindsBy(How = How.Id, Using = "menuToggle")]
        private IWebElement menu;

        [FindsBy(How = How.CssSelector, Using = "nav>ul>li>a[title='News']")]
        private IWebElement newsmenu;
        [FindsBy(How = How.XPath, Using = "//*[@id='news-container-29']/ul/li[1]/a/div/div[3]/span")]
        private IWebElement newarticletest1;
        [FindsBy(How = How.XPath, Using = "//*[@id='news-container-29']/ul/li[2]/a/div/div[3]/span")]
        private IWebElement newarticletest2;

        public void verifyingnews()
        {
            Thread.Sleep(2000);              //adding some wait time //
            menu.Click();
            newsmenu.Click();
            String expecttitle = "News - typo11";
            Assert.AreEqual(expecttitle, driver.Title);  //checking the title on the web with the above provided//
            Console.WriteLine(driver.Title);
        }
        public void verifyreadmorearticle1()
        {
            Thread.Sleep(2000);
            menu.Click();
            newsmenu.Click();
            String expecttitle = "News - typo11";
            Assert.AreEqual(expecttitle, driver.Title);
            Console.WriteLine(driver.Title);

        }
        public void verifyingreadmorearticle2()
        {
            Thread.Sleep(2000);
            menu.Click();
            newsmenu.Click();
            String expecttitle = "News - typo11";
            Assert.AreEqual(expecttitle, driver.Title);
            Console.WriteLine(driver.Title);

        }
    }
}
