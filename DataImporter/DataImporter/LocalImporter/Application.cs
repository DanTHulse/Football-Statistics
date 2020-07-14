using System.Linq;

namespace LocalImporter
{
    public class Application : IApplication
    {
        private readonly FutbolContext _context;

        public Application(FutbolContext context)
        {
            this._context = context;
        }

        public void Run()
        {
            var teams = this._context.Team_v1.FirstOrDefault();
        }
    }
}
