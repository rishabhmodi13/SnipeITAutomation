using Microsoft.Playwright;
using System.Threading.Tasks;

namespace SnipeITAutomation.Pages
{
    public class AssetPage
    {
        private readonly IPage _page;
        public AssetPage(IPage page) => _page = page;

        public async Task GoToAssetCreateAsync()
        {
            await _page.ClickAsync("a[href='/hardware/create']");
        }

        public async Task CreateAssetAsync(string name)
        {
            await _page.SelectOptionAsync("#status_id", new[] { "2" }); // Ready to Deploy
            await _page.FillAsync("#name", name);
            await _page.FillAsync("#serial", "SN-" + name);
            await _page.FillAsync("#model_number", "MacBook Pro 13");
            await _page.CheckAsync("#requestable");
            await _page.ClickAsync("button[type='submit']");
            await _page.WaitForTimeoutAsync(2000); // Wait for confirmation
        }

        public async Task SearchAssetAsync(string name)
        {
            await _page.GotoAsync("https://demo.snipeitapp.com/hardware");
            await _page.FillAsync("input[aria-controls='DataTables_Table_0']", name);
            await _page.WaitForSelectorAsync("table");
        }

        public async Task ClickAssetFromListAsync() =>
            await _page.ClickAsync("table tbody tr td a");

        public async Task<bool> ValidateAssetDetailsAsync(string name)
        {
            var text = await _page.TextContentAsync("h1");
            return text.Contains(name);
        }

        public async Task<bool> ValidateHistoryTabAsync(string assetName)
        {
            await _page.ClickAsync("a[href='#tab_history']");
            await _page.WaitForSelectorAsync("#tab_history");
            var historyText = await _page.InnerTextAsync("#tab_history");
            return historyText.Contains("created", System.StringComparison.OrdinalIgnoreCase) &&
                   historyText.Contains(assetName);
        }
    }
}
