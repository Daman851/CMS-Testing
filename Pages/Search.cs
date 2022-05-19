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
    class Search
    {

        private IWebDriver driver;   //Declaring the variable for the driver,reports,extent test//
        public Search(IWebDriver driver)    //Driver initialisation of the web driver   //
        {
            this.driver = driver;
            
            PageFactory.InitElements(driver, this);          //Page Factory will initialize every WebElement variable with a reference to a corresponding element on the actual web page based on configured “locators”//
        }

       
        [FindsBy(How = How.CssSelector, Using = "div.search-toggle.mobile-toggle.d-flex.d-lg-none")]         // Menu  Initialse and define the constructor//
        private IWebElement SearchKey;
       
        [FindsBy(How = How.CssSelector, Using = "input[id='ke_search_sword'] ")]            //Finding the element using CSS selector//
        
        private IWebElement SearchBox;                                                   //Interface through which user control the elements on the page //

        [FindsBy(How = How.XPath, Using = "//header//form//span//input[@type='submit']")]        //Finding the element using CSS selector//
        private IWebElement SearchButton;                                                        //Interface through which user control the elements on the page //
        public void verifyingsearch()                           // creating an web element action method // 
        {

            IJavaScriptExecutor jse12 = (IJavaScriptExecutor)driver;      //utilize JavascriptExecutor, create a reference for the interface and assign it to the WebDriver instance by type casting it.

            jse12.ExecuteScript("arguments[0].click()", SearchKey);       //Calling the element to be clicked //

            Thread.Sleep(2000);    // adding some wait time //


            SearchBox.SendKeys("pers");    // Type the value in the textbox//

            String typedValue = SearchBox.GetAttribute("value");   //get the value of the textbox //

            int size = typedValue.Length;       //get the length of the typed value(local variable)//

            SearchButton.Click();         // Clicks on the Search  button //
            
            Thread.Sleep(2000);        // adding some wait time //



            //Putting if else condition to check. atleast 4 characters shoould be embeded in the text box to search
            if (size < 4)
            {
               
                Assert.Fail("Failed because of: ");      // Assert that specified condition is fail. //
                Console.WriteLine("Please enter atleat 4 characters");     //Print the specified data //

            }
            else
            {
                Assert.True(true, "success");           // Assert that specified condition is True. //
                Console.WriteLine("Please enter atlest 4 charatcters");  //Print the specified data //
            }
        

          
        }

    }
}