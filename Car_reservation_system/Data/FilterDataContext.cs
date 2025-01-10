


﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Car_reservation_system.Models;


namespace Car_reservation_system.Data
{
    public class FilterDataContext : DbContext
    {
        public FilterDataContext(DbContextOptions<FilterDataContext> options)
            : base(options)
        {
        }

        public DbSet<Car_reservation_system.Models.FilterData> FilterData { get; set; } = default!;
    }
}