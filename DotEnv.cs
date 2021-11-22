namespace DotEnv {
    using System;
    using System.IO;

    public static class Manager {
        public static void Load(string filePath) {
            if (!File.Exists(filePath)) return;

            foreach (string line in File.ReadAllLines(filePath)) {
                string[] pair = line.Split('=');
                if (pair.Length != 2 || pair[1].Length == 0) continue;
                Environment.SetEnvironmentVariable(pair[0], pair[1]);
            }
        }

        public static void set(string key, string value) {
            Environment.SetEnvironmentVariable(key, value);
        }

        public static string get(string key) {
            return Environment.GetEnvironmentVariable(key);
        }
    }
}