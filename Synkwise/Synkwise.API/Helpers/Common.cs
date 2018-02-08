using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Synkwise.API.Helpers
{
    public static class Common
    {
        public static string AppUrl = GetWebConfiguration("webConfigurationItems:appUrl");

        public static int InvitationExpirationDays = Int32.Parse(GetWebConfiguration("webConfigurationItems:invitationExpirationDays"));

        public static List<int> RoleUIRestriciton
        {
            get
            {
                var roleList = GetWebConfiguration("webConfigurationItems:restrictedUIRoles");
                return string.IsNullOrEmpty(roleList) ? new List<int>() : roleList.Split(',').Select(Int32.Parse).ToList();
            }
        }


        public static string GetWebConfiguration(string key)
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var config = builder.Build();

            var configValue = config.AsEnumerable().FirstOrDefault(c => c.Key == key).Value;

            if (configValue == null)
                return string.Empty;

            return configValue;
        }
    }
}
