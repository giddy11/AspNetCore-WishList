using System.IO;
using System.Text.RegularExpressions;
using Xunit;

namespace WishListTests
{
    public class AddMVCMiddlewareTests
    {
        [Fact(DisplayName = "Add AddControllers Middleware to ConfigureServices @add-AddControllers-middleware-to-configureservices")]
        public void AddAddControllersCallAdded()
        {
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Startup.cs";
            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }

            Assert.True(file.Contains("services.AddControllers();"), "`Startup.cs`'s `ConfigureServices` method did not contain a call to `AddControllers`.");
        }

        [Fact(DisplayName = "Configure MVC Middleware In Configure @configure-userouting-middleware-in-configure")]
        public void UseRoutingAdded()
        {
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Startup.cs";
            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }

            Assert.True(file.Contains("app.UseRouting();"), "`Startup.cs`'s `Configure` method did not contain a call to `UseRouting` on `app`.");
        }

        [Fact(DisplayName = "Configure AddControllers Middleware In Configure @configure-useendpoints-middleware-in-configure")]
        public void UseEndpointsAdded()
        {
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Startup.cs";
            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }

            Assert.True(file.Contains("app.UseRouting();"), "`Startup.cs`'s `Configure` method did not contain a call to `UseRouting` on `app`.");

            var pattern = @"app.UseRouting\s*?[(]\s*?[)]\s*?;\s*?app.UseEndpoints\s*?[(]\s*?endpoints\s*?=>\s*?{\s*?endpoints.MapDefaultControllerRoute\s*?[(]\s*?[)]\s*?;\s*?}\s*?[)]\s*?;";
            var rgx = new Regex(pattern);
            Assert.True(rgx.IsMatch(file), "`Startup.cs`'s `Configure` method did not contain a call to `UseEnpoints` on `app` after `UseRouting` with an argument of `endpoints => { endpoints.MapDefaultControllerRoute(); }`");
        }
    }
}
