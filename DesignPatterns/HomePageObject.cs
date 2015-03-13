using OpenQA.Selenium;

namespace AutomationRhapsody.DesignPatterns
{
    class HomePageObject
    {
        private WebDriverFacade webDriver;
        public HomePageObject(WebDriverFacade webDriver)
        {
            this.webDriver = webDriver;
        }

        private IWebElement SearchButton
        {
            get { return webDriver.FindElement(By.XPath("//div[@class='search-toggle']")); }
        }

        private IWebElement SearchInput
        {
            get { return webDriver.FindElement(By.XPath("//input[@class='search-field']")); }
        }

        private IWebElement SiteTitle
        {
            get { return webDriver.FindElement(By.XPath("//h1[@class='site-title']/a")); }
        }

        public string GetSiteTitle()
        {
            return SiteTitle.Text;
        }

        public void SearchFor(string text)
        {
            SearchButton.Click();
            SearchInput.SendKeys(text);
            SearchInput.Submit();
        }
    }
}
