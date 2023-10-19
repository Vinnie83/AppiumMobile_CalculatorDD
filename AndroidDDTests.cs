using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.PageObjects;

namespace AppiumAndroid_CalculatorDDTests
{
    public class AndroidDDTests
    {

        private const string appiumUrl = "http://127.0.0.1:4723/wd/hub";
        private const string appLocation = @"C:\com.example.androidappsummator.apk";
        private AndroidDriver<AndroidElement> driver;  
        private AppiumOptions options;  

        [SetUp]
        public void Setup()
        {
            this.options = new AppiumOptions() { PlatformName = "Android" };
            options.AddAdditionalCapability("app", appLocation);
            this.driver = new AndroidDriver<AndroidElement>(new Uri(appiumUrl), options);  
        }

        [TearDown]  
        public void Teardown()
        {

            driver.Quit();   
        }

        [TestCase("10","5","15")]
        [TestCase("10","bbbb","error")]

        public void Test_CalculatorDD(string firstValue, string secondValue, string result) 
        {

        var firstInput = driver.FindElementById("com.example.androidappsummator:id/editText1");
        var secondInput = driver.FindElementById("com.example.androidappsummator:id/editText2");
        var resultField = driver.FindElementById("com.example.androidappsummator:id/editTextSum");
        var calcButton = driver.FindElementById("com.example.androidappsummator:id/buttonCalcSum");

        firstInput.Clear();
        secondInput.Clear();
        firstInput.SendKeys(firstValue);
        secondInput.SendKeys(secondValue);
        calcButton.Click();

        

        Assert.That(resultField.Text, Is.EqualTo(result));
    }
    }
}