﻿using System.Data;
using System.Text;
using Yupi.Data.Base.Adapters.Interfaces;
using Yupi.Game.Commands.Interfaces;
using Yupi.Game.GameClients.Interfaces;
using Yupi.Game.Users;

namespace Yupi.Game.Commands.Controllers
{
    /// <summary>
    ///     Class UserInfo. This class cannot be inherited.
    /// </summary>
    internal sealed class UserInfo : Command
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="UserInfo" /> class.
        /// </summary>
        public UserInfo()
        {
            MinRank = 5;
            Description = "Tells you information of the typed username.";
            Usage = ":userinfo [USERNAME]";
            MinParams = 1;
        }

        public override bool Execute(GameClient session, string[] pms)
        {
            if (pms.Length != 1)
                return true;

            if (string.IsNullOrEmpty(pms[0]))
                return true;

            string userName = Yupi.FilterInjectionChars(pms[0]);

            Habbo userCached = Yupi.GetHabboForName(userName);

            if (userCached == null)
                return true;

            StringBuilder builder = new StringBuilder();

            if (userCached.CurrentRoom != null)
            {
                builder.Append($" - ROOM INFORMATION [{userCached.CurrentRoom.RoomId}] - \r");
                builder.Append($"Owner: {userCached.CurrentRoom.RoomData.Owner}\r");
                builder.Append($"Room Name: {userCached.CurrentRoom.RoomData.Name}\r");
                builder.Append($"Current Users: {userCached.CurrentRoom.UserCount} / {userCached.CurrentRoom.RoomData.UsersMax}");
            }

            session.SendNotif(string.Concat("User info for: ", userName, " \rUser ID: ", userCached.Id, ":\rRank: ",
                userCached.Rank, "\rCurrentTalentLevel: ", userCached.CurrentTalentLevel, " \rCurrent Room: ", userCached.CurrentRoomId,
                " \rCredits: ", userCached.Credits, "\rDuckets: ", userCached.Duckets, "\rDiamonds: ", userCached.Diamonds,
                "\rMuted: ", userCached.Muted.ToString(), "\r\r\r", builder.ToString()));

            return true;
        }
    }
}