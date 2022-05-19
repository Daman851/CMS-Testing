using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMS_Testing.BaseClass
{


    internal class Basetest
    {
        //Declaring the variable for the driver,reports,extent test//
        public IWebDriver driver;

        public static ExtentReports extent;

        public Basetest() {  }

        public static ExtentReports getInstance()  // Created method for extent report creation 
        {
            if (extent == null)   //On condition if extent report is empty,new report is generated//
            { 
                string reportpath = @"C:\\Users\\daman\\OneDrive - Whitireia and WelTec\\Capstone Project\\Ocular\\CMS-Testing\\Extent-reports";       // Declaring the path, where reports will be saved //
                
                var htmlReporter = new ExtentHtmlReporter(reportpath);   // Creating the instance of the HTML reporteer//
                /* creating new object reference for the report*/
                extent = new ExtentReports();
                extent.AddSystemInfo(" Environment", "CMS Testing ");  //Defining the system information in the envrioment of the extent report //
                extent.AddSystemInfo("Operating System:", "Windows 10");
                extent.AddSystemInfo("UserName", "Daman Narula");
                
                extent.AttachReporter(htmlReporter);  // Attaching the HTML report //
                string extentConfigPath = @"C:\\Users\\daman\\OneDrive - Whitireia and WelTec\\Capstone Project\\Ocular\\CMS-Testing\\Extent-config.xml";   //Adding the confog file//
                
                htmlReporter.LoadConfig(extentConfigPath);  //Adding the configuration path to the HTML report //
            }
            return extent;   ///Extent reports will be returned //
        }
        /* Everytime report should be updated , clearing the report*/
        [OneTimeTearDown]

        // Method is created to flush extent report every time so that it will be created nearly every time //
        public void ExtentClose()  
        {
            extent.Flush(); //Used to update the reports //

        }
        /* Method for NotImplementedexception,Taking screenshots of test result screen*/
        private string Capture(IWebDriver driver, object name)
        {
            throw new NotImplementedException();  // New instance is initiated //
        }

        //Method is created for the screenshot to take the screenshot of the application.
        private string Getscreenshot(IWebDriver driver, string screenshotname)
        {
            ITakesScreenshot st = (ITakesScreenshot) driver;  //creating an instance of ItakeScreeenshot //
        Screenshot screenshot1 = st.GetScreenshot();     //Getscreenshot mmethod is called to take the screenshot 

            //assembly is the method invoked to get the currently running method to take screenshot, get the path of the screenshot and store it in a apth varaible//
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase; 
            string uptobinPath = path.Substring(0, path.LastIndexOf("CMS-Testing")) + "Screenshots\\" + "screenshotname" + ".png";  //storing the image in the path 
            string localPath = new Uri(uptobinPath).LocalPath;          // to emebed the file in report in the local path//
            screenshot1.SaveAsFile(localPath, ScreenshotImageFormat.Png);   //Saving the file in the local path with the extension as .Png//
            return localPath;            //Path is returned//       
    }
      
        //method created to initialise the multiple browsers//
        public void parallelbrowser(string browsername)
        { //Headless chrome broser is initilised by calling the chrome options //
        ChromeOptions options = new ChromeOptions();
           
        options.AddArguments("headless", "--window-size=1920,1200"); 


if (browsername.Equals("Chrome"))


    driver = new ChromeDriver();



else if (browsername.Equals("Firefox"))


    driver = new FirefoxDriver();



else if (browsername.Equals("headlesschrome"))

    driver = new ChromeDriver(options);
else
    driver = new FirefoxDriver();


        driver.Navigate().GoToUrl("https://client:ocular@www.typo11.dev2.ocular.co.nz/");  //Calling the URL //

        Thread.Sleep(2000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);  // Adding the implicit wait function to amke it a bit slow//

    driver.Manage().Window.Maximize();   // to maximize the window//
    Thread.Sleep(2000);                  //Adding some wait time//


}


    [TearDown]
    public void Close()
    {
        driver.Quit();    //to close the driver //
        Thread.Sleep(2000);
    }

    [TearDown]
    public void AfterTest()
    {     
        //report creation with the status , Test Context gives the information of test status, that will be stored in the variable status //
        var status = TestContext.CurrentContext.Result.Outcome.Status;
        var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)  //gets the stack trace associated with the error failure of the test //
        ? ""
        : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
        Status logstatus;
            
            //switch is used to define the status of the test result to be displayed in the report//
        switch (status)
        {
            case TestStatus.Failed:
                logstatus = Status.Fail;
                break;
            case TestStatus.Inconclusive:
                logstatus = Status.Warning;
                break;
            case TestStatus.Skipped:
                logstatus = Status.Skip;
                break;
            default:
                logstatus = Status.Pass;
                break;
        }
    }

    public static IEnumerable<string> browsertorunwith()   //Indicates the sources to be used to provide test fixture instances for a test class.  which fetches the browser type to run with.//
        {
        string[] browsers = { "Chrome", "Firefox", "headlesschrome" };

        foreach (string b in browsers) { yield return b; }
    }





}
}