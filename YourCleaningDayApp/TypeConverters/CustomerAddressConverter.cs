using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using YourCleaningDayApp.Data.Customers;
using YourCleaningDayApp.Extensions;
using YourCleaningDayApp.ViewModels;

namespace YourCleaningDayApp.TypeConverters
{
    //https://github.com/TinyMapper/TinyMapper/issues/36
    //https://github.com/TinyMapper/TinyMapper/wiki/Custom-mapping
    public class CustomerAddressConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(CustomerViewModel);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            var concreteValue = (Customer)value;
            var result = new CustomerViewModel
            {
                CustomerId = concreteValue.CustomerId,
                FirstName = concreteValue.FirstName,
                LastName = concreteValue.LastName,
                PhoneNumber = concreteValue.PrimaryPhoneNumber.FormatWith("") ,
                EmailAddress = concreteValue.PrimaryEmailAddress,
                Gender = concreteValue.Gender == "M" ? "Male" : "Female",
                Address1 = concreteValue.Address.Address1,
                Address2 = concreteValue.Address.Address2,
                City = concreteValue.Address.City,
                State = concreteValue.Address.StateId,
                Zip = concreteValue.Address.Zipcode,
                MemberDate = concreteValue.CreatedDate.ToShortDateString(),
                MapUrl = concreteValue.Address.MapUrl
            };
            return result;
        }
    }
}

