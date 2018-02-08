using System;
using System.Collections.Generic;
using System.Text;

namespace Synkwise.Core.Models.Document
{
    public class TreeView
    {
        public int Id { get; set; }

        public int StateId { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }

        public int? Rank { get; set; }

        public int CategoryId { get; set; }
    }
}
