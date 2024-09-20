using System.Collections.Generic;

namespace WEB_253502_BARANOVSKY.Models
{
    public class ListDemo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class ModeListViewModel
    {
        public List<ListDemo> Items { get; set; } = new List<ListDemo>();
        public int SelectedItemId { get; set; }
    }
}