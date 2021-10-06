using System;
using System.ComponentModel.DataAnnotations;

namespace ExpoCenter.Mvc.Models
{
    public class ParticipanteIndexViewModel
    {
        private string cpf;

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        [Display(Name = "CPF")]
        //[DisplayFormat(DataFormatString = @"{0:000\.000\.000-00}")]
        public string Cpf { get => long.Parse(cpf).ToString(@"000\.000\.000-00"); set => cpf = value; }

        [DataType(DataType.Date)]
        [Display(Name = "Nascimento")]
        public DateTime DataNascimento { get; set; }
    }
}