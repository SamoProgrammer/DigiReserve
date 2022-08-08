using DigiReserve.Authentication;
using System.ComponentModel.DataAnnotations;

namespace DigiReserve.Models
{
    public class ReserveTimeModel
    {
        [Required(ErrorMessage = "Acceptor Is Required")]
        public string AcceptorId { get; set; }
        [Required(ErrorMessage = "Reservatore Is Required")]
        public string ReservatoreId { get; set; }
        [DataType(DataType.DateTime, ErrorMessage = "Enter Valid Time")]
        [Required(ErrorMessage = "Time Is Required")]
        public DateTime ReservedTime { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
