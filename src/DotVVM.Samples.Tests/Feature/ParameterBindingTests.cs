﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Testing.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Riganti.Selenium.Core;

namespace DotVVM.Samples.Tests.Feature
{
    [TestClass]
    public class ParameterBindingTests : AppSeleniumTest
    {

        [TestMethod]
        public void Feature_ParameterBinding_ParameterBinding()
        {
            RunInAllBrowsers(browser =>
            {
                browser.NavigateToUrl(SamplesRouteUrls.FeatureSamples_ParameterBinding_ParameterBinding + "/123?B=abc");
                browser.Wait();

                browser.Single(".root-a").CheckIfInnerTextEquals("123");
                browser.Single(".root-b").CheckIfInnerTextEquals("abc");
                browser.Single(".nested-a").CheckIfInnerTextEquals("123");
                browser.Single(".nested-b").CheckIfInnerTextEquals("abc");
            });
        }

    }
}
