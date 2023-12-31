﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.event_.tarde.Domains
{
    [Table(nameof(Instituicao))]
    [Index(nameof(CNPJ), IsUnique =true)]
    public class Instituicao
    {
        [Key]
        public Guid IdInstuicao { get; set; } = Guid.NewGuid();

        [Column(TypeName = ("Char(14)"))]
        [Required(ErrorMessage = "CNPJ obrigatório!")]
        [StringLength(14)]
        public string? CNPJ { get; set; }

        [Column(TypeName = "Varchar(200)")]
        [Required(ErrorMessage = "Endereço é obrigatório!")]

        public string? Endereco { get; set; }

        [Column(TypeName = "Varchar(100)")]
        [Required(ErrorMessage = "O nome fantasia é obrigatório!")]

        public string? NomeFantasia { get; set; }
    }
}
