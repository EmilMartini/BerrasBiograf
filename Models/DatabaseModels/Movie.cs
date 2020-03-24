using System;
using System.ComponentModel.DataAnnotations;

namespace BerrasBiograf
{
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double Length { get; set; }
        public Genre Genre { get; set; }
        public int AgeRestriction { get; set; }
        public string ImageLink { get; set; }
    }
}
