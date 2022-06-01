﻿using System.ComponentModel.DataAnnotations;

namespace WissenShop.Web.Core.ViewModels.Dashboard
{
    public class CategoryReportViewModel
    {
        [Display(Name = "Kategori Adı")]
        public string Name { get; set; }
        [Display(Name = "Adet")]
        public int ProductCount { get; set; }
    }
}