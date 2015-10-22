using System.Threading.Tasks;

namespace BDSA2015.Lecture07
{
    class Fail
    {
        static void MainFail(string[] args)
        {
            var t = Task.Run(() => string.Join(null, null));

            t.Wait();
        }
    }
}
