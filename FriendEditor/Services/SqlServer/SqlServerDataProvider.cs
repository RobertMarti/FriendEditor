using System;
using System.Collections.Generic;
using System.Linq;
using FriendEditor.Models;

namespace FriendEditor.Services.SqlServer
{
    public class SqlServerDataProvider : IDataProvider
    {
        //protected static string DataSource = @"EIGER\SQLEXPRESS";
        //protected static string InitialCatalog = "Friends";


        public static FriendsEntities DataContext { get; set; }

        public SqlServerDataProvider()
        {
            //DataContext = ConnectionHelper.GetDataContext(DataSource, InitialCatalog);
            DataContext = new FriendsEntities();
        }

        #region CRUD

        public bool Delete(IFriend friend)
        {
            try
            {
                tabFriend tFriend = new tabFriend{Id = friend.Id};
                DataContext.tabFriends.Remove(tFriend);

                DataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<IFriend> GetAllFriends()
        {
            var friends = new List<IFriend>();
            foreach (var f in DataContext.tabFriends)
            {
                var friend = GetFriend(f);

                friends.Add(friend);
            }

            return friends;
        }


        public IFriend GetFriendById(string id)
        {
            var tFriend = DataContext.tabFriends.SingleOrDefault(x => x.Id == id);
            if (tFriend == null) return null;

            var friend = GetFriend(tFriend);

            return friend;
        }

        public bool Insert(IFriend friend)
        {
            try
            {
                var tFriend = new tabFriend
                {
                    Id = friend.Id,
                    Name = friend.Name,
                    Email = friend.Email,
                    IsDeveloper = friend.IsDeveloper,
                    BirthDate = friend.BirthDate
                };

                DataContext.tabFriends.Add(tFriend);

                DataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(IFriend friend)
        {
            var tFriend = DataContext.tabFriends.SingleOrDefault(x => x.Id == friend.Id);
            if (tFriend == null) return false;

            try
            {
                tFriend.Name = friend.Name;
                tFriend.Email = friend.Email;
                tFriend.IsDeveloper = friend.IsDeveloper;
                tFriend.BirthDate = friend.BirthDate;

                DataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static Friend GetFriend(tabFriend tFriend)
        {
            var friend = new Friend
            {
                Id = tFriend.Id,
                Name = tFriend.Name,
                Email = tFriend.Email,
                IsDeveloper = tFriend.IsDeveloper,
                BirthDate = tFriend.BirthDate
            };
            return friend;
        }

        #endregion
    }
}
