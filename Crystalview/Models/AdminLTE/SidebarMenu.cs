namespace Global.Models
{
    public class SidebarMenu
    {
        public int ID { get; set; }
        public SidebarMenuType Type { get; set; }
        public bool IsActive { get; set; } = false;
        public String? Name { get; set; }
        public String? IconClassName { get; set; }
        public String? URLPath { get; set; }
        public List<SidebarMenu>? TreeChild { get; set; }
        public Tuple<int, int, int> LinkCounter { get; set; }
    }

    public enum SidebarMenuType
    {
        Header,
        Link,
        Tree
    }
}
