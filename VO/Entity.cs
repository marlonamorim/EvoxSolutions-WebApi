using System.ComponentModel.DataAnnotations;

namespace EvoxSolutions.WebApi.VO {
    public class Entity {
        
        [Key]
        public int Id { get; private set; }
    }
}