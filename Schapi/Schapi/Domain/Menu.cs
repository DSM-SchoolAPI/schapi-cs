using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schapi.Domain
{
    public class Menu
    {
        public List<string> Breakfast { get; set; }
        public List<string> Lunch { get; set; }
        public List<string> Dinner { get; set; }

        public string BreakfastString => string.Join(", ", Breakfast.Select(x => x ?? string.Empty));
        public string LunchString => string.Join(", ", Lunch.Select(x => x ?? string.Empty));
        public string DinnerString => string.Join(", ", Dinner.Select(x => x ?? string.Empty));

        internal Menu(List<string> breakfast, List<string> lunch, List<string> dinner)
        {
            Breakfast = breakfast;
            Lunch = lunch;
            Dinner = dinner;
        }
    }
}