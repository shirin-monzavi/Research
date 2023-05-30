namespace TicketBooking
{
    public interface ITicketBookingRepository
    {
        void Save(TocketBookingRequest request);
    }
}