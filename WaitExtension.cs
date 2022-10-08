/* *******************************************************************************************************************
 * Application: TerapiaReembolso
 * 
 * Authors:  Daniel Liedke
 * 
 * Copyright © Dell Inc. 2020
 * Usage and reproduction in any manner whatsoever without the written permission of Dell Inc. is strictly forbidden.
 *  
 * Purpose: Extension to wait for elements to stabilize the automation
 *           
 * *******************************************************************************************************************/

using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TerapiaReembolso
{
    public class WaitExtension
    {
        public static IWebElement WaitUntilElement(IWebDriver driver, By elementLocator, int timeout = 30)
        {
            WaitUntilElementExists(driver, elementLocator, timeout);
            return WaitUntilElementIsClicable(driver, elementLocator, timeout);
        }

        private static IWebElement WaitUntilElementExists(IWebDriver driver, By elementLocator, int timeout = 30)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }

        private static IWebElement WaitUntilElementIsClicable(IWebDriver driver, By elementLocator, int timeout = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementLocator));
        }
    }
}
