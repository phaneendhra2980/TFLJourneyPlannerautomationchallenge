using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow.Infrastructure;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace JourneyPlanner.Specs.Drivers
{
    /// <summary>
    /// Manages a browser instance using Selenium
    /// </summary>
    public class BrowserDriver : IDisposable
    {
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private bool _isDisposed;
        private ChromeDriver _driver;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public BrowserDriver(ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _specFlowOutputHelper = specFlowOutputHelper;
            _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver);
        }

        /// <summary>
        /// The Selenium IWebDriver instance
        /// </summary>
        public IWebDriver Current => _currentWebDriverLazy.Value;

        /// <summary>
        /// Creates the Selenium web driver (opens a browser)
        /// </summary>
        /// <returns></returns>
        private IWebDriver CreateWebDriver()
        {
            //We use the Chrome browser
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
            //ChromeDriverService service = ChromeDriverService.CreateDefaultService(Path.Combine(GetBasePath, @"Binaries\"));
            //  ChromeDriverService service = ChromeDriverService.CreateDefaultService(GetBasePath);
            ChromeOptions options = new ChromeOptions();
            //options.AddArguments("--incognito");
            
            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Manage().Window.Maximize();
            _specFlowOutputHelper.WriteLine("Browser launched");
            return _driver;
        }

        public static string GetBasePath
        {
            get
            {
                var basePath =
                    System.IO.Path.GetDirectoryName((System.Reflection.Assembly.GetExecutingAssembly().Location));
                basePath = basePath.Substring(0, basePath.Length - 23);
                return basePath;
            }
        }

        /// <summary>
        /// Disposes the Selenium web driver (closing the browser)
        /// </summary>
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            if (_currentWebDriverLazy.IsValueCreated)
            {
                Current.Quit();
                _specFlowOutputHelper.WriteLine("Browser closed");
            }

            _isDisposed = true;
        }
    }
}