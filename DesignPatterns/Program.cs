﻿using OpenQA.Selenium;
using System;
using System.Threading;

namespace AutomationRhapsody.DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Browsers browser = Browsers.Chrome;
            WebDriverFacade webDriver = new WebDriverFacade(browser);
            webDriver.Start("http://autoqa.pp.ua/");

            /* Example for Null Object patterns */
            // Location of elements is inside tests logic which is confusing
            // One element can be needed in several tests this will require locating it several times
            IWebElement element = webDriver.FindElement(By.CssSelector("notExisting"));
            element.Click();

            // Because we use singleton it is possible to compare for the Null Object
            if (element == NullWebElement.NULL)
            {
                Console.WriteLine("Element not found!");
            }

            /* Example for Page Objects pattern */
            HomePageObject homePage = new HomePageObject(webDriver);
            // One element is defined on only one place - we do not repeat ourselves
            Console.WriteLine("Title of the site is: " + homePage.GetSiteTitle());
            homePage.SearchFor("empty result");
            webDriver.Stop();
        }
    }
}
