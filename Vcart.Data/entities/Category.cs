﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vcart.Data.entities;

[Table("Category")]
public partial class Category
{
    [Key]
    [Column("CategoryID")]
    public int CategoryId { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string Name { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string Description { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}