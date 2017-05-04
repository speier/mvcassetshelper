using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AssetsHelper
{
    public static class HtmlHelperExtensions
    {
        public static AssetsHelper Assets(this IHtmlHelper htmlHelper)
        {
            return AssetsHelper.GetInstance(htmlHelper);
        }
    }

    public class AssetsHelper
    {
        public static AssetsHelper GetInstance(IHtmlHelper htmlHelper)
        {
            var instanceKey = "3A570A97-40C4-411C-999B-1CEBC92D8FEF";

            var context = htmlHelper.ViewContext.HttpContext;
            if (context == null) return null;

            var assetsHelper = (AssetsHelper)context.Items[instanceKey];

            if (assetsHelper == null) {
                assetsHelper = new AssetsHelper();
                context.Items.Add(instanceKey, assetsHelper);
            }

            return assetsHelper;
        }

        public ItemRegistrar Styles { get; private set; }
        public ItemRegistrar Scripts { get; private set; }
    	public ItemRegistrar InlineScripts { get; private set; }
	    public ItemRegistrar InlineStyles { get; private set; }	

        public AssetsHelper()
        {
            Styles = new ItemRegistrar(ItemRegistrarFormatters.StyleFormat);
            Scripts = new ItemRegistrar(ItemRegistrarFormatters.ScriptFormat);
	        InlineScripts = new ItemRegistrar(ItemRegistrarFormatters.InlineScripts);
	        InlineStyles = new ItemRegistrar(ItemRegistrarFormatters.InlineStyles);
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

        public IHtmlContent Render()
        {
            var sb = new StringBuilder();

            foreach (var item in _items)
            {
                var val = string.Format(_format, EnsureAbsoltute(item));
                sb.AppendLine(val);
            }

            return new HtmlString(sb.ToString());
        }

        private string EnsureAbsoltute(string item) {
            return item.StartsWith("~")
                ? item.Substring(1)
                : item;
        }
    }

    public class ItemRegistrarFormatters
    {
        public const string StyleFormat = "<link href=\"{0}\" rel=\"stylesheet\" type=\"text/css\" />";
        public const string ScriptFormat = "<script src=\"{0}\" type=\"text/javascript\"></script>";
	    public const string InlineScripts = "<script type=\"text/javascript\">{0}</script>";
	    public const string InlineStyles = "<style type=\"text/css\">{0}</style>";
    }
}
