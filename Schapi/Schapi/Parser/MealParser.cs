using AngleSharp.Dom.Html;
using AngleSharp.Extensions;
using Schapi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Schapi.Parser
{
    internal static class MealParser
    {
        static readonly List<string> TIMINGS = new List<string> { "조식", "중식", "석식" };

        public static Dictionary<int, List<string>> GetMenuDictFromData(string data)
        {
            var menu = new Dictionary<int, List<string>>();
            var timing = 0;
            //var matches = Regex.Matches(data, @"[가-힣]+\([가-힣]+\)|[가-힣]+").Cast<Match>();
            var matches = Regex.Matches(data, @"\[?(\/?[가-힣]+(?:\([가-힣]*\))*)(?:\*|[0-9]|\.)*\]?").Cast<Match>();

            foreach (var match in matches)
            {
                var text = match.Groups[1].Value;

                if (Regex.IsMatch(text, "[조중석]식"))
                {
                    timing = TIMINGS.FindIndex(t => t == text);
                    menu[timing] = new List<string>();
                }

                else
                {
                    var list = menu[timing];
                    if (text.StartsWith("/"))
                        list[list.Count - 1] += text;
                    else
                        list.Add(text);
                }
            }

            return menu;
        }

        public static Menu GetMenuFromDict(Dictionary<int, List<string>> dict)
        {
            dict.TryGetValue(0, out var breakfast);
            dict.TryGetValue(1, out var lunch);
            dict.TryGetValue(2, out var dinner);

            return new Menu(breakfast, lunch, dinner);
        }

        public static Dictionary<int, Menu> GetMenusFromDocument(IHtmlDocument document)
        {
            var menus = new Dictionary<int, Menu>();

            var menuCells = document.QuerySelectorAll("table.tbl_type3.tbl_calendar td");
            var menuCounts = 0;

            foreach (var cell in menuCells.Where(c => c.Text() != " "))
            {
                var menu = GetMenuFromDict(GetMenuDictFromData(cell.Text()));
                menus[++menuCounts] = menu;
            }

            return menus;
        }
    }
}