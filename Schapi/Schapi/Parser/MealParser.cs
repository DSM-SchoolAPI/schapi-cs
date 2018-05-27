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
    public static class MealParser
    {
        static readonly List<string> TIMINGS = new List<string> { "조식", "중식", "석식" };

        public static Dictionary<int, List<string>> GetMenuDictFromData(string data)
        {
            var menu = new Dictionary<int, List<string>>();
            var timing = 0;

            foreach (string text in Regex.Matches(data, @"[가-힣]+\([가-힣]+\)|[가-힣]+"))
            {
                if (Regex.IsMatch(text, "[조중석]식"))
                {
                    timing = TIMINGS.FindIndex(t => t == text);
                    menu[timing] = new List<string>();
                }

                else
                {
                    menu[timing].Add(text);
                }
            }

            return menu;
        }

        public static Menu GetMenuFromDict(Dictionary<int, List<string>> dict)
        {
            dict.TryGetValue(0, out var breakfast);
            dict.TryGetValue(1, out var lunch);
            dict.TryGetValue(2, out var dinner);

            var menu = new Menu(breakfast, lunch, dinner);
            return menu;
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
