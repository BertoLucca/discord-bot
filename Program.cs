using System;
using System.Threading.Tasks;

using Discord;

namespace Discord_Bot {
    class Program {
        private Discord.WebSocket.DiscordSocketClient _client;
        
        public static void Main(string[] args) {
            DotEnv.Manager.Load(".env");
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        public async Task MainAsync() {
            _client = new Discord.WebSocket.DiscordSocketClient();
            string token = DotEnv.Manager.get("token");
            _client.Log += this.Log;
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            await Task.Delay(-1);
        }

        private Task Log(Discord.LogMessage msg) {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
