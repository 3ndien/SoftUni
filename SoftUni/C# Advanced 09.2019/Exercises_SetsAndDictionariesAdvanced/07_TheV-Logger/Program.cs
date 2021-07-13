using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_TheV_Logger
{
    public class Profil
    {
        public Profil(string username)
        {
            Username = username;
            Followers = new SortedSet<string>();
            Following = new SortedSet<string>();
        }

        public string Username { get; set; }

        public int Count => Followers.Count;

        public SortedSet<string> Following { get; set; }

        public SortedSet<string> Followers { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var vloggers = new Dictionary<string, Profil>();

            while (true)
            {
                string[] inputLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (inputLine.Length == 1)
                {
                    int totalCountVloggers = vloggers.Count;
                    Dictionary<string, Profil> orderByMostFamous = vloggers
                        .OrderByDescending(v => v.Value.Count)
                        .ThenBy(v => v.Value.Following.Count)
                        .ToDictionary(k => k.Key, v => v.Value);

                    Console.WriteLine($"The V-Logger has a total of { totalCountVloggers } vloggers in its logs.");

                    int count = 1;
                    foreach (var kvp in orderByMostFamous)
                    {
                        string vloggerName = kvp.Key;
                        Profil profil = kvp.Value;

                        Console.WriteLine($"{count}. {vloggerName} : {profil.Followers.Count} followers, {profil.Following.Count} following");

                        if (count == 1 && profil.Followers.Count != 0)
                        {
                            foreach (var follower in profil.Followers)
                            {
                                Console.WriteLine($"*  {follower}");
                            }
                        }
                        count++;
                    }

                    break;
                }

                if (inputLine.Length == 4)
                {
                    string vlogger = inputLine[0];

                    if (vloggers.ContainsKey(vlogger))
                    {
                        continue;
                    }
                    vloggers.Add(vlogger, new Profil(vlogger));
                }

                if (inputLine.Length == 3)
                {
                    string follower = inputLine[0];
                    string followed = inputLine[2];

                    if (!vloggers.ContainsKey(follower) || 
                        !vloggers.ContainsKey(followed) ||
                        followed == follower ||
                        vloggers[follower].Following.Any(f => f == followed) ||
                        vloggers[followed].Followers.Any(f => f == follower))
                    {
                        continue;
                    }

                    vloggers[follower].Following.Add(followed);
                    vloggers[followed].Followers.Add(follower);
                }
            }
        }
    }
}
