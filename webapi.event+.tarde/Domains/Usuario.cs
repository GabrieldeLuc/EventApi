using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.tarde.Domains
{
    [Table(nameof(Usuario))]
    public class Usuario
    {
        
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string? Nome { get; set; }


        [Column(TypeName = "Varchar(100)")]
        [Required(ErrorMessage = "Email é obrigatório!")]
        public string? Email { get; set; }


        [Column(TypeName = "char(60)")]
        [Required(ErrorMessage = "Senha é obrigatória!")]
        [StringLength(60, MinimumLength =6, ErrorMessage = "Senha deve conter de 6 a 60 caracteres")]
        public string? Senha { get; set; }


        // referencia tabela tipo usuario = FK 
        [Required(ErrorMessage = "O tipo do Usuario é obrigatório.")]
        public Guid IdTipoUsuario { get; set; }


        [ForeignKey(nameof(IdTipoUsuario))] 
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
