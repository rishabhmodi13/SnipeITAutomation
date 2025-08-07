using Microsoft.Playwright;
using System.Threading.Tasks;

namespace SnipeITAutomation.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;
        public LoginPage(IPage page) => _page = page;

        public async Task NavigateAsync() => await _page.GotoAsync("https://demo.snipeitapp.com/login");

        public async Task LoginAsync(string email, string password)
        {
            await _page.FillAsync("#email", email);
            await _page.FillAsync("#password", password);
            await _page.ClickAsync("button[type='submit']");
            await _page.WaitForURLAsync("**/dashboard");
        }
    }
}
