using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UIAutomationTests
{
    public class Selenium
    {
        private IWebDriver _driver = null!;
        private WebDriverWait _wait = null!;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void CreateCountryTest()
        {
            string baseUrl = "http://localhost:8080";
            string countryName = $"Pais Selenium {DateTime.Now:HHmmss}";
            string continent = "América";
            string language = "Espanol";

            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(baseUrl);

            IWebElement listTitle = _wait.Until(driver =>
                driver.FindElement(By.XPath("//*[contains(text(),'Lista de países')]")));

            Assert.That(listTitle.Displayed, Is.True);

            IWebElement addCountryButton = _wait.Until(driver =>
                driver.FindElement(By.XPath("//*[contains(text(),'Agregar país') or contains(text(),'Agregar pais')]")));

            Assert.That(addCountryButton.Displayed, Is.True);

            addCountryButton.Click();

            IWebElement formTitle = _wait.Until(driver =>
                driver.FindElement(By.XPath("//*[contains(text(),'Formulario de creación de países')]")));

            Assert.That(formTitle.Displayed, Is.True);

            IWebElement nameInput = _wait.Until(driver =>
                driver.FindElement(By.Id("name")));

            IWebElement continentSelect = _wait.Until(driver =>
                driver.FindElement(By.Id("continent")));

            IWebElement languageInput = _wait.Until(driver =>
                driver.FindElement(By.Id("language")));

            nameInput.SendKeys(countryName);

            SelectElement selectContinent = new SelectElement(continentSelect);
            selectContinent.SelectByText(continent);

            languageInput.SendKeys(language);

            Assert.That(nameInput.GetAttribute("value"), Is.EqualTo(countryName));
            Assert.That(selectContinent.SelectedOption.Text, Is.EqualTo(continent));
            Assert.That(languageInput.GetAttribute("value"), Is.EqualTo(language));

            IWebElement saveButton = _wait.Until(driver =>
                driver.FindElement(By.XPath("//button[contains(text(),'Guardar')]")));

            saveButton.Click();

            IWebElement successMessage = _wait.Until(driver =>
                driver.FindElement(By.Id("successMessage")));

            Assert.That(successMessage.Text, Is.EqualTo("País guardado exitosamente."));

            _wait.Until(driver => driver.Url == $"{baseUrl}/");

            IWebElement countriesTable = _wait.Until(driver =>
            {
                IWebElement table = driver.FindElement(By.CssSelector("table"));
                return table.Text.Contains(countryName) ? table : null;
            });

            Assert.That(countriesTable.Text, Does.Contain(countryName));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}