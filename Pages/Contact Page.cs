using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMS_Testing.Pages
{
    public class Contact_Page
    {
        //Web Elements are declared and defined in the Contact Class//
        private IWebDriver driver;
        public Contact_Page(IWebDriver driver)  //Driver initialisation of the web driver   //
        {
            this.driver = driver;
            //Provides the ability to produe, page object modelling a page//
            PageFactory.InitElements(driver, this);  //Page Factory will initialize every WebElement variable with a reference to a corresponding element on the actual web page based on configured “locators”//
        }

        /* Menu  Initialse and define the constructor*/
        [FindsBy(How = How.Id, Using = "menuToggle")]
        private IWebElement menu;
        [FindsBy(How = How.CssSelector, Using = "a[title='Contact']")]
        private IWebElement contact;
        [FindsBy(How = How.XPath, Using = "//input[@id='contactSimple-13-name']")]
        private IWebElement contactname;
        [FindsBy(How = How.XPath, Using = "//input[@id='contactSimple-13-email']")]
        private IWebElement contactemail;
        [FindsBy(How = How.XPath, Using = "//textarea[@id='contactSimple-13-message']")]
        private IWebElement contactmessage;
        [FindsBy(How = How.CssSelector, Using = "button.btn.btn-primary")]
        private IWebElement contactsubmit;
        [FindsBy(How = How.XPath, Using = "//*[@id='contactSimple-13']/div[2]/div/span")]
        private IWebElement mandatoryname;
        [FindsBy(How = How.XPath, Using = "//*[@id='contactSimple-13']/div[3]/div/span")]
        private IWebElement mandatoryemail;
        [FindsBy(How = How.XPath, Using = "//*[@id='contactSimple-13']/div[4]/div/span")]
        private IWebElement mandatorymessage;
        [FindsBy(How = How.XPath, Using = "//*[@id='topBar']/div/div/div[2]/div/p")]
        private IWebElement useremail;



        public void VerifyingContact()
        {
            Thread.Sleep(2000);        // adding some wait time //
            menu.Click();               // Clicks on the menu  //
            contact.Click();                 // Clicks on the Contact //

        }

        public void verifyingtextfield_is_enabled()
        {
            Thread.Sleep(2000);
            menu.Click();
            contact.Click();
            /*verifies wheether the textbox is enabled to type the text*/
            Assert.AreEqual(true, contactname.Enabled);
            Assert.AreEqual(true, contactemail.Enabled);
            Assert.AreEqual(true, contactmessage.Enabled);

            Console.WriteLine("All the text fields are enabled");

        }

        public void verifying_contact_form_with_emptyfields()
        {
            Thread.Sleep(2000);
            menu.Click();
            contact.Click();
            OpenQA.Selenium.IJavaScriptExecutor jse = (OpenQA.Selenium.IJavaScriptExecutor)driver;
            /*added sleep to give little time for browser to respond properly*/
            Thread.Sleep(3000);
             //verifies whether the user is not able to submit on empty text fields //

            contactname.SendKeys("");
            contactemail.SendKeys("");
            contactmessage.SendKeys("");
            contactsubmit.Click();
            // highlight the element with red border 3px width//
            jse.ExecuteScript("arguments[0].style.border='3px solid red'", contactname);    
            jse.ExecuteScript("arguments[0].style.border='3px solid red'", contactemail);
            jse.ExecuteScript("arguments[0].style.border='3px solid red'", contactmessage);
            Console.WriteLine("Name:" + mandatoryname.Text);   // Printing the text on the test screen //
            Console.WriteLine("Email" + mandatoryemail.Text);
            Console.WriteLine("Message" + mandatorymessage.Text);
        }
        public void verifyinguserid()
        {

            Thread.Sleep(2000);
            menu.Click();
            contact.Click();
            OpenQA.Selenium.IJavaScriptExecutor jse = (OpenQA.Selenium.IJavaScriptExecutor)driver;    //utilize JavascriptExecutor, create a reference for the interface and assign it to the WebDriver instance by type casting it.


            // added sleep to give little time for browser to respond
            Thread.Sleep(3000);
           

            jse.ExecuteScript("arguments[0].style.border='3px solid red'", useremail);
            String exceptedtitle = "DN@gmail.com";
            Assert.AreEqual(exceptedtitle, useremail.Text);
            Console.WriteLine("The useremail displayed is wrong");


        }

    }
}