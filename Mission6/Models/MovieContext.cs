﻿using Microsoft.EntityFrameworkCore;

namespace Mission6.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }

        public DbSet<MovieFormModel> Movies { get; set; }
    }
}
