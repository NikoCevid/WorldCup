using System;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace WinFormsApp.Helpers
{
    public static class ImageHelper
    {
        public static Image LoadEmbeddedImage(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream(resourceName);
            return stream != null ? Image.FromStream(stream) : null;
        }

        public static void ListAllEmbeddedResourceNames()
        {
            var names = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            foreach (var name in names)
            {
                System.Diagnostics.Debug.WriteLine(name);
            }
        }
    }
}
