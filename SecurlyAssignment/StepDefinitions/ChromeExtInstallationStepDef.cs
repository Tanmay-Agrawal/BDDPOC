using WindowsInput;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using SecurlyAssignment.Actions;

namespace SecurlyAssignment.StepDefinitions
{

    
    [Binding]
    public sealed class ChromeExtInstallationStepDef
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
        UserActions action = new UserActions();

        [Given(@"I have signed in as user with credentials ""(.*)"" and ""(.*)""")]
        public void GivenIHaveSignedInAsUserWithCredentialsAnd(string username, string password)
        {
            
            action.Driver= new ChromeDriver();
            action.Driver.Manage().Cookies.DeleteAllCookies();
            action.Driver.Manage().Window.Maximize();
            action.Input = new InputSimulator();
            action.OpenSignInModal(action.Input);
            action.EnteruserCredentials(action.Input, username, password);
            
        }

        [Given(@"I have installed ""(.*)"" extension")]
        public void GivenIHaveInstalledExtension(string extensionname)
        {
            string ExtensionPageUrl = "https://chrome.google.com/webstore/category/extensions?hl=en-US";
            action.OpenExtensionPage(action.Input, action.Driver, ExtensionPageUrl);
            action.DownloadChromExtension(action.Input,extensionname);
        }

        [When(@"I navigate to extensions page")]
        public void WhenINavigateToExtensionsPage()
        {
            action.NavigateToExtensionPage(action.Driver);
        }

        [Then(@"I should see Chrome Extension installed with Id ""(.*)""")]
        public void ThenIShouldSeeChromeExtensionInstalledWithId(string expectedId)
        {
            action.GetExtensionName(action.Input, expectedId);
           action.Driver.Quit();
        }


    }
}
