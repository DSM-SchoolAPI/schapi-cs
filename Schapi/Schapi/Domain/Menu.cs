using System;
using System.Collections.Generic;
using System.Text;

namespace Schapi.Domain
{
    public class Menu
    {
        public List<string> Breakfast { get; set; }
        public List<string> Lunch { get; set; }
        public List<string> Dinner { get; set; }

        public string BreakfastString => string.Join(", ", Breakfast);
        public string LunchString => string.Join(", ", Lunch);
        public string DinnerString => string.Join(", ", Dinner);

        internal Menu(List<string> breakfast, List<string> lunch, List<string> dinner)
        {
            Breakfast = breakfast;
            Lunch = lunch;
            Dinner = dinner;
        }
    }
}