using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Configurations
{
    public static class ValuesLimiter
    {
        public const int ImageLinkMaxLength = 50;
        public const int PhoneNumberMaxLength = 20;
        public const int NameMaxLength = 100;
        public const int EmailMaxLength = 256;
        public const int CodeMaxLength = 50;
        public const int DescriptionMaxLength = 500;
        public const int UsernameMaxLength = 50;
        public const int PasswordHashMaxLength = 256;
        public const int NationalIdMaxLength = 20;
        public const int AddressMaxLength = 250;
        public const int UrlMaxLength = 2083;
        public const string DefaultStringType = "nvarchar";
        // ===== JSON =====
        public const string JsonType = "nvarchar(max)";

        // ===== Numeric & Money =====
        public const string MoneyType = "decimal(18,2)";
        public const string IntType = "int";

        // ===== Date & Time =====
        public const string DateTimeType = "datetime2";
        public const string CreatedAtDefault = "GETUTCDATE()";

        // ===== Soft Delete =====
        public const string SoftDeleteType = "bit";
        public const bool SoftDeleteDefault = false;

        // ===== GUID =====
        public const string GuidType = "uniqueidentifier";

        // ===== Geo =====
        public const string LatitudeType = "decimal(9,6)";
        public const string LongitudeType = "decimal(9,6)";
    }
}
