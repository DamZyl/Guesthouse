using System;
using System.Collections.Generic;
using System.Text;

namespace Guesthouse.Core.Utils.Exceptions
{
    public static class ErrorCodes
    {
        public static string BookedRoom => "booked_room";
        public static string InvalidCost => "invalid_cost";
        public static string InvalidDate => "invalid_date";
        public static string InvalidDescription => "invalid_description";
        public static string InvalidEmail => "invalid_email";
        public static string InvalidFirstName => "invalid_first_name";
        public static string InvalidFloor => "invalid_floor";
        public static string InvalidLastName => "invalid_last_name";
        public static string InvalidName => "invalid_name";
        public static string InvalidNumber => "invalid_number";
        public static string InvalidPassword => "invalid_password";
        public static string InvalidPhoneNumber => "invalid_phone_number";
        public static string InvalidPrice => "invalid_price";
        public static string InvalidRole => "invalid_role";
        public static string NotBookedRoom => "not_booked_room";
    }
}