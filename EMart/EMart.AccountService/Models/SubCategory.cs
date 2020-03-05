﻿using System;
using System.Collections.Generic;

namespace EMart.AccountService.Models
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            Items = new HashSet<Items>();
        }

        public string SubcategoryId { get; set; }
        public string SubcategoryName { get; set; }
        public string CategoryId { get; set; }
        public string BriefDetails { get; set; }
        public string Gst { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Items> Items { get; set; }
    }
}
