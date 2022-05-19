using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMS_Testing.Pages
{
    class Menu_Option_List
    {
        private IWebDriver driver;   //Web Elements are declared and defined in the MenuOptionList Class/
        public Menu_Option_List(IWebDriver driver)      //Driver initialisation of the web driver   //
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);      //Page Factory will initialize every WebElement variable with a reference to a corresponding element on the actual web page based on configured “locators”//
        }

        /* Menu  Initialse and define the constructor*/
        [FindsBy(How = How.Id, Using = "menuToggle")]
        private IWebElement menu;
        [FindsBy(How = How.CssSelector, Using = "ul.menu ")]
        private IWebElement menulist;


        public void menuoptionlist()
        {

            Thread.Sleep(2000);
            menu.Click();
            IList<IWebElement> menuitems = driver.FindElements(By.XPath(("//*[@id='p11']//li")));
            int menutotal = menuitems.Count;


            Console.WriteLine("The total number of menu items displayed are:" + menutotal);
            Console.WriteLine("The Menu displayed are:" + menulist.Text);

            if (menutotal == 8)
            {
                Assert.Pass("The test cases is passed");
            }
            else
                Assert.Fail("The test case is failed");


        }
        public void Menuoptionlistwithpersonallog()
        {
            Thread.Sleep(2000);
            menu.Click();
            menulist.Click();
            IList<IWebElement> menuitems = driver.FindElements(By.XPath(("//*[@id='p1']/div[2]/header/div/div/nav/ul//li//a")));
            int menutotal = menuitems.Count;
            
            Console.WriteLine("The total number of menu items displayed are:" + menutotal);
            Console.WriteLine("The Menu displayed are:" + menulist.Text);

            if (menutotal == 10)
            {
                Assert.Pass("The test cases is passed");
            }
            else
                Assert.Fail("The test case is failed");


        }

        public void verifyingtogglingbutton()
        {
            Thread.Sleep(2000);
            menu.Click();
            Thread.Sleep(2000);
            menu.Click();

        }


    }

}