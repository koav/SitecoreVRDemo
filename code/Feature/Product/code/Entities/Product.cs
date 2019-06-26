using System;
using SC91.Foundation.Devices.Helpers;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace SC91.Feature.Product.Entities
{
    public class Product
    {
        public Product(Item item)
        {
            InnerItem = item ?? throw new ArgumentNullException(nameof(item));

            this.Title = InnerItem.Fields["Product title"]?.Value;
            this.Description = InnerItem.Fields["Product description"]?.Value;
            this.Price = Convert.ToDecimal(InnerItem.Fields["Product price"]?.Value);
            this.Image = ((ImageField)InnerItem.Fields["Product image"])?.MediaItem;
            this.VrModel = ((FileField)InnerItem.Fields["VR Model"])?.MediaItem;
        }

        public Item InnerItem { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Item Image { get; set; }
        public Item VrModel { get; set; }
    }

    public static class ProductExt
    {
        public static string GetImageLink(this Product product)
        {
            return product?.Image != null
                ? Sitecore.Resources.Media.MediaManager.GetMediaUrl(product.Image)
                : null;
        }

        public static string GetVrModelLink(this Product product)
        {
            return product?.VrModel != null
                ? Sitecore.Resources.Media.MediaManager.GetMediaUrl(product.VrModel)
                : null;
        }
    }
}