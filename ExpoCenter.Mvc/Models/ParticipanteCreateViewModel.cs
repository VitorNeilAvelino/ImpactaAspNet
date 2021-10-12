using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExpoCenter.Mvc.Models
{
    public class ParticipanteCreateViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "CPF")]
        [StringLength(11, MinimumLength = 11)]
        public string Cpf { get; set; }

        [Display(Name = "Nascimento")]
        //[DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        //[DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public List<EventoGridViewModel> Eventos { get; set; }
    }
}