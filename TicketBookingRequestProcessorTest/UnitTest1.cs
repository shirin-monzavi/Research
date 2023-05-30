using Moq;
using TicketBooking;

namespace TicketBookingRequestProcessorTest
{
    public class UnitTest1
    {
        private readonly TicketBookingRequestProcessor sut;
        private readonly Mock<ITicketBookingRepository> ticketBookingRepositoryMock;

        public UnitTest1()
        {
            ticketBookingRepositoryMock = new Mock<ITicketBookingRepository>();

            sut = new TicketBookingRequestProcessor(ticketBookingRepositoryMock.Object);
        }

        [Fact]
        public void BookTicket_Should_Return_Ticket_With_Requested_Value()
        {
            //Arrange
            var reuest = new TocketBookingRequest
            {
                FirstName = "shirin",
                LastName = "Rahman",
                EmailAddressAttribute = "shirin.monzavi@yahoo.com"
            };

            //Act
            var actual = sut.BookTickert(reuest);

            //Assert
            Assert.NotNull(actual);
            Assert.Equal(reuest.FirstName, actual.FirstName);
            Assert.Equal(reuest.LastName, actual.LastName);
            Assert.Equal(reuest.EmailAddressAttribute, actual.EmailAddressAttribute);
        }

        [Fact]
        public void BookTicket_Pass_Null_Booking_Request_Should_Return_Null()
        {
            //Arrange

            //Act
            var exception = Assert.Throws<ArgumentNullException>(() => sut.BookTickert(null));

            //Assert
            Assert.Equal("request", exception.ParamName);
        }

        [Fact]
        public void Save_BookedTicket_Should_Be_Saved_To_Database()
        {
            //Arrage
            TocketBookingRequest savedTicketBooking = null;

            ticketBookingRepositoryMock.Setup(x => x.Save(It.IsAny<TocketBookingRequest>()))
                  .Callback<TocketBookingRequest>((ticketBooking) =>
                  {
                      savedTicketBooking = ticketBooking;
                  });

            var reuest = new TocketBookingRequest
            {
                FirstName = "shirin",
                LastName = "Rahman",
                EmailAddressAttribute = "shirin.monzavi@yahoo.com"
            };

            //Act
            var actual = sut.BookTickert(reuest);

            //Assert
            ticketBookingRepositoryMock.Verify(x => x.Save(It.IsAny<TocketBookingRequest>()), Times.Once);
            Assert.NotNull(savedTicketBooking);
            Assert.Equal(reuest.FirstName, savedTicketBooking.FirstName);
            Assert.Equal(reuest.LastName, savedTicketBooking.LastName);
        }
    }
}