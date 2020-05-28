using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using stuf.Core.UserAccounts;

namespace stuf.Commands {
    public class inforole : ModuleBase<SocketCommandContext> {

        /*
         * This Task is a command that, when ran, displays the XP and Level of the
         * user
         */
        [Command("user info"), Alias("info")]
        public async Task info(SocketGuildUser user = null) {

            if (user == null) user = Context.User as SocketGuildUser;

            var User = UserAccounts.GetOrCreateAccount(user.Id);
            EmbedBuilder Embed = new EmbedBuilder();
            Embed.WithTitle($"{user.Nickname} info:")
                .AddInlineField("Bot stats", $"**XP:** {User.XP}\n **Level:** {User.Lvl}")
                .WithColor(Color.Blue)
                .WithFooter($"{Context.Guild.Name}", Context.Guild.Owner.GetAvatarUrl())
                .WithCurrentTimestamp()
                .WithThumbnailUrl(user.GetAvatarUrl());
            await Context.Channel.SendMessageAsync("", false, Embed.Build());

        }
    }
}


