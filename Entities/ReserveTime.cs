using DigiReserve.Authentication;
using System.ComponentModel.DataAnnotations;

namespace DigiReserve.Entities
{
    public class ReserveTime
    {
        public int ReserveTimeId { get; set; }
        public ApplicationUser Acceptor { get; set; }
        public ApplicationUser Reservatore { get; set; }
        public DateTime ReservedTime { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
