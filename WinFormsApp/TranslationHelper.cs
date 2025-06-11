using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp
{
    internal static class TranslationHelper
    {
        public static void ApplyCulture(string cultureCode, Control rootControl, Type resourceType)
        {
            if (string.IsNullOrWhiteSpace(cultureCode))
                throw new ArgumentException("Language code must not be null or empty.", nameof(cultureCode));

            if (cultureCode.ToUpperInvariant() == "EN")
            {
                cultureCode = "";
            }


            //var culture = new CultureInfo(cultureCode);
            var culture = string.IsNullOrEmpty(cultureCode)
                 ? CultureInfo.InvariantCulture
        : new CultureInfo(cultureCode);

            // Apply culture to the current thread
            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;

            // Load resources
            var resources = new ComponentResourceManager(resourceType);

            if (rootControl is Form form)
            {
                var formText = resources.GetString("$this.Text", culture);
                if (!string.IsNullOrEmpty(formText))
                {
                    form.Text = formText;
                }

                // Recursively update all controls
                UpdateControlTexts(rootControl, resources, culture);

                // Handle MenuStrip items separately
                if (form.MainMenuStrip != null)
                {
                    foreach (ToolStripItem item in form.MainMenuStrip.Items)
                    {
                        UpdateMenuItemTexts(item, resources, culture);
                    }
                }
            }
        }
        private static void UpdateControlTexts(Control control, ComponentResourceManager resources, CultureInfo culture)
        {
            if (!string.IsNullOrEmpty(control.Name))
            {
                resources.ApplyResources(control, control.Name, culture);
            }

            foreach (Control child in control.Controls)
            {
                UpdateControlTexts(child, resources, culture);
            }
        }

        private static void UpdateMenuItemTexts(ToolStripItem item, ComponentResourceManager resources, CultureInfo culture)
        {
            if (!string.IsNullOrEmpty(item.Name))
            {
                resources.ApplyResources(item, item.Name, culture);
            }

            if (item is ToolStripMenuItem menuItem)
            {
                foreach (ToolStripItem subItem in menuItem.DropDownItems)
                {
                    UpdateMenuItemTexts(subItem, resources, culture);
                }
            }
        }
    }
}