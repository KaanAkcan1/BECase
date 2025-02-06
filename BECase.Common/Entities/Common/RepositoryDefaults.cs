using BECase.Common.Enums.Common;

namespace BECase.Common.Entities.Common
{
    public class RepositoryDefaults
    {
        public const int DefaultEntityStatus = 1;

        public const string EntityStatusPropertyValueGroupName = nameof(EntityStatus);

        public const int AppSettingsPropertyValueId = 999999;

        public const string identityTablesPrefix = "App";

        public static class UserId
        {
            public static readonly Guid SystemAdministrator = new Guid("99999999-9999-9999-9999-999999999999");
            public static readonly Guid Administrator = new Guid("88888888-8888-8888-8888-888888888888");
            public static readonly Guid System = new Guid("11111111-1111-1111-1111-111111111111");
            public static readonly Guid Anonymous = new Guid("00000000-0000-0000-0000-000000000000");
        }

        public static class AdminLoginValues
        {
            public const string UserName = "admin";
            public const string Password = "password";
            public const string Email = "admin@hbcase.com";
            public const string PhoneNumber = "05076111600";
        }

    }
}
