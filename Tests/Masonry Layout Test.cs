using AventStack.ExtentReports;
using CMS_Testing.BaseClass;
using CMS_Testing.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
namespace CMS_Testing.Tests
{
    [TestFixture]            //Attribute that marks a class that contains tests, Basetest is marked as Test fixture//
    [Parallelizable]        // Multiple Test Cases can run parallel //
    internal class Masonry_Layout_Test : Basetest
    {
        /* taking the reference for screenshot for the baseclass*/
        ExtentReports MasonryLayoutcreenshot = Basetest.getInstance();       // Declaring Getinstance as screenshot method //
        [Test, Category("Automation Testing")]                  // Grouping the test method //
        [TestCaseSource(typeof(Basetest), "browsertorunwith")]   //Indicates the sources to be used to provide test fixture instances for a test class.  which fetches the browser type to run with.//
        public void Tc4(string browsername)          // Creating the method //


        {
           
            parallelbrowser(browsername);       //  calling the function from the basetest for the parallel browser test //
            var lp = new Masonry_Layout(driver);    // Creating an instance of base page(Masonry Layout)
            Thread.Sleep(2000);
            lp.verifyingmasonrylayout();      //Calling the base page methods(Verifying Masonry_Layout)//
            Thread.Sleep(2000);
        } // Everytime report should be cleared , or refreshed //
        [TearDown]

        public void screenshotteardown()       //Creating a method for Extent reports //
        {
            ExtentTest test;
            String browsername = TestContext.CurrentContext.Test.Arguments[0] as String;    //   Declaring the browser variables and test method name //
            String methodname = TestContext.CurrentContext.Test.MethodName as String;       //   Declaring the browser variables and test method name //
            test = extent.CreateTest("<h3>Masonry layout</h3>").Info("<h3>Test Started in </h3>" + browsername + " " + "and" + " " + methodname);
            
            if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))      // Checking the test status , if fails, it will follow this method //
            {

                Screenshot file = ((ITakesScreenshot)driver).GetScreenshot();      // Using the getscreeenshot method to take the screenshots of the resulting screen in HTML report  //
                string image = file.AsBase64EncodedString;                                //Image will be stored in this format //

                //Giving some condtions to be followed in HTML report //
                test.Fail("<b><font color=red" + "Screenshot of Fail" + "</font></b>", MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
            }
            else if
                  (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Passed))    // Checking the test status , if Pass, it will follow this method //
            {
                Screenshot file = ((ITakesScreenshot)driver).GetScreenshot();      // Using the getscreeenshot method to take the screenshots of the resulting screen in HTML report  //
                string image = file.AsBase64EncodedString;                                //Image will be stored in this format //

                //Giving some condtions to be followed in HTML report //
                test.Pass("<b><font color=green" + "Screenshot of Pass" + "</font></b>", MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
            }
           
        }
        // Everytime report should be updated , clearing the report//
        [TearDown]
        public void exit()
        {
            MasonryLayoutcreenshot.Flush();
        }
    }
}
    