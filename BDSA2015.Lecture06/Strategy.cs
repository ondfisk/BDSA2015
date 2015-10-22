using System;

namespace BDSA2015.Lecture06
{
    public class Strategy
    {
        public static void Execute()
        {
            var users = new HashStrategy[] {
                 new SHA1User { Password = "P@ssw0rd" },
                 new SHA512User { Password = "P@ssw0rd" }
            };

            foreach (var user in users)
            {
                Console.WriteLine($"Hash: {user.Hash}, Salt: {user.Salt}");
            }
        }
    }
}
