using JourneyPlanner.Specs.Drivers;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace JourneyPlanner.Hooks
{
    [Binding]
    public sealed class LoggingHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;
        private readonly TestContext _testContext;
        private readonly BrowserDriver _browserDriver;
        public LoggingHooks(BrowserDriver browserDriver, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _browserDriver = browserDriver;
            _testContext = new TestContext(TestExecutionContext.CurrentContext);
            _specFlowOutputHelper = specFlowOutputHelper;

        }
        

        [AfterStep]
        public void TakeScreenshotAfterEachStep()
        {
            //TODO: implement logic that has to run after executing each scenario

            if (_browserDriver.Current is ITakesScreenshot screenshotTaker)
            {
                var filename = Path.ChangeExtension(Path.GetRandomFileName(), "png");
                screenshotTaker.GetScreenshot().SaveAsFile(filename);
                var basePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
               
                basePath = basePath.Substring(0, basePath.Length - 38);
                string filePath= Path.Combine(basePath, @"TestResults\")+filename;
                _specFlowOutputHelper.AddAttachment(filePath);
                


            }
        }
    }
}
