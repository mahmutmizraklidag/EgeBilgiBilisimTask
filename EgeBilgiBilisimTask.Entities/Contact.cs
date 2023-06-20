﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EgeBilgiBilisimTask.Entities
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Adı"), Required(ErrorMessage = "{0} alanı boş geçilemez!")]
        public string Name { get; set; }
        [Display(Name = "Soyadı"), Required(ErrorMessage = "{0} alanı boş geçilemez!")]
        public string Surname { get; set; }
        [Display(Name = "Email"), Required(ErrorMessage = "{0} alanı boş geçilemez!"), EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }
        [Display(Name = "Mesaj"), Required(ErrorMessage = "{0} alanı boş geçilemez!")]
        public string? Message { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
