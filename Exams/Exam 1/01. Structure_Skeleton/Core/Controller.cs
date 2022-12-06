using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private HotelRepository hotels;

        public Controller()
        {
            hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            if (hotels.Select(hotelName) == null)
            {
                hotels.AddNew(new Hotel(hotelName, category));
                return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
            }

            return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            if (!hotels.All().Any(x => x.Category == category))
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }

            var matchingHotels = hotels.All()
                .Where(x => x.Category == category)
                .OrderBy(x => x.FullName);

            bool isBookingSuccessful = false;
            IHotel hotelBooked = null;
            IBooking booking = null;
            var bookingNumber = -1;

            foreach (var hotel in matchingHotels)
            {
                var matchingRooms = hotel.Rooms.All()
                    .Where(x => x.PricePerNight > 0)
                    .OrderBy(x => x.BedCapacity);

                foreach (var room in matchingRooms)
                {
                    if (room.BedCapacity >= adults + children)
                    {
                        hotelBooked = hotel;
                        isBookingSuccessful = true;
                        bookingNumber = hotelBooked.Bookings.All().Count() + 1;
                        booking = new Booking(room, duration, adults, children, bookingNumber);
                        break;
                    }
                }

                if (isBookingSuccessful)
                {
                    break;
                }
            }

            if (!isBookingSuccessful)
            {
                return string.Format(OutputMessages.RoomNotAppropriate);
            }

            hotelBooked.Bookings.AddNew(booking);
            return string.Format(OutputMessages.BookingSuccessful, bookingNumber, hotelBooked.FullName);
        }

        public string HotelReport(string hotelName)
        {
            var hotel = hotels.Select(hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            var sb = new StringBuilder();

            sb.AppendLine($"Hotel name: {hotel.FullName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:f2} $");
            sb.AppendLine($"--Bookings:");

            if (!hotel.Bookings.All().Any())
            {
                sb.AppendLine();
                sb.AppendLine($"none");
            }
            else
            {
                foreach (var booking in hotel.Bookings.All())
                {
                    sb.AppendLine();
                    sb.AppendLine(booking.BookingSummary());
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            var hotel = hotels.Select(hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (roomTypeName != nameof(DoubleBed) && roomTypeName != nameof(Apartment) && roomTypeName != nameof(Studio))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RoomTypeIncorrect));
            }

            if (hotel.Rooms.Select(roomTypeName) == null)
            {
                return string.Format(OutputMessages.RoomTypeNotCreated);
            }

            if (hotel.Rooms.Select(roomTypeName).PricePerNight > 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CannotResetInitialPrice));
            }

            hotel.Rooms.Select(roomTypeName).SetPrice(price);
            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            var hotel = hotels.Select(hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (hotel.Rooms.Select(roomTypeName) != null)
            {
                return string.Format(OutputMessages.RoomTypeAlreadyCreated);
            }

            IRoom room;

            if (roomTypeName == nameof(DoubleBed))
            {
                room = new DoubleBed();
            }
            else if (roomTypeName == nameof(Apartment))
            {
                room = new Apartment();
            }
            else if (roomTypeName == nameof(Studio))
            {
                room = new Studio();
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RoomTypeIncorrect));
            }

            hotel.Rooms.AddNew(room);
            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }
    }
}
