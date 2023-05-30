namespace TicketBooking
{
    public class TicketBookingRequestProcessor
    {
        private readonly ITicketBookingRepository ticketBookingRepository;

        public TicketBookingRequestProcessor(ITicketBookingRepository ticketBookingRepository)
        {
            this.ticketBookingRepository = ticketBookingRepository;
        }

        public TicketResponse BookTickert(TocketBookingRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            this.ticketBookingRepository.Save(request);

            return new TicketResponse
            {
                EmailAddressAttribute = request.EmailAddressAttribute,
                FirstName = request.FirstName,
                LastName = request.LastName,
            };
        }
    }
}