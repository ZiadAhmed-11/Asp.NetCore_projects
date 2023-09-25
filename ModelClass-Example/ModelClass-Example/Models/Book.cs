﻿using Microsoft.AspNetCore.Mvc;

namespace ModelClass_Example.Models
{
    public class Book
    {
        //[FromQuery]
        public int? BookId { get; set; }
        public string? Author { get; set; }

        public override string ToString()
        {
            return $"Book object - Book id : {BookId}, Author : {Author}";
        }
    }
}
