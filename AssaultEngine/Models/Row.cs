using System.Collections.Generic;

namespace AssaultEngine.Models
{
    public class Tag
    {
        public int Start { get; set; }
        public int End { get; set; }
        public string Content { get; set; }
    }
    public class Row
    {
        public int RowId { get; set; }
        public string Text { get; set; }
        public List<Tag> Tags;
        public Style Style { get; set; }
    }
}