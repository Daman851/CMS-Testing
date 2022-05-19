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
    internal class Slider
    {
        
        private IWebDriver driver;     //Web Elements are declared and defined in the Slider Class/
        public Slider(IWebDriver driver)     //Driver initialisation of the web driver   //
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);      //Page Factory will initialize every WebElement variable with a reference to a corresponding element on the actual web page based on configured “locators”//
        }

        [FindsBy(How = How.CssSelector, Using = "#ocular-slider-4")]
        private IWebElement slides;

        [FindsBy(How = How.CssSelector, Using = "span.swiper-pagination-total")]
        private IWebElement numberofslides;
        [FindsBy(How = How.CssSelector, Using = "div.swiper-button-next")]
        private IWebElement nextbutton;
        [FindsBy(How = How.CssSelector, Using = "span.swiper-pagination-current")]
        private IWebElement currentslidenumber;

        [FindsBy(How = How.CssSelector, Using = "div.swiper-button-prev")]
        private IWebElement previousbutton;
        

        
        public void slide()
        {

           /* Console.WriteLine("Slide width and height is" + slides.Size);
            String expectSize = "Height =500, Width = 1920";
            Assert.AreEqual(expectSize, slides.Size);
            Console.WriteLine(driver.Title);*/
            IList<IWebElement> slideimages = driver.FindElements(By.CssSelector("div[class^='ocular-slider-slide ']"));
            int numberofslides1 = slideimages.Count();
            // Console.WriteLine(slideimages.Count());
            Console.WriteLine(numberofslides.Text);
            Thread.Sleep(5000);

            for (int i = 1; i <= slideimages.Count(); i++)
            {
                Console.WriteLine("Next button is clicked");
                nextbutton.Click();
                Thread.Sleep(2000);
                Console.WriteLine("current slide number=" + currentslidenumber.Text);

            }

            for (int j = 1; j <= slideimages.Count(); j++)
            {
                Console.WriteLine("Previous button is clicked");
                previousbutton.Click();
                Thread.Sleep(2000);
                Console.WriteLine("current slide number=" + currentslidenumber.Text);


            }
     
        }


    }
}
