using Project_DDD.DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DDD.ApplicationLayer.Models.DTOs
{
    public class CategoryDTO
    {   
    public int Id { get; set; }
    public string CategoyName { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; } = "/images/MainCategory/default.jpg";

    public DateTime? UpdateDate { get; set; }
    public DateTime? DeleteDate { get; set; }
    public Status Status { get; set; }

    }
}

