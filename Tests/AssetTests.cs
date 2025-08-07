using System;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using SnipeITAutomation.Utils;
using SnipeITAutomation.Pages;

namespace SnipeITAutomation.Tests
{
    public class AssetTests : TestBase
    {
        [Fact]
        public async Task CreateAndValidateAsset()
        {
            var login = new LoginPage(_page);
            var asset = new AssetPage(_page);
            string assetName = $"MacBook-{Guid.NewGuid().ToString().Substring(0, 5)}";

            await login.NavigateAsync();
            await login.LoginAsync("admin", "password");

            await asset.GoToAssetCreateAsync();
            await asset.CreateAssetAsync(assetName);

            await asset.SearchAssetAsync(assetName);
            await asset.ClickAssetFromListAsync();

            (await asset.ValidateAssetDetailsAsync(assetName))
                .Should().BeTrue("Asset details page should match the created asset.");

            (await asset.ValidateHistoryTabAsync(assetName))
                .Should().BeTrue("History tab should contain asset creation entry.");
        }
    }
}
