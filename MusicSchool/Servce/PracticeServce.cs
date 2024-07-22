using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSchool.Servce
{
    internal static class PracticeServce
    {
        // 1
        public static Func<List<string>, bool> Func1 = (list) => list.Any
        (str => str.StartsWith("a"));

        //2
        public static Func<List<string>, bool> Func2 = (list) =>
        list.Any(str => string.IsNullOrEmpty(str));

        //3
        public static Func<List<string>, bool> Func3 = (list) => 
        list.All(str => str.StartsWith("a"));

        //4
        public static Func<List<string>, List<string>> Func4 = (list) =>
        list.Select(str => str.ToUpper()).ToList();
        //5
        public static Func<List<string>, List<string>> Func5 = (list) =>
            (from i in list select i.ToUpper()).ToList();

        //6
        public static Func<List<string>, List<string>> Func6 = (list) =>
        list.Where(str => str.Length > 3).ToList();

        //7
        public static Func<List<string>, List<string>> Func7 = (list) =>
            (from i in list where i.Length>3 select i).ToList();

        // 8 
        public static Func<List<string>,string> Func8 = (list) => 
            string.Join(",",list);

        //9
        public static Func<List<string>, int> Func9 = (list) =>
           string.Join("", list).Length;


    }
}
