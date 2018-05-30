using System.Collections.Generic;
using Schapi.Domain;
using Schapi.Parser;

namespace Schapi
{
    public class Region
    {
        public const string 
            SEOUL = "stu.sen.go.kr",
            BUSAN = "stu.pen.go.kr",
            DAEGU = "stu.dge.go.kr",
            INCHEON = "stu.ice.go.kr",
            GWANGJU = "stu.gen.go.kr",
            DAEJEON = "stu.dje.go.kr",
            ULSAN = "stu.use.go.kr",
            SEJONG = "stu.sje.go.kr",
            GYEONGGI = "stu.cbe.go.kr",
            KANGWON = "stu.kwe.go.kr",
            CHUNGBUK = "stu.cbe.go.kr",
            CHUNGNAM = "stu.cne.go.kr",
            JEONBUK = "stu.jbe.go.kr",
            JEONNAM = "stu.jne.go.kr",
            GYEONGBUK = "stu.gbe.go.kr",
            GYEONGNAM = "stu.gne.go.kr",
            JEJU = "stu.jje.go.kr";
    }

    public enum Kind
    {
        KINDERGARTEN = 1,
        ELEMENTARY = 2,
        MIDDLE = 3,
        HIGH = 4,
    }

    public class SchoolAPI
    {
        public Kind kind;
        public string region;
        public string code;

        public SchoolAPI(Kind kind, string region, string code)
        {
            this.kind = kind;
            this.region = region;
            this.code = code;
        }

        private string GetMonthlyMealsURL(int year, int month)
        {
            return $"http://{region}/sts_sci_md00_001.do?" +
                   $"schulCode={code}&" +
                   $"schulCrseScCode={(int)kind}&" +
                   $"schulKndScScore=0{(int)kind}&" +
                   $"schYm={year}{month:00}";
        }

        public Dictionary<int, Menu> GetMonthlyMenus(int year, int month)
        {
            var document = ResponseParser.GetDocumentFromURL(GetMonthlyMealsURL(year, month));
            return MealParser.GetMenusFromDocument(document);
        }
    }
}