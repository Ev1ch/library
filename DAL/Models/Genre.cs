﻿namespace DAL.Models
{
    public class Genre : Model<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
