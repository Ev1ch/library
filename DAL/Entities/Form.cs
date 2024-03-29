﻿using DAL.Entities.Relations;

namespace DAL.Entities
{
    public class Form : Entity<int>
    {
        public int ClientId { get; set; }

        public Client Client { get; set; }

        public ICollection<Book> Books { get; set; }

        public ICollection<FormBook> FormBooks { get; set; }
    }
}
