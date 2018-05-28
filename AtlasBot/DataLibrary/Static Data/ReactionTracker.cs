using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtlasBot.Modules;
using Discord;
using Discord.WebSocket;

namespace DataLibrary.Static_Data
{
    public static class ReactionTracker
    {
        private static List<ReactionList> _reactionList = new List<ReactionList>();
        public static IUserMessage Message;
        public static List<RoleEmote> roleEmote = new List<RoleEmote>();
        public static void ReactionAdded(Cacheable<IUserMessage, ulong> cacheable, ISocketMessageChannel socketMessageChannel,
            SocketReaction arg3)
        {
            ReactionList message = _reactionList.SingleOrDefault(x => x.MessageId == arg3.MessageId);
            if (message != null)
            {
                ReactionTracked reaction = new ReactionTracked();
                reaction.Date = DateTime.Now;
                reaction.Emoji = arg3.Emote.Name;
                reaction.Username = arg3.User.Value.Username;
                message.Reactions.Add(reaction);
            }
        }

        public static void SubscribeMessage(ulong messageId)
        {
            ReactionList message = new ReactionList();
            message.MessageId = messageId;
            message.Reactions = new List<ReactionTracked>();
            _reactionList.Add(message);
        }

        public static void UnsubscribeMessage(ulong message)
        {
            int index = _reactionList.IndexOf(_reactionList.FirstOrDefault(x => x.MessageId == message));
            _reactionList.RemoveAt(index);
        }

        public static ReactionList GetReactionList(ulong messageId)
        {
            return _reactionList.FirstOrDefault(x => x.MessageId == messageId);
        }
    }

    public class ReactionList
    {
        public ulong MessageId { get; set; }
        public List<ReactionTracked> Reactions { get; set; }
    }
    public class ReactionTracked
    {
        public string Username { get; set;}
        public DateTime Date { get; set; }
        public string Emoji { get; set; }
    }
}
