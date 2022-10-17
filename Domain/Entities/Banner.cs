using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Banner : BaseEntity
    {
        public string Title { get; set; }
        public int FileId { get; set; }
        public string Content { get; set; } = string.Empty;
        public int? Priority { get; set; }
        public bool Active { get; set; } = true;

        public AppFile File { get; set; }
    }
}
