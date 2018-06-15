#region Using Statements
using AppKit;
#endregion

namespace Grimthole.MacOS.Source
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            NSApplication.Init();
            
			using (var game = new Grimthole())
            {
                game.Run();
            }
        }
    }
}
