namespace HigherLogics.Web.Windmill.Test.Models
{
    public class GlobalViewModel
    {
        public GlobalViewModel(string page)
        {
            Page = page;
        }
        public string Page { get; set; }
    }
}
