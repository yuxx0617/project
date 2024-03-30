namespace TEST.Models.Class
{

    public class Class
    {
        public int ClassID { get; set; }
        public string Account { get; set; }
        public int Type { get; set; }
        public int Price { get; set; }
        public string Content{get;set;}
        public string Video{get;set;}
        public int Year{get;set;}
        public DateTime CreateTime{get;set;}
        public DateTime? EditTime{get;set;}
        public bool IsDelete {get;set;}
    }
}