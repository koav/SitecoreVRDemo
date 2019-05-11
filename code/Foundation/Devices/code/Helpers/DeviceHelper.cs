using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Layouts;

namespace SC91.Foundation.Devices.Helpers
{
    public static class DeviceHelper
    {
        private const string VR_DEVICE = "{75DC9210-B082-4D73-928B-F6F7649E1BFD}";

        public static bool IsVrDevice()
        {
            var currentItem = Sitecore.Context.Item;
            var layoutField = new LayoutField(currentItem);

            LayoutDefinition layoutDef = LayoutDefinition.Parse(layoutField.Value);
            DeviceDefinition deviceDef = layoutDef.GetDevice(Sitecore.Context.Device.ID.ToString());

            return deviceDef.ID == VR_DEVICE;
        }

        public static string GetVrLink(Item item)
        {
            if(item == null)
                throw new ArgumentNullException(nameof(item));

            DeviceItem deviceItem = Context.Database.Resources.Devices.GetAll().First(d => d.ID == ID.Parse(VR_DEVICE));
            if (deviceItem != null)
            {
                return Sitecore.Links.LinkManager.GetItemUrl(item) + "?" + deviceItem.QueryString;
            }

            return null;
        }
    }
}