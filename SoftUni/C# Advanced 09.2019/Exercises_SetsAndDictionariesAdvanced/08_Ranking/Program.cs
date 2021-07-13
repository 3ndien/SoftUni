using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();
            var candidates = new Dictionary<string, Dictionary<string, long>>();

            string[] data = null;

            while (true)
            {
                data = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries);

                if (data[0] == "end of contests")
                {
                    break;
                }

                string contest = data[0];
                string password = data[1];

                contests[contest] = password;
            }

            while (true)
            {
                data = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);

                if (data[0] == "end of submissions")
                {
                    break;
                }

                string contest = data[0];
                string password = data[1];
                string username = data[2];
                int points = int.Parse(data[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!candidates.ContainsKey(username))
                    {
                        candidates.Add(username, new Dictionary<string, long>());
                    }
                    if (!candidates[username].ContainsKey(contest))
                    {
                        candidates[username].Add(contest, points);
                    }
                    if (points > candidates[username][contest])
                    {
                        candidates[username][contest] = points;
                    }
                }
            }

            var orderedCandidates = candidates
                .ToDictionary(k => k.Key, 
                v => v.Value.OrderByDescending(x => x.Value)
                .ToDictionary(ks => ks.Key, vs => vs.Value));

            KeyValuePair<string, Dictionary<string, long>> bestCandidate = orderedCandidates.First();
            long bestPoints = bestCandidate.Value.Values.Sum();

            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var userKVP in candidates.OrderBy(n => n.Key))
            {
                string username = userKVP.Key;
                Dictionary<string, long> userContests = userKVP.Value;
                Console.WriteLine(username);

                foreach (var contestKVP in userContests.OrderByDescending(up => up.Value))
                {
                    Console.WriteLine($"#  {contestKVP.Key} -> {contestKVP.Value}");
                }
            }
        }
    }
}
