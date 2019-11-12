using System.ComponentModel.DataAnnotations;
using EvoxSolutions.WebApi.VO;

namespace EvoxSolutions.WebApi.Models
{
    public class Category : Entity
    {
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Title { get; set; }
    }
}