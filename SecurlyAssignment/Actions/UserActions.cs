using System;
using System.Threading;
using OpenQA.Selenium;
using WindowsInput;
using WindowsInput.Native;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace SecurlyAssignment.Actions
{

    public class UserActions
    {
        //Driver Initialisation
        public IWebDriver Driver { get; set; }

        // Initialize an instance of InputSimultor Class to Input Keywords
        public InputSimulator Input { get; set; }
        
        // Custom Function to Press Enter
        public void  PressEnter(InputSimulator Input)
        {
            Input.Keyboard.KeyDown(VirtualKeyCode.RETURN);
            Thread.Sleep(2000);
            Input.Keyboard.KeyUp(VirtualKeyCode.RETURN);
        }

        //Custom Function to Press Enter
        public void PressTab(InputSimulator Input)
        {
            Input.Keyboard.KeyDown(VirtualKeyCode.TAB);
            Input.Keyboard.KeyUp(VirtualKeyCode.TAB);
            Thread.Sleep(1000);
        }

        //Open Sign In Modal
        public void OpenSignInModal(InputSimulator Input)
        {
            Input.Keyboard.KeyDown(VirtualKeyCode.CONTROL);
            Input.Keyboard.KeyDown(VirtualKeyCode.SHIFT);
            Input.Keyboard.KeyPress(VirtualKeyCode.VK_M);
            Thread.Sleep(5000);
            Input.Keyboard.KeyUp(VirtualKeyCode.CONTROL);
            Input.Keyboard.KeyUp(VirtualKeyCode.SHIFT);
            Thread.Sleep(2000);
           PressEnter(Input);

        }

        // Sign In in Chrome Browser
        public void EnteruserCredentials(InputSimulator Input, string username, string password)
        {
            //Provides UserName
            Input.Keyboard.TextEntry(username);
            PressTab(Input);
            PressEnter(Input);
            Thread.Sleep(1000);

            //Provides Password and Sign In to Chrome Browser
            Input.Keyboard.TextEntry(password);
            PressTab(Input);
            PressTab(Input);
            PressEnter(Input);
            PressEnter(Input);
            Thread.Sleep(2000);
            PressTab(Input);
            Thread.Sleep(2000);
            PressTab(Input);
            Thread.Sleep(2000);
            PressEnter(Input);
            Thread.Sleep(2000);
        }

        //Naviagte to Extension Page
        public void OpenExtensionPage(InputSimulator Input, IWebDriver Driver, string url)
        {
            
            Driver.Navigate().GoToUrl(url);
            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(20000));
        }

        // Provide Extension Name ,Download and Install Extension
        public void DownloadChromExtension(InputSimulator Input, string extensionName)
        {
            //Provides Extension Name
            Driver.FindElement(By.Id("searchbox-input")).SendKeys(extensionName);
            Thread.Sleep(3000);
            PressEnter(Input);
            PressEnter(Input);
            Thread.Sleep(6000);

            //Download and Install Extension
            IWebElement elm = Driver.FindElement(By.CssSelector(".g-c-R.webstore-test-button-label"));
            elm.Click();
            Thread.Sleep(5000);
            PressTab(Input);
            PressEnter(Input);
            Thread.Sleep(30000);

        }

        // Navigation to Extension Page after Extension is downloaded
        public void NavigateToExtensionPage(IWebDriver Driver)
        {
            Driver.Navigate().GoToUrl("chrome://extensions/");
            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10000));
            
           
        }

        //Verification of Installed Extension
        public void GetExtensionName(InputSimulator Input, string expectedString)
        {
            Input.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_1);
            Thread.Sleep(3000);
            Driver.SwitchTo().Frame("extensions");
            IWebElement textElement = Driver.FindElement(By.Id(expectedString));
            Console.WriteLine(expectedString);
          
        }

    }
}
