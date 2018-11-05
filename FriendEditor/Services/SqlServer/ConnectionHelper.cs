using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendEditor.Services.SqlServer
{
    public class ConnectionHelper
    {
        protected static string MetaData = "metadata=res://*/Services.Friends.csdl|res://*/Services.Friends.ssdl|res://*/Services.Friends.msl";

        public static FriendsEntities GetDataContext(string sDataSource, string sInitialCatalog)
        {
            return new FriendsEntities(GetConnectionString(MetaData, sDataSource, sInitialCatalog));
        }

        public static string GetConnectionString(string metaData, string sDataSource, string sInitialCatalog)
        {
            const string appName = "EntityFramework";
            const string providerName = "System.Data.SqlClient";

            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
            sqlBuilder.DataSource = sDataSource;
            sqlBuilder.InitialCatalog = sInitialCatalog;
            sqlBuilder.MultipleActiveResultSets = true;
            sqlBuilder.IntegratedSecurity = true;
            sqlBuilder.ApplicationName = appName;

            EntityConnectionStringBuilder efBuilder = new EntityConnectionStringBuilder();
            efBuilder.Metadata = metaData;
            efBuilder.Provider = providerName;
            efBuilder.ProviderConnectionString = sqlBuilder.ConnectionString;

            return efBuilder.ConnectionString;
        }

    }
}
