﻿using Kudu.Services.Web.Tracing;
using Xunit;

namespace Kudu.Core.Test
{
    public class TraceModuleFacts
    {
        [Theory]
        [InlineData("/api/siteextensions", true)]
        [InlineData("/api/siteextensions/", true)]
        [InlineData("/api/siteextensions/foo", true)]
        [InlineData("/api/siteextensions/foo/", true)]
        [InlineData("/api/siteextensions/foo/bar", true)]
        [InlineData("/api/siteextensions/foo/bar/", true)]
        [InlineData("/api/siteextensionss", false)]
        [InlineData("/api/siteextensionss/foo", false)]
        [InlineData("/siteextensions", false)]
        [InlineData("/siteextensionss", false)]
        [InlineData("/api/deployments", true)]
        [InlineData("/api/deployments/", true)]
        [InlineData("/api/deployments/3bad999c", true)]
        [InlineData("/api/deployments/3bad999c/", true)]
        [InlineData("/api/deployments/3bad999c/log", true)]
        [InlineData("/api/deployments/3bad999c/log/", true)]
        [InlineData("/api/deployments/3bad999c/log/aaca03ed", false)]
        [InlineData("/api/deployments/3bad999c/log/aaca03ed/", false)]
        [InlineData("/api/deploymentss", false)]
        [InlineData("/api/deploymentss/log", false)]
        [InlineData("/deployments", false)]
        [InlineData("/deploymentss", false)]
        [InlineData("/api/settings", false)]
        [InlineData("/api/processes", true)]
        [InlineData("/api/processes/", true)]
        [InlineData("/api/processes/1", true)]
        [InlineData("/api/processes/1/", true)]
        [InlineData("/api/processes/1/dump", false)]
        [InlineData("/api/processes", true)]
        [InlineData("/api/processes/", true)]
        [InlineData("/api/processes/1", true)]
        [InlineData("/api/processes/1/", true)]
        [InlineData("/api/processes/1/dump", false)]
        [InlineData("/api/webjobs", true)]
        [InlineData("/api/webjobs/", true)]
        [InlineData("/api/webjobs/1", true)]
        [InlineData("/api/webjobs/1/", true)]
        [InlineData("/api/webjobs/1/dump", false)]
        [InlineData("/api/triggeredwebjobs", true)]
        [InlineData("/api/triggeredwebjobs/", true)]
        [InlineData("/api/triggeredwebjobs/1", true)]
        [InlineData("/api/triggeredwebjobs/1/", true)]
        [InlineData("/api/triggeredwebjobs/1/dump", false)]
        [InlineData("/api/continuouswebjobs", true)]
        [InlineData("/api/continuouswebjobs/", true)]
        [InlineData("/api/continuouswebjobs/1", true)]
        [InlineData("/api/continuouswebjobs/1/", true)]
        [InlineData("/api/continuouswebjobs/1/dump", false)]
        public void IsRbacWhiteListPathsTests(string path, bool expected)
        {
            // Test
            var actual = TraceModule.IsRbacWhiteListPaths(path);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
