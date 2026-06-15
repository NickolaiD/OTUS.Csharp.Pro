namespace DIP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var gameUI = new GameUI();
            var gameLogic = new GameLogic();
            var random = new Random();

            var game = new Game(gameLogic, gameUI, random);
            game.Play(0, 100, 10);
            
        }
    }
}
