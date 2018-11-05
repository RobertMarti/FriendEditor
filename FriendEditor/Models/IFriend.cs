using System;

namespace FriendEditor.Models
{
    public interface IFriend
    {
        string Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }

        DateTime BirthDate { get; set; }
        bool IsDeveloper { get; set; }

    }
}