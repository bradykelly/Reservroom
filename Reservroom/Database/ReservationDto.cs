﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reservroom.Database;

public class ReservationDto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int FloorNumber { get; set; }
    public int RoomNumber { get; set; }
    public string? UserName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
