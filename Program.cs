using System;
using AsyncTasks = System.Threading.Tasks;

using Discord;
using DotEnv;

namespace Discord_Bot {
    class Program {
        private Discord.WebSocket.DiscordSocketClient _client;
        
        public static void Main(string[] args) {
            DotEnv.Manager.Load(".env");
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        public async AsyncTasks.Task MainAsync() {
            _client = new Discord.WebSocket.DiscordSocketClient();
            string token = DotEnv.Manager.get("token");

            _client.Log += Program.Log;
            _client.MessageReceived += Program.ClientOnMessageReceived;

            await _client.LoginAsync(Discord.TokenType.Bot, token);
            await _client.StartAsync();

            await AsyncTasks.Task.Delay(-1); // run forever
        }

        private static AsyncTasks.Task Log(Discord.LogMessage msg) {
            System.Console.WriteLine(msg.ToString());
            return AsyncTasks.Task.CompletedTask;
        }

        private static AsyncTasks.Task ClientOnMessageReceived(
            Discord.WebSocket.SocketMessage arg
        ) {
            if (arg.Content.StartsWith("-hello")) {
                System.Console.WriteLine("command success!");
                arg.Channel.SendMessageAsync("Hello!");
            }
            return AsyncTasks.Task.CompletedTask;
        }
    }
}
