﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Aural_Novel.Models;

public partial class AuralNovelEntities1 : DbContext
{
    public AuralNovelEntities1()
        : base("name=AuralNovelEntities1")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }

    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<Reader> Readers { get; set; }
    public virtual DbSet<Seller> Sellers { get; set; }
}
