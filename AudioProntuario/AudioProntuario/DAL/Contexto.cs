﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AudioProntuario.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AudioProntuario.DAL
{
    public class Contexto : DbContext
    {
        public Contexto() : base("AudioConnectionString") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Audio> AudioDB { get; set; }
    }
}