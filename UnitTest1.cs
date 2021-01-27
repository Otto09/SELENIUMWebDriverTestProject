using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;
using FluentAssertions;
using FluentAssertions.Equivalency;

namespace UnitTestProject_SeleniumVS
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WriteFirstnameInAGivenTextboxIdentifiedById()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.intend.ro/inregistrare");
            driver.Manage().Window.Maximize();

            var textBoxFirstName = driver.FindElement(By.Id("name"));
            textBoxFirstName.Clear();
            textBoxFirstName.SendKeys("Prenume Test");

            Thread.Sleep(1000);
            string textBox = driver.FindElement(By.Id("name")).GetProperty("value");           
            Assert.AreEqual("Prenume Test", textBox);         
        }

        [TestMethod]
        public void CheckIfTheSiteIsTheOneRequired()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.intend.ro/inregistrare");
            driver.Manage().Window.Maximize();

            string URL = driver.Url;
            Assert.AreEqual(URL, "https://www.intend.ro/inregistrare");
        }

        [TestMethod]
        public void CheckAValidSubmissionForPersons()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.intend.ro/inregistrare");
            driver.Manage().Window.Maximize();

            //prenume
            var textBoxFirstName = driver.FindElement(By.Id("name"));
            textBoxFirstName.Clear();
            textBoxFirstName.SendKeys("Prenume Test2");

            //nume
            var textBoxLastName = driver.FindElement(By.Id("lastname"));
            textBoxLastName.Clear();
            textBoxLastName.SendKeys("Nume Test2");

            //telefon
            var textBoxPhone = driver.FindElement(By.Id("phone"));
            textBoxPhone.Clear();
            textBoxPhone.SendKeys("0740000072");

            //email
            var textBoxEmail = driver.FindElement(By.Id("email"));
            textBoxEmail.Clear();
            textBoxEmail.SendKeys("email72@gmail.com");

            //parola
            var textBoxPassword = driver.FindElement(By.Id("password"));
            textBoxPassword.Clear();
            textBoxPassword.SendKeys("Password3");

            //confirma parola
            var textBoxCPassword = driver.FindElement(By.Id("cpassword"));
            textBoxCPassword.Clear();
            textBoxCPassword.SendKeys("Password3");

            //adresa
            var textBoxAddress = driver.FindElement(By.Id("address"));
            textBoxAddress.Clear();
            textBoxAddress.SendKeys("Adresa Test2");

            //localitate
            var textBoxCity = driver.FindElement(By.Id("city"));
            textBoxCity.Clear();
            textBoxCity.SendKeys("Localitate Test2");

            //Judet/Sector
            var textBoxState = driver.FindElement(By.Id("state"));
            textBoxState.Clear();
            textBoxState.SendKeys("Judet Test2");

            //submit
            driver.FindElement(By.CssSelector(".register-form .form-submitter")).Click();

            //check modal
            Thread.Sleep(2000);
            string textModal = driver.FindElement(By.CssSelector(".modal-dialog p")).Text;
            Assert.AreEqual("Ati fost inregistrat cu success! Va rugam verificati-va email-ul pentru instructiunile de activare.", textModal);
        }
        [TestMethod]
        public void TestLocationAndSizeTextboxes()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.intend.ro/inregistrare");
            driver.Manage().Window.Maximize();

            var textBoxFirstName = driver.FindElement(By.Id("name"));
            textBoxFirstName.Clear();
            textBoxFirstName.SendKeys("Prenume Test3");
            var location = textBoxFirstName.Location;
            var size = textBoxFirstName.Size;

            Assert.AreEqual(325, size.Width);
            Assert.AreEqual(38, size.Height);
            Assert.AreEqual(198, location.X);
            Assert.AreEqual(422, location.Y);
        }
        [TestMethod]
        public void CheckTheExistenceOfRequiredAttributeForPersons()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.intend.ro/inregistrare");
            driver.Manage().Window.Maximize();

            //nume
            var textBoxFirstName = driver.FindElement(By.Id("name"));
            var firstNameRequired = textBoxFirstName.GetProperty("required");
            Assert.AreEqual("True", firstNameRequired);

            //prenume
            var textBoxLastName = driver.FindElement(By.Id("lastname"));
            var lastNameRequired = textBoxLastName.GetProperty("required");
            Assert.AreEqual("True", lastNameRequired);

            //telefon
            var textBoxPhone = driver.FindElement(By.Id("phone"));
            var phoneRequired = textBoxPhone.GetProperty("required");
            Assert.AreEqual("True", phoneRequired);

            //email
            var textBoxEmail = driver.FindElement(By.Id("email"));
            var emailRequired = textBoxEmail.GetProperty("required");
            Assert.AreEqual("True", emailRequired);

            //parola
            var textBoxPassword = driver.FindElement(By.Id("password"));
            var passwordRequired = textBoxPassword.GetProperty("required");
            Assert.AreEqual("True", passwordRequired);

            //confirma parola
            var textBoxCPassword = driver.FindElement(By.Id("cpassword"));
            var cPasswordRequired = textBoxCPassword.GetProperty("required");
            Assert.AreEqual("True", cPasswordRequired);

            //adresa
            var textBoxAddress = driver.FindElement(By.Id("address"));
            var addressRequired = textBoxAddress.GetProperty("required");
            Assert.AreEqual("True", addressRequired);

            //localitate
            var textBoxCity = driver.FindElement(By.Id("city"));
            var cityRequired = textBoxCity.GetProperty("required");
            Assert.AreEqual("True", cityRequired);

            //Judet/Sector
            var textBoxState = driver.FindElement(By.Id("state"));
            var stateRequired = textBoxState.GetProperty("required");
            Assert.AreEqual("True", stateRequired);
        }
        [TestMethod]
        public void CheckAValidSubmissionForCompanies()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.intend.ro/inregistrare");
            driver.Manage().Window.Maximize();

            //checkbox
            var pj = driver.FindElement(By.XPath("//li[2]/label"));
            if (pj != null)
                pj.Click();

            //nume firma
            var textBoxCompanyName = driver.FindElement(By.Id("company-name"));
            textBoxCompanyName.Clear();
            textBoxCompanyName.SendKeys("Companie Test");

            //cod unic (CUI)
            var textBoxCompanyCui = driver.FindElement(By.Id("company-cui"));
            textBoxCompanyCui.Clear();
            textBoxCompanyCui.SendKeys("100");

            //nr inregistrare (Reg. Com.)
            var textBoxCompanyReg = driver.FindElement(By.Id("company-reg"));
            textBoxCompanyReg.Clear();
            textBoxCompanyReg.SendKeys("100");

            //banca
            var textBoxCompanyBank = driver.FindElement(By.Id("company-bank"));
            textBoxCompanyBank.Clear();
            textBoxCompanyBank.SendKeys("Banca Test");

            //cont banca IBAN
            var textBoxCompanyIban = driver.FindElement(By.Id("company-iban"));
            textBoxCompanyIban.Clear();
            textBoxCompanyIban.SendKeys("100");

            //adresa
            var textBoxAddress = driver.FindElement(By.Id("company-address"));
            textBoxAddress.Clear();
            textBoxAddress.SendKeys("Adresa Test2");

            //localitate
            var textBoxCity = driver.FindElement(By.Id("company-city"));
            textBoxCity.Clear();
            textBoxCity.SendKeys("Localitate Test2");

            //Judet/Sector
            var textBoxState = driver.FindElement(By.Id("company-state"));
            textBoxState.Clear();
            textBoxState.SendKeys("Judet Test2");

            //prenume
            var textBoxFirstName = driver.FindElement(By.Id("name"));
            textBoxFirstName.Clear();
            textBoxFirstName.SendKeys("Prenume Test2");

            //nume
            var textBoxLastName = driver.FindElement(By.Id("lastname"));
            textBoxLastName.Clear();
            textBoxLastName.SendKeys("Nume Test2");

            //telefon
            var textBoxPhone = driver.FindElement(By.Id("phone"));
            textBoxPhone.Clear();
            textBoxPhone.SendKeys("0740000071");

            //email
            var textBoxEmail = driver.FindElement(By.Id("email"));
            textBoxEmail.Clear();
            textBoxEmail.SendKeys("email71@gmail.com");

            //parola
            var textBoxPassword = driver.FindElement(By.Id("password"));
            textBoxPassword.Clear();
            textBoxPassword.SendKeys("Password3");

            //confirma parola
            var textBoxCPassword = driver.FindElement(By.Id("cpassword"));
            textBoxCPassword.Clear();
            textBoxCPassword.SendKeys("Password3");

            //adresa
            var textBoxPersonAddress = driver.FindElement(By.Id("address"));
            textBoxPersonAddress.Clear();
            textBoxPersonAddress.SendKeys("Adresa Test2");

            //localitate
            var textBoxPersonCity = driver.FindElement(By.Id("city"));
            textBoxPersonCity.Clear();
            textBoxPersonCity.SendKeys("Localitate Test2");

            //Judet/Sector
            var textBoxPersonState = driver.FindElement(By.Id("state"));
            textBoxPersonState.Clear();
            textBoxPersonState.SendKeys("Judet Test2");

            //submit
            driver.FindElement(By.XPath("(//a[contains(text(),'Inregistrare')])[3]")).Click();

            //check modal
            Thread.Sleep(2000);
            string textModal = driver.FindElement(By.XPath("//div[@id='window']/div/div/h5")).Text;
            Assert.AreEqual("ACTIUNE REUSITA!", textModal);
        }
        [TestMethod]
        public void CheckTheExistenceOfRequiredAttributeForCompanies()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.intend.ro/inregistrare");
            driver.Manage().Window.Maximize();

            //checkbox
            var pj = driver.FindElement(By.XPath("//li[2]/label"));
            if (pj != null)
                pj.Click();

            //nume firma
            var textBoxCompanyName = driver.FindElement(By.Id("company-name"));
            var companyNameRequired = textBoxCompanyName.GetProperty("required");
            Assert.AreEqual("True", companyNameRequired);

            //cod unic (CUI)
            var textBoxCompanyCui = driver.FindElement(By.Id("company-cui"));
            var companyCuiRequired = textBoxCompanyCui.GetProperty("required");
            Assert.AreEqual("True", companyCuiRequired);

            //nr inregistrare (Reg. Com.)
            var textBoxCompanyReg = driver.FindElement(By.Id("company-reg"));
            var companyRegRequired = textBoxCompanyReg.GetProperty("required");
            Assert.AreEqual("True", companyRegRequired);

            //banca
            var textBoxCompanyBank = driver.FindElement(By.Id("company-bank"));
            var companyBankRequired = textBoxCompanyBank.GetProperty("required");
            Assert.AreEqual("False", companyBankRequired);

            //cont banca IBAN
            var textBoxCompanyIban = driver.FindElement(By.Id("company-iban"));
            var companyIbanRequired = textBoxCompanyIban.GetProperty("required");
            Assert.AreEqual("False", companyIbanRequired);

            //adresa
            var textBoxAddress = driver.FindElement(By.Id("address"));
            var addressRequired = textBoxAddress.GetProperty("required");
            Assert.AreEqual("True", addressRequired);

            //localitate
            var textBoxCity = driver.FindElement(By.Id("city"));
            var cityRequired = textBoxCity.GetProperty("required");
            Assert.AreEqual("True", cityRequired);

            //Judet/Sector
            var textBoxState = driver.FindElement(By.Id("state"));
            var stateRequired = textBoxState.GetProperty("required");
            Assert.AreEqual("True", stateRequired);
        }
        [TestMethod]
        public void CheckPhoneAndEmailReuse()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.intend.ro/inregistrare");
            driver.Manage().Window.Maximize();

            //checkbox
            var pj = driver.FindElement(By.XPath("//li[2]/label"));
            if (pj != null)
                pj.Click();

            //nume firma
            var textBoxCompanyName = driver.FindElement(By.Id("company-name"));
            textBoxCompanyName.Clear();
            textBoxCompanyName.SendKeys("Companie Test");

            //cod unic (CUI)
            var textBoxCompanyCui = driver.FindElement(By.Id("company-cui"));
            textBoxCompanyCui.Clear();
            textBoxCompanyCui.SendKeys("100");

            //nr inregistrare (Reg. Com.)
            var textBoxCompanyReg = driver.FindElement(By.Id("company-reg"));
            textBoxCompanyReg.Clear();
            textBoxCompanyReg.SendKeys("100");

            //banca
            var textBoxCompanyBank = driver.FindElement(By.Id("company-bank"));
            textBoxCompanyBank.Clear();
            textBoxCompanyBank.SendKeys("Banca Test");

            //cont banca IBAN
            var textBoxCompanyIban = driver.FindElement(By.Id("company-iban"));
            textBoxCompanyIban.Clear();
            textBoxCompanyIban.SendKeys("100");

            //adresa
            var textBoxAddress = driver.FindElement(By.Id("company-address"));
            textBoxAddress.Clear();
            textBoxAddress.SendKeys("Adresa Test2");

            //localitate
            var textBoxCity = driver.FindElement(By.Id("company-city"));
            textBoxCity.Clear();
            textBoxCity.SendKeys("Localitate Test2");

            //Judet/Sector
            var textBoxState = driver.FindElement(By.Id("company-state"));
            textBoxState.Clear();
            textBoxState.SendKeys("Judet Test2");

            //prenume
            var textBoxFirstName = driver.FindElement(By.Id("name"));
            textBoxFirstName.Clear();
            textBoxFirstName.SendKeys("Prenume Test2");

            //nume
            var textBoxLastName = driver.FindElement(By.Id("lastname"));
            textBoxLastName.Clear();
            textBoxLastName.SendKeys("Nume Test2");

            //telefon
            var textBoxPhone = driver.FindElement(By.Id("phone"));
            textBoxPhone.Clear();
            textBoxPhone.SendKeys("0740000065");

            //email
            var textBoxEmail = driver.FindElement(By.Id("email"));
            textBoxEmail.Clear();
            textBoxEmail.SendKeys("email65@gmail.com");

            //parola
            var textBoxPassword = driver.FindElement(By.Id("password"));
            textBoxPassword.Clear();
            textBoxPassword.SendKeys("Password3");

            //confirma parola
            var textBoxCPassword = driver.FindElement(By.Id("cpassword"));
            textBoxCPassword.Clear();
            textBoxCPassword.SendKeys("Password3");

            //adresa
            var textBoxPersonAddress = driver.FindElement(By.Id("address"));
            textBoxPersonAddress.Clear();
            textBoxPersonAddress.SendKeys("Adresa Test2");

            //localitate
            var textBoxPersonCity = driver.FindElement(By.Id("city"));
            textBoxPersonCity.Clear();
            textBoxPersonCity.SendKeys("Localitate Test2");

            //Judet/Sector
            var textBoxPersonState = driver.FindElement(By.Id("state"));
            textBoxPersonState.Clear();
            textBoxPersonState.SendKeys("Judet Test2");

            //submit
            driver.FindElement(By.XPath("(//a[contains(text(),'Inregistrare')])[3]")).Click();

            //check modal
            Thread.Sleep(2000);
            string textModal = driver.FindElement(By.XPath("//div[@id='window']/div/div/h5")).Text;
            string actiuneNereusita = "ACTIUNE NEREUSITA!";
            Assert.AreEqual(actiuneNereusita, textModal);
        }

        [TestMethod]
        public void NavigatetoUrlAndPressSubmitButton()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.intend.ro/inregistrare");
            driver.Manage().Window.Maximize();

            //submit
            driver.FindElement(By.CssSelector(".register-form .form-submitter")).Click();

            //Check validation message
            string message = driver.FindElement(By.Id("name")).GetProperty("validationMessage");
            Assert.AreEqual("Please fill out this field.", message);
        }

        [TestMethod]
        public void WriteUntilLastnameInTextboxesIdentifiedByIdAndPressSubmitButton()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.intend.ro/inregistrare");
            driver.Manage().Window.Maximize();

            //prenume
            var textBoxFirstName = driver.FindElement(By.Id("name"));
            textBoxFirstName.Clear();
            textBoxFirstName.SendKeys("Prenume Test2");

            //submit
            driver.FindElement(By.CssSelector(".register-form .form-submitter")).Click();

            //Check validation message
            string message = driver.FindElement(By.Id("lastname")).GetProperty("validationMessage");
            Assert.AreEqual("Please fill out this field.", message);
        }

        [TestMethod]
        public void WriteUntilPhoneInTextboxesIdentifiedByIdAndPressSubmitButton()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.intend.ro/inregistrare");
            driver.Manage().Window.Maximize();

            //prenume
            var textBoxLastName = driver.FindElement(By.Id("lastname"));
            textBoxLastName.Clear();
            textBoxLastName.SendKeys("Nume Test2");

            //nume
            var textBoxFirstName = driver.FindElement(By.Id("name"));
            textBoxFirstName.Clear();
            textBoxFirstName.SendKeys("Prenume Test2");

            //submit
            driver.FindElement(By.CssSelector(".register-form .form-submitter")).Click();

            //Check validatiom message
            string message = driver.FindElement(By.Id("phone")).GetProperty("validationMessage");
            Assert.AreEqual("Please fill out this field.", message);
        }

        [TestMethod]
        public void WriteUntilEmailInTextboxesIdentifiedByIdAndPressSubmitButton()
        {

            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.intend.ro/inregistrare");
            driver.Manage().Window.Maximize();

            //prenume
            var textBoxLastName = driver.FindElement(By.Id("lastname"));
            textBoxLastName.Clear();
            textBoxLastName.SendKeys("Nume Test2");

            //nume
            var textBoxFirstName = driver.FindElement(By.Id("name"));
            textBoxFirstName.Clear();
            textBoxFirstName.SendKeys("Prenume Test2");

            //telefon
            var textBoxPhone = driver.FindElement(By.Id("phone"));
            textBoxPhone.Clear();
            textBoxPhone.SendKeys("0740000065");

            //submit
            driver.FindElement(By.CssSelector(".register-form .form-submitter")).Click();

            //Check validatiom message
            string message = driver.FindElement(By.Id("email")).GetProperty("validationMessage");
            Assert.AreEqual("Please fill out this field.", message);
            }

        [TestMethod]
        public void WriteUntilPasswordInTextboxesIdentifiedByIdAndPressSubmitButton()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.intend.ro/inregistrare");
            driver.Manage().Window.Maximize();

            //prenume
            var textBoxLastName = driver.FindElement(By.Id("lastname"));
            textBoxLastName.Clear();
            textBoxLastName.SendKeys("Nume Test2");

            //nume
            var textBoxFirstName = driver.FindElement(By.Id("name"));
            textBoxFirstName.Clear();
            textBoxFirstName.SendKeys("Prenume Test2");

            //telefon
            var textBoxPhone = driver.FindElement(By.Id("phone"));
            textBoxPhone.Clear();
            textBoxPhone.SendKeys("0740000065");

            //email
            var textBoxEmail = driver.FindElement(By.Id("email"));
            textBoxEmail.Clear();
            textBoxEmail.SendKeys("email65@gmail.com");

            //submit
            driver.FindElement(By.CssSelector(".register-form .form-submitter")).Click();

            //Check validatiom message
            string message = driver.FindElement(By.Id("password")).GetProperty("validationMessage");
            Assert.AreEqual("Please fill out this field.", message);
        }

        [TestMethod]
        public void WriteUntilCPasswordInTextboxesIdentifiedByIdAndPressSubmitButton()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.intend.ro/inregistrare");
            driver.Manage().Window.Maximize();

            //prenume
            var textBoxLastName = driver.FindElement(By.Id("lastname"));
            textBoxLastName.Clear();
            textBoxLastName.SendKeys("Nume Test2");

            //nume
            var textBoxFirstName = driver.FindElement(By.Id("name"));
            textBoxFirstName.Clear();
            textBoxFirstName.SendKeys("Prenume Test2");

            //telefon
            var textBoxPhone = driver.FindElement(By.Id("phone"));
            textBoxPhone.Clear();
            textBoxPhone.SendKeys("0740000065");

            //email
            var textBoxEmail = driver.FindElement(By.Id("email"));
            textBoxEmail.Clear();
            textBoxEmail.SendKeys("email65@gmail.com");

            //password
            var textBoxPassword = driver.FindElement(By.Id("password"));
            textBoxPassword.Clear();
            textBoxPassword.SendKeys("Password3");

            //submit
            driver.FindElement(By.CssSelector(".register-form .form-submitter")).Click();

            //Check validatiom message
            string message = driver.FindElement(By.Id("cpassword")).GetProperty("validationMessage");
            Assert.AreEqual("Please fill out this field.", message);
        }

        [TestMethod]
        public void WriteUntilPersonAddressInTextboxesIdentifiedByIdAndPressSubmitButton()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.intend.ro/inregistrare");
            driver.Manage().Window.Maximize();

            //prenume
            var textBoxLastName = driver.FindElement(By.Id("lastname"));
            textBoxLastName.Clear();
            textBoxLastName.SendKeys("Nume Test2");

            //nume
            var textBoxFirstName = driver.FindElement(By.Id("name"));
            textBoxFirstName.Clear();
            textBoxFirstName.SendKeys("Prenume Test2");

            //telefon
            var textBoxPhone = driver.FindElement(By.Id("phone"));
            textBoxPhone.Clear();
            textBoxPhone.SendKeys("0740000065");

            //email
            var textBoxEmail = driver.FindElement(By.Id("email"));
            textBoxEmail.Clear();
            textBoxEmail.SendKeys("email65@gmail.com");

            //password
            var textBoxPassword = driver.FindElement(By.Id("password"));
            textBoxPassword.Clear();
            textBoxPassword.SendKeys("Password3");

            //confirm password
            var textBoxCPassword = driver.FindElement(By.Id("cpassword"));
            textBoxCPassword.Clear();
            textBoxCPassword.SendKeys("Password3");

            //submit
            driver.FindElement(By.CssSelector(".register-form .form-submitter")).Click();

            //Check validatiom message
            string message = driver.FindElement(By.Id("address")).GetProperty("validationMessage");
            Assert.AreEqual("Please fill out this field.", message);
        }

        [TestMethod]
        public void WriteUntilPersonCityInTextboxesIdentifiedByIdAndPressSubmitButton()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.intend.ro/inregistrare");
            driver.Manage().Window.Maximize();

            //prenume
            var textBoxLastName = driver.FindElement(By.Id("lastname"));
            textBoxLastName.Clear();
            textBoxLastName.SendKeys("Nume Test2");

            //nume
            var textBoxFirstName = driver.FindElement(By.Id("name"));
            textBoxFirstName.Clear();
            textBoxFirstName.SendKeys("Prenume Test2");

            //telefon
            var textBoxPhone = driver.FindElement(By.Id("phone"));
            textBoxPhone.Clear();
            textBoxPhone.SendKeys("0740000065");

            //email
            var textBoxEmail = driver.FindElement(By.Id("email"));
            textBoxEmail.Clear();
            textBoxEmail.SendKeys("email65@gmail.com");

            //password
            var textBoxPassword = driver.FindElement(By.Id("password"));
            textBoxPassword.Clear();
            textBoxPassword.SendKeys("Password3");

            //confirma parola
            var textBoxCPassword = driver.FindElement(By.Id("cpassword"));
            textBoxCPassword.Clear();
            textBoxCPassword.SendKeys("Password3");

            //adresa
            var textBoxPersonAddress = driver.FindElement(By.Id("address"));
            textBoxPersonAddress.Clear();
            textBoxPersonAddress.SendKeys("Adresa Test2");

            //submit
            driver.FindElement(By.CssSelector(".register-form .form-submitter")).Click();

            //Check validatiom message
            string message = driver.FindElement(By.Id("city")).GetProperty("validationMessage");
            Assert.AreEqual("Please fill out this field.", message);
        }

        [TestMethod]
        public void WriteUntilPersonStateInTextboxesIdentifiedByIdAndPressSubmitButton()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.intend.ro/inregistrare");
            driver.Manage().Window.Maximize();

            //prenume
            var textBoxLastName = driver.FindElement(By.Id("lastname"));
            textBoxLastName.Clear();
            textBoxLastName.SendKeys("Nume Test2");

            //nume
            var textBoxFirstName = driver.FindElement(By.Id("name"));
            textBoxFirstName.Clear();
            textBoxFirstName.SendKeys("Prenume Test2");

            //telefon
            var textBoxPhone = driver.FindElement(By.Id("phone"));
            textBoxPhone.Clear();
            textBoxPhone.SendKeys("0740000065");

            //email
            var textBoxEmail = driver.FindElement(By.Id("email"));
            textBoxEmail.Clear();
            textBoxEmail.SendKeys("email65@gmail.com");

            //password
            var textBoxPassword = driver.FindElement(By.Id("password"));
            textBoxPassword.Clear();
            textBoxPassword.SendKeys("Password3");

            //confirma parola
            var textBoxCPassword = driver.FindElement(By.Id("cpassword"));
            textBoxCPassword.Clear();
            textBoxCPassword.SendKeys("Password3");

            //adresa
            var textBoxPersonAddress = driver.FindElement(By.Id("address"));
            textBoxPersonAddress.Clear();
            textBoxPersonAddress.SendKeys("Adresa Test2");

            //localitate
            var textBoxPersonCity = driver.FindElement(By.Id("city"));
            textBoxPersonCity.Clear();
            textBoxPersonCity.SendKeys("Localitate Test2");

            //submit
            driver.FindElement(By.CssSelector(".register-form .form-submitter")).Click();

            //Check validatiom message
            string message = driver.FindElement(By.Id("state")).GetProperty("validationMessage");
            Assert.AreEqual("Please fill out this field.", message);
        }

        [TestMethod]

        public void WriteUntilCompanyNameInTextboxesIdentifiedByIdAndPressSubmitButton()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.intend.ro/inregistrare");
            driver.Manage().Window.Maximize();

            //checkbox
            var pj = driver.FindElement(By.XPath("//li[2]/label"));
            if (pj != null)
                pj.Click();

            //prenume
            var textBoxFirstName = driver.FindElement(By.Id("name"));
            textBoxFirstName.Clear();
            textBoxFirstName.SendKeys("Prenume Test2");

            //nume
            var textBoxLastName = driver.FindElement(By.Id("lastname"));
            textBoxLastName.Clear();
            textBoxLastName.SendKeys("Nume Test2");

            //telefon
            var textBoxPhone = driver.FindElement(By.Id("phone"));
            textBoxPhone.Clear();
            textBoxPhone.SendKeys("0740000069");

            //email
            var textBoxEmail = driver.FindElement(By.Id("email"));
            textBoxEmail.Clear();
            textBoxEmail.SendKeys("email69@gmail.com");

            //parola
            var textBoxPassword = driver.FindElement(By.Id("password"));
            textBoxPassword.Clear();
            textBoxPassword.SendKeys("Password3");

            //confirma parola
            var textBoxCPassword = driver.FindElement(By.Id("cpassword"));
            textBoxCPassword.Clear();
            textBoxCPassword.SendKeys("Password3");

            //adresa
            var textBoxAddress = driver.FindElement(By.Id("address"));
            textBoxAddress.Clear();
            textBoxAddress.SendKeys("Adresa Test2");

            //localitate
            var textBoxCity = driver.FindElement(By.Id("city"));
            textBoxCity.Clear();
            textBoxCity.SendKeys("Localitate Test2");

            //Judet/Sector
            var textBoxState = driver.FindElement(By.Id("state"));
            textBoxState.Clear();
            textBoxState.SendKeys("Judet Test2");

            //submit
            driver.FindElement(By.CssSelector(".register-form .form-submitter")).Click();

            //Check validatiom message
            string message = driver.FindElement(By.Id("company-name")).GetProperty("validationMessage");
            Assert.AreEqual("Please fill out this field.", message);
        }

        [TestMethod]
        public void WriteUntilCompanyCuiInTextboxesIdentifiedByIdAndPressSubmitButton()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.intend.ro/inregistrare");
            driver.Manage().Window.Maximize();

            //checkbox
            var pj = driver.FindElement(By.XPath("//li[2]/label"));
            if (pj != null)
                pj.Click();

            //prenume
            var textBoxFirstName = driver.FindElement(By.Id("name"));
            textBoxFirstName.Clear();
            textBoxFirstName.SendKeys("Prenume Test2");

            //nume
            var textBoxLastName = driver.FindElement(By.Id("lastname"));
            textBoxLastName.Clear();
            textBoxLastName.SendKeys("Nume Test2");

            //telefon
            var textBoxPhone = driver.FindElement(By.Id("phone"));
            textBoxPhone.Clear();
            textBoxPhone.SendKeys("0740000069");

            //email
            var textBoxEmail = driver.FindElement(By.Id("email"));
            textBoxEmail.Clear();
            textBoxEmail.SendKeys("email69@gmail.com");

            //parola
            var textBoxPassword = driver.FindElement(By.Id("password"));
            textBoxPassword.Clear();
            textBoxPassword.SendKeys("Password3");

            //confirma parola
            var textBoxCPassword = driver.FindElement(By.Id("cpassword"));
            textBoxCPassword.Clear();
            textBoxCPassword.SendKeys("Password3");

            //adresa
            var textBoxAddress = driver.FindElement(By.Id("address"));
            textBoxAddress.Clear();
            textBoxAddress.SendKeys("Adresa Test2");

            //localitate
            var textBoxCity = driver.FindElement(By.Id("city"));
            textBoxCity.Clear();
            textBoxCity.SendKeys("Localitate Test2");

            //Judet/Sector
            var textBoxState = driver.FindElement(By.Id("state"));
            textBoxState.Clear();
            textBoxState.SendKeys("Judet Test2");

            //nume firma
            var textBoxCompanyName = driver.FindElement(By.Id("company-name"));
            textBoxCompanyName.Clear();
            textBoxCompanyName.SendKeys("Companie Test");

            //submit
            driver.FindElement(By.CssSelector(".register-form .form-submitter")).Click();

            //Check validatiom message
            string message = driver.FindElement(By.Id("company-cui")).GetProperty("validationMessage");
            Assert.AreEqual("Please fill out this field.", message);
        }

        [TestMethod]
        public void WriteUntilCompanyRegInTextboxesIdentifiedByIdAndPressSubmitButton()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.intend.ro/inregistrare");
            driver.Manage().Window.Maximize();

            //checkbox
            var pj = driver.FindElement(By.XPath("//li[2]/label"));
            if (pj != null)
                pj.Click();

            //prenume
            var textBoxFirstName = driver.FindElement(By.Id("name"));
            textBoxFirstName.Clear();
            textBoxFirstName.SendKeys("Prenume Test2");

            //nume
            var textBoxLastName = driver.FindElement(By.Id("lastname"));
            textBoxLastName.Clear();
            textBoxLastName.SendKeys("Nume Test2");

            //telefon
            var textBoxPhone = driver.FindElement(By.Id("phone"));
            textBoxPhone.Clear();
            textBoxPhone.SendKeys("0740000069");

            //email
            var textBoxEmail = driver.FindElement(By.Id("email"));
            textBoxEmail.Clear();
            textBoxEmail.SendKeys("email69@gmail.com");

            //parola
            var textBoxPassword = driver.FindElement(By.Id("password"));
            textBoxPassword.Clear();
            textBoxPassword.SendKeys("Password3");

            //confirma parola
            var textBoxCPassword = driver.FindElement(By.Id("cpassword"));
            textBoxCPassword.Clear();
            textBoxCPassword.SendKeys("Password3");

            //adresa
            var textBoxAddress = driver.FindElement(By.Id("address"));
            textBoxAddress.Clear();
            textBoxAddress.SendKeys("Adresa Test2");

            //localitate
            var textBoxCity = driver.FindElement(By.Id("city"));
            textBoxCity.Clear();
            textBoxCity.SendKeys("Localitate Test2");

            //Judet/Sector
            var textBoxState = driver.FindElement(By.Id("state"));
            textBoxState.Clear();
            textBoxState.SendKeys("Judet Test2");

            //nume firma
            var textBoxCompanyName = driver.FindElement(By.Id("company-name"));
            textBoxCompanyName.Clear();
            textBoxCompanyName.SendKeys("Companie Test");

            //cod unic (CUI)
            var textBoxCompanyCui = driver.FindElement(By.Id("company-cui"));
            textBoxCompanyCui.Clear();
            textBoxCompanyCui.SendKeys("100");

            //submit
            driver.FindElement(By.CssSelector(".register-form .form-submitter")).Click();

            //Check validatiom message
            string message = driver.FindElement(By.Id("company-reg")).GetProperty("validationMessage");
            Assert.AreEqual("Please fill out this field.", message);
        }

        [TestMethod]
        public void WriteUntilCompanyBankInTextboxesIdentifiedByIdAndPressSubmitButton()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.intend.ro/inregistrare");
            driver.Manage().Window.Maximize();

            //checkbox
            var pj = driver.FindElement(By.XPath("//li[2]/label"));
            if (pj != null)
                pj.Click();

            //prenume
            var textBoxFirstName = driver.FindElement(By.Id("name"));
            textBoxFirstName.Clear();
            textBoxFirstName.SendKeys("Prenume Test2");

            //nume
            var textBoxLastName = driver.FindElement(By.Id("lastname"));
            textBoxLastName.Clear();
            textBoxLastName.SendKeys("Nume Test2");

            //telefon
            var textBoxPhone = driver.FindElement(By.Id("phone"));
            textBoxPhone.Clear();
            textBoxPhone.SendKeys("0740000069");

            //email
            var textBoxEmail = driver.FindElement(By.Id("email"));
            textBoxEmail.Clear();
            textBoxEmail.SendKeys("email69@gmail.com");

            //parola
            var textBoxPassword = driver.FindElement(By.Id("password"));
            textBoxPassword.Clear();
            textBoxPassword.SendKeys("Password3");

            //confirma parola
            var textBoxCPassword = driver.FindElement(By.Id("cpassword"));
            textBoxCPassword.Clear();
            textBoxCPassword.SendKeys("Password3");

            //adresa
            var textBoxAddress = driver.FindElement(By.Id("address"));
            textBoxAddress.Clear();
            textBoxAddress.SendKeys("Adresa Test2");

            //localitate
            var textBoxCity = driver.FindElement(By.Id("city"));
            textBoxCity.Clear();
            textBoxCity.SendKeys("Localitate Test2");

            //Judet/Sector
            var textBoxState = driver.FindElement(By.Id("state"));
            textBoxState.Clear();
            textBoxState.SendKeys("Judet Test2");

            //nume firma
            var textBoxCompanyName = driver.FindElement(By.Id("company-name"));
            textBoxCompanyName.Clear();
            textBoxCompanyName.SendKeys("Companie Test");

            //cod unic (CUI)
            var textBoxCompanyCui = driver.FindElement(By.Id("company-cui"));
            textBoxCompanyCui.Clear();
            textBoxCompanyCui.SendKeys("100");

            //nr inregistrare (Reg. Com.)
            var textBoxCompanyReg = driver.FindElement(By.Id("company-reg"));
            textBoxCompanyReg.Clear();
            textBoxCompanyReg.SendKeys("100");

            //submit
            driver.FindElement(By.CssSelector(".register-form .form-submitter")).Click();

            //Check validatiom message
            string message = driver.FindElement(By.Id("company-address")).GetProperty("validationMessage");
            Assert.AreEqual("Please fill out this field.", message);
        }

        [TestMethod]
        public void WriteUntilCompanyIbanInTextboxesIdentifiedByIdAndPressSubmitButton()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.intend.ro/inregistrare");
            driver.Manage().Window.Maximize();

            //checkbox
            var pj = driver.FindElement(By.XPath("//li[2]/label"));
            if (pj != null)
                pj.Click();

            //prenume
            var textBoxFirstName = driver.FindElement(By.Id("name"));
            textBoxFirstName.Clear();
            textBoxFirstName.SendKeys("Prenume Test2");

            //nume
            var textBoxLastName = driver.FindElement(By.Id("lastname"));
            textBoxLastName.Clear();
            textBoxLastName.SendKeys("Nume Test2");

            //telefon
            var textBoxPhone = driver.FindElement(By.Id("phone"));
            textBoxPhone.Clear();
            textBoxPhone.SendKeys("0740000069");

            //email
            var textBoxEmail = driver.FindElement(By.Id("email"));
            textBoxEmail.Clear();
            textBoxEmail.SendKeys("email69@gmail.com");

            //parola
            var textBoxPassword = driver.FindElement(By.Id("password"));
            textBoxPassword.Clear();
            textBoxPassword.SendKeys("Password3");

            //confirma parola
            var textBoxCPassword = driver.FindElement(By.Id("cpassword"));
            textBoxCPassword.Clear();
            textBoxCPassword.SendKeys("Password3");

            //adresa
            var textBoxAddress = driver.FindElement(By.Id("address"));
            textBoxAddress.Clear();
            textBoxAddress.SendKeys("Adresa Test2");

            //localitate
            var textBoxCity = driver.FindElement(By.Id("city"));
            textBoxCity.Clear();
            textBoxCity.SendKeys("Localitate Test2");

            //Judet/Sector
            var textBoxState = driver.FindElement(By.Id("state"));
            textBoxState.Clear();
            textBoxState.SendKeys("Judet Test2");

            //nume firma
            var textBoxCompanyName = driver.FindElement(By.Id("company-name"));
            textBoxCompanyName.Clear();
            textBoxCompanyName.SendKeys("Companie Test");

            //cod unic (CUI)
            var textBoxCompanyCui = driver.FindElement(By.Id("company-cui"));
            textBoxCompanyCui.Clear();
            textBoxCompanyCui.SendKeys("100");

            //nr inregistrare (Reg. Com.)
            var textBoxCompanyReg = driver.FindElement(By.Id("company-reg"));
            textBoxCompanyReg.Clear();
            textBoxCompanyReg.SendKeys("100");

            //banca
            var textBoxCompanyBank = driver.FindElement(By.Id("company-bank"));
            textBoxCompanyBank.Clear();
            textBoxCompanyBank.SendKeys("Banca Test");

            //submit
            driver.FindElement(By.CssSelector(".register-form .form-submitter")).Click();

            //Check validatiom message
            string message = driver.FindElement(By.Id("company-address")).GetProperty("validationMessage");
            Assert.AreEqual("Please fill out this field.", message);
        }

        [TestMethod]
        public void WriteUntilAddressInTextboxesIdentifiedByIdAndPressSubmitButton()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.intend.ro/inregistrare");
            driver.Manage().Window.Maximize();

            //checkbox
            var pj = driver.FindElement(By.XPath("//li[2]/label"));
            if (pj != null)
                pj.Click();

            //prenume
            var textBoxFirstName = driver.FindElement(By.Id("name"));
            textBoxFirstName.Clear();
            textBoxFirstName.SendKeys("Prenume Test2");

            //nume
            var textBoxLastName = driver.FindElement(By.Id("lastname"));
            textBoxLastName.Clear();
            textBoxLastName.SendKeys("Nume Test2");

            //telefon
            var textBoxPhone = driver.FindElement(By.Id("phone"));
            textBoxPhone.Clear();
            textBoxPhone.SendKeys("0740000069");

            //email
            var textBoxEmail = driver.FindElement(By.Id("email"));
            textBoxEmail.Clear();
            textBoxEmail.SendKeys("email69@gmail.com");

            //parola
            var textBoxPassword = driver.FindElement(By.Id("password"));
            textBoxPassword.Clear();
            textBoxPassword.SendKeys("Password3");

            //confirma parola
            var textBoxCPassword = driver.FindElement(By.Id("cpassword"));
            textBoxCPassword.Clear();
            textBoxCPassword.SendKeys("Password3");

            //adresa
            var textBoxAddress = driver.FindElement(By.Id("address"));
            textBoxAddress.Clear();
            textBoxAddress.SendKeys("Adresa Test2");

            //localitate
            var textBoxCity = driver.FindElement(By.Id("city"));
            textBoxCity.Clear();
            textBoxCity.SendKeys("Localitate Test2");

            //Judet/Sector
            var textBoxState = driver.FindElement(By.Id("state"));
            textBoxState.Clear();
            textBoxState.SendKeys("Judet Test2");

            //nume firma
            var textBoxCompanyName = driver.FindElement(By.Id("company-name"));
            textBoxCompanyName.Clear();
            textBoxCompanyName.SendKeys("Companie Test");

            //cod unic (CUI)
            var textBoxCompanyCui = driver.FindElement(By.Id("company-cui"));
            textBoxCompanyCui.Clear();
            textBoxCompanyCui.SendKeys("100");

            //nr inregistrare (Reg. Com.)
            var textBoxCompanyReg = driver.FindElement(By.Id("company-reg"));
            textBoxCompanyReg.Clear();
            textBoxCompanyReg.SendKeys("100");

            //banca
            var textBoxCompanyBank = driver.FindElement(By.Id("company-bank"));
            textBoxCompanyBank.Clear();
            textBoxCompanyBank.SendKeys("Banca Test");

            //cont banca IBAN
            var textBoxCompanyIban = driver.FindElement(By.Id("company-iban"));
            textBoxCompanyIban.Clear();
            textBoxCompanyIban.SendKeys("100");

            //submit
            driver.FindElement(By.CssSelector(".register-form .form-submitter")).Click();

            //Check validatiom message
            string message = driver.FindElement(By.Id("company-address")).GetProperty("validationMessage");
            Assert.AreEqual("Please fill out this field.", message);
        }

        [TestMethod]
        public void WriteUntilCityInTextboxesIdentifiedByIdAndPressSubmitButton()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.intend.ro/inregistrare");
            driver.Manage().Window.Maximize();

            //checkbox
            var pj = driver.FindElement(By.XPath("//li[2]/label"));
            if (pj != null)
                pj.Click();

            //prenume
            var textBoxFirstName = driver.FindElement(By.Id("name"));
            textBoxFirstName.Clear();
            textBoxFirstName.SendKeys("Prenume Test2");

            //nume
            var textBoxLastName = driver.FindElement(By.Id("lastname"));
            textBoxLastName.Clear();
            textBoxLastName.SendKeys("Nume Test2");

            //telefon
            var textBoxPhone = driver.FindElement(By.Id("phone"));
            textBoxPhone.Clear();
            textBoxPhone.SendKeys("0740000069");

            //email
            var textBoxEmail = driver.FindElement(By.Id("email"));
            textBoxEmail.Clear();
            textBoxEmail.SendKeys("email69@gmail.com");

            //parola
            var textBoxPassword = driver.FindElement(By.Id("password"));
            textBoxPassword.Clear();
            textBoxPassword.SendKeys("Password3");

            //confirma parola
            var textBoxCPassword = driver.FindElement(By.Id("cpassword"));
            textBoxCPassword.Clear();
            textBoxCPassword.SendKeys("Password3");

            //adresa
            var textBoxAddress = driver.FindElement(By.Id("address"));
            textBoxAddress.Clear();
            textBoxAddress.SendKeys("Adresa Test2");

            //localitate
            var textBoxCity = driver.FindElement(By.Id("city"));
            textBoxCity.Clear();
            textBoxCity.SendKeys("Localitate Test2");

            //Judet/Sector
            var textBoxState = driver.FindElement(By.Id("state"));
            textBoxState.Clear();
            textBoxState.SendKeys("Judet Test2");

            //nume firma
            var textBoxCompanyName = driver.FindElement(By.Id("company-name"));
            textBoxCompanyName.Clear();
            textBoxCompanyName.SendKeys("Companie Test");

            //cod unic (CUI)
            var textBoxCompanyCui = driver.FindElement(By.Id("company-cui"));
            textBoxCompanyCui.Clear();
            textBoxCompanyCui.SendKeys("100");

            //nr inregistrare (Reg. Com.)
            var textBoxCompanyReg = driver.FindElement(By.Id("company-reg"));
            textBoxCompanyReg.Clear();
            textBoxCompanyReg.SendKeys("100");

            //banca
            var textBoxCompanyBank = driver.FindElement(By.Id("company-bank"));
            textBoxCompanyBank.Clear();
            textBoxCompanyBank.SendKeys("Banca Test");

            //cont banca IBAN
            var textBoxCompanyIban = driver.FindElement(By.Id("company-iban"));
            textBoxCompanyIban.Clear();
            textBoxCompanyIban.SendKeys("100");

            //adresa
            var textBoxCompanyAddress = driver.FindElement(By.Id("company-address"));
            textBoxCompanyAddress.Clear();
            textBoxCompanyAddress.SendKeys("Adresa Test2");

            //submit
            driver.FindElement(By.CssSelector(".register-form .form-submitter")).Click();

            //Check validatiom message
            string message = driver.FindElement(By.Id("company-city")).GetProperty("validationMessage");
            Assert.AreEqual("Please fill out this field.", message);
        }

        [TestMethod]
        public void WriteUntilCompanyStateInTextboxesIdentifiedByIdAndPressSubmitButton()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.intend.ro/inregistrare");
            driver.Manage().Window.Maximize();

            //checkbox
            var pj = driver.FindElement(By.XPath("//li[2]/label"));
            if (pj != null)
                pj.Click();

            //prenume
            var textBoxFirstName = driver.FindElement(By.Id("name"));
            textBoxFirstName.Clear();
            textBoxFirstName.SendKeys("Prenume Test2");

            //nume
            var textBoxLastName = driver.FindElement(By.Id("lastname"));
            textBoxLastName.Clear();
            textBoxLastName.SendKeys("Nume Test2");

            //telefon
            var textBoxPhone = driver.FindElement(By.Id("phone"));
            textBoxPhone.Clear();
            textBoxPhone.SendKeys("0740000069");

            //email
            var textBoxEmail = driver.FindElement(By.Id("email"));
            textBoxEmail.Clear();
            textBoxEmail.SendKeys("email69@gmail.com");

            //parola
            var textBoxPassword = driver.FindElement(By.Id("password"));
            textBoxPassword.Clear();
            textBoxPassword.SendKeys("Password3");

            //confirma parola
            var textBoxCPassword = driver.FindElement(By.Id("cpassword"));
            textBoxCPassword.Clear();
            textBoxCPassword.SendKeys("Password3");

            //adresa
            var textBoxAddress = driver.FindElement(By.Id("address"));
            textBoxAddress.Clear();
            textBoxAddress.SendKeys("Adresa Test2");

            //localitate
            var textBoxCity = driver.FindElement(By.Id("city"));
            textBoxCity.Clear();
            textBoxCity.SendKeys("Localitate Test2");

            //Judet/Sector
            var textBoxState = driver.FindElement(By.Id("state"));
            textBoxState.Clear();
            textBoxState.SendKeys("Judet Test2");

            //nume firma
            var textBoxCompanyName = driver.FindElement(By.Id("company-name"));
            textBoxCompanyName.Clear();
            textBoxCompanyName.SendKeys("Companie Test");

            //cod unic (CUI)
            var textBoxCompanyCui = driver.FindElement(By.Id("company-cui"));
            textBoxCompanyCui.Clear();
            textBoxCompanyCui.SendKeys("100");

            //nr inregistrare (Reg. Com.)
            var textBoxCompanyReg = driver.FindElement(By.Id("company-reg"));
            textBoxCompanyReg.Clear();
            textBoxCompanyReg.SendKeys("100");

            //banca
            var textBoxCompanyBank = driver.FindElement(By.Id("company-bank"));
            textBoxCompanyBank.Clear();
            textBoxCompanyBank.SendKeys("Banca Test");

            //cont banca IBAN
            var textBoxCompanyIban = driver.FindElement(By.Id("company-iban"));
            textBoxCompanyIban.Clear();
            textBoxCompanyIban.SendKeys("100");

            //adresa
            var textBoxCompanyAddress = driver.FindElement(By.Id("company-address"));
            textBoxCompanyAddress.Clear();
            textBoxCompanyAddress.SendKeys("Adresa Test2");

            //localitate
            var textBoxCompanyCity = driver.FindElement(By.Id("company-city"));
            textBoxCompanyCity.Clear();
            textBoxCompanyCity.SendKeys("Localitate Test2");

            //submit
            driver.FindElement(By.CssSelector(".register-form .form-submitter")).Click();

            //Check validatiom message
            string message = driver.FindElement(By.Id("company-state")).GetProperty("validationMessage");
            Assert.AreEqual("Please fill out this field.", message);
        }
    }
}
