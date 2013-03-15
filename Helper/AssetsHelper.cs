using System.Collections.Generic;
using System.Text;

namespace System.Web.Mvc
{
    public static class HtmlHelperExtensions
    {
        public static AssetsHelper Assets(this HtmlHelper htmlHelper)
        {
            return AssetsHelper.GetInstance(htmlHelper);
        }
    }

    public class AssetsHelper
    {
        public static AssetsHelper GetInstance(HtmlHelper htmlHelper)
        {
            var instanceKey = "48F2764A-6898-450E-99F8-1EF0B912ED03";

            var context = htmlHelper.ViewContext.HttpContext;
            if (context == null) return null;

            var assetsHelper = (AssetsHelper)context.Items[instanceKey];

            if (assetsHelper == null)
                context.Items.Add(instanceKey, assetsHelper = new AssetsHelper());

            return assetsHelper;
        }

        public ItemRegistrar Styles { get; private set; }
        public ItemRegistrar Scripts { get; private set; }
		public ItemRegistrar InlineScripts { get; private set; }

        public AssetsHelper()
        {
            Styles = new ItemRegistrar(ItemRegistrarFormatters.StyleFormat);
            Scripts = new ItemRegistrar(ItemRegistrarFormatters.ScriptFormat);
			InlineScripts = new ItemRegistrar(ItemRegistrarFormatters.InlineScripts);
        }
    }

    public class ItemRegistrar
    {
        private readonly string _format;
        private readonly IList<string> _items;

        public ItemRegistrar(string format)
        {
            _format = format;
            _items = new List<string>();
        }

        public ItemRegistrar Add(string url)
        {
            if (!_items.Contains(url))
                _items.Add(url);

            return this;
        }

        public IHtmlString Render()
        {
            var sb = new StringBuilder();

            foreach (var item in _items)
            {
                var fmt = string.Format(_format, item);
                sb.AppendLine(fmt);
            }

            return new HtmlString(sb.ToString());
        }
    }

    public class ItemRegistrarFormatters
    {
        public const string StyleFormat = "<link href=\"{0}\" rel=\"stylesheet\" type=\"text/css\" />";
        public const string ScriptFormat = "<script src=\"{0}\" type=\"text/javascript\"></script>";
		public const string InlineScripts = "<script type=\"text/javascript\">{0}</script>";
    }
}
