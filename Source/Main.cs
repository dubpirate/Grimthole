using System;

namespace Grimthole
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Programs()
        {
            using (var game = new Grimthole())
                game.Run();
        }
    }
#endif
}
