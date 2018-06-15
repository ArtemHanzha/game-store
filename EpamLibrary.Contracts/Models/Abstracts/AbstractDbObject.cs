using System.ComponentModel.DataAnnotations;

namespace EpamLibrary.Contracts.Models.Abstracts
{
    public abstract class AbstractDbObject
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
