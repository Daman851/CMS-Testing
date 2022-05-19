using CMS_Testing.BaseClass;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CMS_Testing.Pages;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports.Model;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Support.UI;
using System.Reflection;

namespace CMS_Testing.Tests
{

    [TestFixture]      //Attribute that marks a class that contains tests, Basetest is marked as Test fixture//
    [Parallelizable]  // Multiple Test Cases can run parallel //
    internal class Contact : Basetest               // Reference to BaseTest //
    {
        /* taking the reference for screenshot for the baseclass*/
        ExtentReports Contactscreenshot = Basetest.getInstance();  // Declaring Getinstance as screenshot method //
        

        [Test, Category("Automation Testing")]         // Grouping the test method //
        [TestCaseSource(typeof(Basetest), "browsertorunwith")] //  Indicates the sources to be used to provide test fixture instances for a test class.  which fetches the browser type to run with. //
        public void Tc3(string browsername)  // Creating the method //
        {

            parallelbrowser(browsername);    //  calling the function from the basetest for the parallel browser test //
            var lp = new Contact_Page(driver);  // Creating an instance of base page(Contact_Page),
            Thread.Sleep(2000);     
            lp.VerifyingContact();            //Calling the base page methods(Verifying_Contact)//
            Thread.Sleep(2000);

            String expecttitle = "Contact - typo11";   // creating a variable //
            Assert.AreEqual(expecttitle, driver.Title,"Failed because of reason");   //  Variable will be taken and check with the assertion, title of the page //
            Console.WriteLine(driver.Title);     // Prinitng in the console//
           
            
            //Use boolean method when we need to run multiple assertions //
            /* bool b = expecttitle.Equals(driver.Title);
             bool bo = browsername.Equals("Chrome");
            /* throw new Exception("Element not found");*/

            /* Assert.IsTrue(b && bo, "Failed because: Title match was " + b + "or browsername match was " + bo );*/


            /*  var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));*/

            /*var div = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("display-length")));*/


        }
        [Test, Category("Automation Testing")]     //Grouping the test method //
        [TestCaseSource(typeof(Basetest), "browsertorunwith")]     //  Indicates the sources to be used to provide test fixture instances for a test class.  which fetches the browser type to run with. //
        public void Tc11(string browsername)                //  calling the function from the basetest for the parallel browser test //
        {
            ExtentReports extent;

            parallelbrowser(browsername);
            var lp1 = new Contact_Page(driver);
            lp1.verifyingtextfield_is_enabled();
        }

        [Test, Category("Automation Testing")]
        [TestCaseSource(typeof(Basetest), "browsertorunwith")]
        public void Tc12(string browsername)
        {
            ExtentReports extent;

            parallelbrowser(browsername);
            var lp2 = new Contact_Page(driver);
            lp2.verifying_contact_form_with_emptyfields();
        }

     /*   [Test, Category("Automation Testing")]
        [TestCaseSource(typeof(Basetest), "browsertorunwith")]
        public void Tc13(string browsername)
        {
            ExtentReports extent;

            parallelbrowser(browsername);
            var lp3 = new Contact_Page(driver);
            lp3.verifyinguserid();
        }
     */

        [TearDown]   // 

        public void screenshotteardown()    //Creating a method for Extent reports //
        {
            ExtentTest test;   // Creating an instance for the Extent tests //
            String browsername = TestContext.CurrentContext.Test.Arguments[0] as String;    //   Declaring the browser variables and test method name //
            String methodname = TestContext.CurrentContext.Test.MethodName as String;       //   Declaring the browser variables and test method name //

            test = extent.CreateTest("<h3>Contact Page-Title</h3>").Info("<h3>Test Started in </h3>"  +browsername + " " + "and" + " " + methodname);// Caaling the extent report method from BAseTest //


            if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))  // Checking the test status , if fails, it will follow this method //
            {

                Screenshot file = ((ITakesScreenshot)driver).GetScreenshot();  // Using the getscreeenshot method to take the screenshots of the resulting screen in HTML report  //
                string image = file.AsBase64EncodedString;        //Image will be stored in this format //

                //Giving some condtions to be followed in HTML report //
                test.Fail("<b><font color=red>" + "Failed because of reason"+ TestContext.CurrentContext.Result.StackTrace + TestContext.CurrentContext.Result.Message  + "</font></b>", MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
                
            }
            else if
                  (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Passed))  // Checking the test status , if Pass, it will follow this method //
            {
                Screenshot file = ((ITakesScreenshot)driver).GetScreenshot();   // Using the getscreeenshot method to take the screenshots of the resulting screen in HTML report  //
                string image = file.AsBase64EncodedString;          //Image will be stored in this format //


                      //Giving some condtions to be followed in HTML report //
                test.Pass("<b><font color=green" + TestContext.CurrentContext.Result.StackTrace + TestContext.CurrentContext.Result.Message + TestContext.CurrentContext.Result.Outcome + "Screenshot of Pass" + "</font></b>", MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
            }
         
    }
        // Everytime report should be updated , clearing the report//
        [TearDown]

        // Method is created to flush extent report every time so that it will be created nearly every time //
        public void exit()  //
    {
        Contactscreenshot.Flush();
    }
}
}