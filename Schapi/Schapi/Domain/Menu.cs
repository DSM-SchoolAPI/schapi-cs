using System;
using System.Collections.Generic;
using System.Text;

namespace Schapi.Domain
{
    public class Menu
    {
        private List<string> breakfast;
        private List<string> lunch;
        private List<string> dinner;

        public List<string> Breakfast { get => breakfast; set => breakfast = value; }
        public List<string> Lunch { get => lunch; set => lunch = value; }
        public List<string> Dinner { get => dinner; set => dinner = value; }

        public Menu(List<string> breakfast, List<string> lunch, List<string> dinner)
        {
            this.breakfast = breakfast;
            this.lunch = lunch;
            this.dinner = dinner;
        }
    }
}