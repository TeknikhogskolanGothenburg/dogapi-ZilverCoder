using System.Collections.Generic;

namespace test2.Models
{
    public class Dog
    {
        public string BreedName {get; set;}
        public string WikipediaUrl {get; set;}
        public string Description{get; set;}
        public List<string> Dogs = new List<string>();
    }
}