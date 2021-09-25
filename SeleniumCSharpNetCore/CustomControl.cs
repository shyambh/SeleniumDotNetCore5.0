using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumCSharpNetCore
{
    public class CustomControl : DriverHelper
    {
        public static void ComboBox(string controlName, string value)
        {
            IWebElement comboControl = Driver.FindElement(By.Id($"{controlName}-awed"));
            comboControl.Clear();
            comboControl.SendKeys(value);

            Driver.FindElement(By.XPath($"//div[@id='{controlName}-dropmenu']//li[text()='{value}']")).Click();
        }
    }
}
