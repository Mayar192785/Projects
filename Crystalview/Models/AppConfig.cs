namespace Global.Models
{
    public class AppConfig
    {
    }
    /// <summary>
    /// get the configuration file structure 
    /// 
    /// {
    //  "AppName": "This is at the root",
    //  "Favourites": {
    //    "TvShow": "Star Trek: The Next Generation",
    //    "Movie": "First Contact",
    //    "Food": "Haggis",
    //    "Drink":  "Cream Soda"  
    //  },
    //  "Fruits": [
    //    "Apples",
    //    "Oranges",
    //    "Pears",
    //    "Cherries",
    //    "Bananas",
    //    "Strawberries",
    //    "Raspberries"
    //  ]           
    //}
    /// </summary>
    public class MyConfiguration
    {
        public String? UserName { get; set; } // From the environment variable of the same name
        public String? InMemory { get; set; } // From the in-memory collection
        public String? AppName { get; set; } // from appSettings.json

        public string[] Fruits { get; set; } // from appSettings.json
    }
}
