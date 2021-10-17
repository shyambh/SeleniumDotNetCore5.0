using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;



namespace SeleniumCSharpNetCore
{
    public class Tests : DriverHelper
    {
        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--headless", "--start-maximized");
            //options.AddArguments("--start-maximized");
            Console.WriteLine("Setup");

            new DriverManager().SetUpDriver(new ChromeConfig());
            
            Driver = new ChromeDriver(options);
        }

        [Test]
        public void Test1()
        {
            try
            {
                Driver.Navigate().GoToUrl("https://demowf.aspnetawesome.com/");
                Console.WriteLine("Setup");
                
                Driver.FindElement(By.Id("ContentPlaceHolder1_Meal")).SendKeys("Tomato");
                /*Driver.FindElement(By.XPath(
                    "//input[@name='ctl00$ContentPlaceHolder1$ChildMeal1']/following-sibling::div[text()='Lettuce']")).Click();*/

                CustomControl.ComboBox("ContentPlaceHolder1_AllMealsCombo", "Almond");
                Driver.Quit();
            }
            catch (Exception e)
            {
                Driver.Quit();
                Assert.Fail($"Test is failing due to this : {e}");
            }
        }
    }
}