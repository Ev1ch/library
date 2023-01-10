﻿using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Book : Model<int>
    {
        public int Quantity { get; set; }

        public int Available { get; set; }

        [Required]
        public string Name { get; set; }

        public IList<Author> Authors { get; set; }

        public IList<Genre> Genres { get; set; }

        public IList<Form> Forms { get; set; }
    }
}