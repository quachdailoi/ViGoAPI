using API.Services.Constract;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;

namespace API.Services
{
    public class BookingDetailDriverService : IBookingDetailDriverService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingDetailDriverService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<BookingDetailDriver>> Create(List<BookingDetailDriver> bookingDetailDrivers) => _unitOfWork.BookingDetailDrivers.Add(bookingDetailDrivers); 
    }
}
