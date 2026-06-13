using OCP;

namespace OCP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var gameUI = new GameUI();
            var strategy = new ClassicGameStrategy();
            //var strategy = new HotColdGameStrategy();
            var random = new Random();

            var game = new Game(strategy, gameUI, random);
            game.Play(0, 100, 10);
            
        }
    }
}
