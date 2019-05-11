using System;
using System.Linq;
using System.Web.Mvc;
using SC91.Feature.Product.Models;
using SC91.Foundation.Devices.Helpers;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Layouts;
using Sitecore.Mvc.Presentation;

namespace SC91.Feature.Product.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            var dataSourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;
            var dataSource = Sitecore.Context.Database.GetItem(dataSourceId);

            if (dataSource == null)
                throw new NullReferenceException("Data source is empty");

            var viewModel = new ProductViewModel()
            {
                Product = new Entities.Product(dataSource)
            };

            if (DeviceHelper.IsVrDevice())
            {
                return this.View("IndexVR", viewModel);
            }
            else
            {
                return this.View("Index", viewModel);
            }
        }
    }
}