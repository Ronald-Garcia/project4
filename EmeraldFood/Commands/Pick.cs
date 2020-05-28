using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Net;
using Discord.WebSocket;
using stuf.Core.UserAccounts;

namespace EmeraldFood.Commands {
    public class Pick : ModuleBase<SocketCommandContext> {

        /*
         * This Task is a command that, when ran, will first check if there is a food available
         * if not, return, but if there is a food, pick up the food and add it to the XP of the user,
         * deleting both messages
         */
        [Command("eat")]
        public async Task eat() {
            if (Main.main.foodAppeared) {
                await Context.Message.DeleteAsync();
                var m = await Context.Channel.GetMessageAsync(Main.main.messageID);
                await m.DeleteAsync();
                Main.main.foodAppeared = false;
                int p = new Random().Next(3, 8);
                await ReplyAsync(Context.User.Mention + " has picked up the food! They gained " + p + " points!");
                var user = UserAccounts.GetOrCreateAccount(Context.User.Id);
                user.XP += (uint)p;
            }
        }
    }
}
