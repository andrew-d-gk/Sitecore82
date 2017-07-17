namespace Sitecore82.Controllers.Controllers
{
    using System.Web.Mvc;
    using Glass.Mapper.Sc.Web.Mvc;
    using Sitecore82.Models.Models;

    /// <summary>
    /// Test controller
    /// </summary>
    /// <seealso cref="Glass.Mapper.Sc.Web.Mvc.GlassController" />
    public class TestController : GlassController
    {
        // GET: Test
        /// <summary>
        /// Mies the rendering.
        /// </summary>
        /// <returns></returns>
        public ActionResult MyRendering()
        {
            var model = this.GetDataSourceItem<IMyRenderingData>();
            return this.View(model);
        }
    }
}