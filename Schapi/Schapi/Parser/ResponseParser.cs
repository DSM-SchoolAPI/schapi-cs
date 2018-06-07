using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Schapi.Parser
{
    internal static class ResponseParser
    {
        public static IHtmlDocument GetDocumentFromURL(string url)
        {
            var client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var content = response.Content.ReadAsStringAsync().Result;

            var parser = new HtmlParser();
            var document = parser.ParseAsync(content).Result;

            return document;
        }
    }
}