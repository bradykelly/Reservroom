using System;

namespace Reservroom.Models;

public class Reservation
{
    public RoomId RoomId { get; }
    public string UserName { get; }
    public DateTime StartTime { get; }
    public DateTime EndTime { get; }
    public TimeSpan Length => EndTime.Subtract(StartTime);

    public Reservation(RoomId roomId, string userName, DateTime startTime, DateTime endTime)
    {
        RoomId = roomId;
        UserName = userName;
        StartTime = startTime;
        EndTime = endTime;
    }

    public bool Conflicts(Reservation reservation)
    {
        if (reservation.RoomId != RoomId)
        {
            return false;
        }

        return reservation.StartTime < EndTime || reservation.EndTime > StartTime;
    }
}
