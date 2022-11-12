/* *******************************************************************************************************************
 * Aplicação: TerapiaReembolso
 * 
 * Autor:  Daniel Liedke
 * 
 * Copyright © Daniel Liedke 2022
 * Usage and reproduction in any manner whatsoever without the written permission of Daniel Liedke is strictly forbidden.
 *  
 * Propósito: Aguarda por elementos na página para estabilizar a automações e reduzir sleeps
 *           
 * *******************************************************************************************************************/

using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TerapiaReembolso
{
    public class WaitExtension
    {
        public static IWebElement WaitUntilElement(IWebDriver driver, By elementLocator, int timeoutSeconds = 30)
        {
            WaitUntilElementExists(driver, elementLocator, timeoutSeconds);
            return WaitUntilElementIsClicable(driver, elementLocator, timeoutSeconds);
        }

        private static IWebElement WaitUntilElementExists(IWebDriver driver, By elementLocator, int timeoutSeconds = 30)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
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
