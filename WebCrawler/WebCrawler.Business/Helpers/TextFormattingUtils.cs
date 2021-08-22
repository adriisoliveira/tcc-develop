using System;
using System.Collections.Generic;
using System.Text;

namespace WebCrawler.Business.Helpers
{
    public static class TextFormattingUtils
    {
        public static string UrlConformer(string unformattedUrl)
        {
            var uri = new Uri(unformattedUrl);
            return (uri.Scheme + "://" + uri.Host + uri.PathAndQuery + uri.Fragment).Trim('/');
        }

    }
}
