using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendEditor.Services.SqlServer
{
    public partial class FriendsEntities
    {
	        public FriendsEntities(string connectionString)
            : base(connectionString)
        {
        }
    }
}
