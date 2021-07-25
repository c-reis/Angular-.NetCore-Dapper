using System.ComponentModel.DataAnnotations;


namespace projEntrevista.Models
{
    public class PessoaModels
    {
        [Key]
        public int Idpessoa { get; set; }
        [Required, MaxLength(60)]
        public string Nomecompleto { get; set; }
        [Required]
        public int Idade { get; set; }
        [Required, MaxLength(11)]
        public string Cpf { get; set; }
        [Required, MaxLength(60)]
        public string Rua_endereco { get; set; }
        [Required]
        public int Num_endereco { get; set; }
        [Required, MaxLength(50)]
        public string Bairro_endereco { get; set; }
        [Required, MaxLength(50)]
        public string Cidade { get; set; }

    }
}
