using System;
using System.ComponentModel.DataAnnotations;

namespace ExpoCenter.Mvc.Models
{
    public class EventoGridViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        
        public DateTime Data { get; set; }

        public string Local { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        public bool Selecionado { get; set; }
    }
}