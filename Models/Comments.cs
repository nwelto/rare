﻿namespace rare.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; }
    }
}
