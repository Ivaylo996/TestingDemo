using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace SeleniumWebDriver
{
    [TestClass]
    public class HomePageTests
    {
        IWebDriver driver;

        [TestInitialize]
        public void TestSetup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://app.fluxday.io/users/sign_in");
        }

        [TestCleanup]
        public void TestTeardown()
        {
            driver.Quit();
        }

        [TestCategory("LoginTesting")]
        [TestMethod]
        public void Test001LoginWithValidInput()
        {
            var username = "emp1@fluxday.io";
            var password = "password";

            var usernameTextBox = driver.FindElement(By.XPath("//*[@id=\"user_email\"]"));
            var passwordTextBox = driver.FindElement(By.XPath("//*[@id=\"user_password\"]"));

            usernameTextBox.SendKeys(username);

            passwordTextBox.SendKeys(password);

            var loginButton = driver.FindElement(By.XPath("//*[@id=\"new_user\"]/div[2]/div[3]/button"));
            loginButton.Click();

            Thread.Sleep(3000);

            var verifyResults = driver.FindElement(By.XPath("//*[@id=\"pane2\"]/div[1]/div"));
            var actualResult = verifyResults.Text.ToLower();

            var expectedResult = "Entries".ToLower();

            Assert.AreEqual(expectedResult, actualResult);

        }


        [TestCategory("LoginInvalidInputTesting")]
        [TestMethod]
        public void Test002LoginWithInvalidInput()
        {
            var username = "asdf@fluxday.io";
            var password = "asdf";

            var usernameTextBox = driver.FindElement(By.XPath("//*[@id=\"user_email\"]"));
            var passwordTextBox = driver.FindElement(By.XPath("//*[@id=\"user_password\"]"));

            usernameTextBox.SendKeys(username);

            passwordTextBox.SendKeys(password);

            var loginButton = driver.FindElement(By.XPath("//*[@id=\"new_user\"]/div[2]/div[3]/button"));
            loginButton.Click();

            Thread.Sleep(3000);

            var verifyResults = driver.FindElement(By.XPath("/html/body/script"));

            Assert.IsTrue(verifyResults.Enabled);

        }

        [TestCategory("LogoutButtonTesting")]
        [TestMethod]
        public void Test003LogoutButton()
        {
            var username = "emp1@fluxday.io";
            var password = "password";

            var usernameTextBox = driver.FindElement(By.XPath("//*[@id=\"user_email\"]"));
            var passwordTextBox = driver.FindElement(By.XPath("//*[@id=\"user_password\"]"));

            usernameTextBox.SendKeys(username);

            passwordTextBox.SendKeys(password);

            var loginButton = driver.FindElement(By.XPath("//*[@id=\"new_user\"]/div[2]/div[3]/button"));
            loginButton.Click();

            Thread.Sleep(3000);

            var logoutButton = driver.FindElement(By.XPath("/html/body/div[2]/div[1]/ul[3]/li[2]/a"));
            logoutButton.Click();

            Thread.Sleep(3000);

            var verifyLoginPage = driver.FindElement(By.XPath("//*[@id=\"new_user\"]/h2/div"));
            Assert.IsTrue(verifyLoginPage.Displayed);

        }

        [TestCategory("LogoutButtonTesting")]
        [TestMethod]
        public void Test004UserEmployeeInformationButton()
        {
            var username = "emp1@fluxday.io";
            var password = "password";

            var usernameTextBox = driver.FindElement(By.XPath("//*[@id=\"user_email\"]"));
            var passwordTextBox = driver.FindElement(By.XPath("//*[@id=\"user_password\"]"));

            usernameTextBox.SendKeys(username);

            passwordTextBox.SendKeys(password);

            var loginButton = driver.FindElement(By.XPath("//*[@id=\"new_user\"]/div[2]/div[3]/button"));
            loginButton.Click();

            Thread.Sleep(3000);

            var userInfomationtButton = driver.FindElement(By.XPath("/html/body/div[2]/div[1]/ul[3]/li[1]/a"));
            userInfomationtButton.Click();

            Thread.Sleep(3000);

            var verifyLoginPage = driver.FindElement(By.XPath("//*[@id=\"pane3\"]/div/div[1]/div[3]/img"));
            Assert.IsTrue(verifyLoginPage.Displayed);


        }


        [TestCategory("EditNicknameTests")]
        [TestMethod]
        public void Test005EditNicknameAsEmployee()
        {

            var username = "emp1@fluxday.io";
            var password = "password";

            var usernameTextBox = driver.FindElement(By.XPath("//*[@id=\"user_email\"]"));
            var passwordTextBox = driver.FindElement(By.XPath("//*[@id=\"user_password\"]"));

            usernameTextBox.SendKeys(username);

            passwordTextBox.SendKeys(password);

            var loginButton = driver.FindElement(By.XPath("//*[@id=\"new_user\"]/div[2]/div[3]/button"));
            loginButton.Click();

            Thread.Sleep(3000);

            var userInfomationtButton = driver.FindElement(By.XPath("/html/body/div[2]/div[1]/ul[3]/li[1]/a"));
            userInfomationtButton.Click();

            Thread.Sleep(3000);

            var optinsButton = driver.FindElement(By.XPath("//*[@id=\"pane3\"]/div/div[1]/div[2]/a/div"));
            optinsButton.Click();

            Thread.Sleep(3000);

            var editOptionButton = driver.FindElement(By.XPath("//*[@id=\"drop1\"]/li[1]/a"));
            editOptionButton.Click();

            Thread.Sleep(3000);

            var editedNickname = driver.FindElement(By.XPath("//*[@id=\"user_nickname\"]"));
            editedNickname.Clear();
            editedNickname.SendKeys("Employee");

            Thread.Sleep(3000);

            var saveButton = driver.FindElement(By.XPath("//*[@id=\"edit_user_27\"]/div[3]/div[2]/input"));
            saveButton.Click();

            Thread.Sleep(2000);

            var userNickname = driver.FindElement(By.XPath("//*[@id=\"pane3\"]/div/div[1]/div[4]/div/div"));
            var actualResult = userNickname.Text.ToUpper();

            var expectedResult = "(Employee)".ToUpper();
            Assert.AreEqual(expectedResult, actualResult);


        }
    }
}
