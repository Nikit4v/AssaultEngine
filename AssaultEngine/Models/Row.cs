using System.Collections.Generic;
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace AssaultEngine.Models
{
    public class Chunk
    {
        public int ChunkId { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public string Content { get; set; }
    }
    public class Row
    {
        public int RowId { get; set; }
        public string Actor { get; set; }
        public List<Chunk> Chunks { get; set; }
        public List<Style> Styles { get; set; }
    }
}