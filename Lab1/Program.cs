using Lab1;

GameAccount firstPlayer = new GameAccount("Anton");
GameAccount secondPlayer = new GameAccount("Ivan");

firstPlayer.WinGame(secondPlayer, DateTime.Now, 5);
/*
try
{
    firstPlayer.LoseGame(secondPlayer, DateTime.Now, 15);
}
catch (InvalidOperationException e)
{
    Console.WriteLine("Error");
    Console.WriteLine(e.ToString());
    return;
}
*/
/*
try
{
    firstPlayer.LoseGame(secondPlayer, DateTime.Now, -7);
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine("Error!");
    Console.WriteLine(e.ToString());
    return;
}
*/
firstPlayer.LoseGame(secondPlayer, DateTime.Now, 7);
firstPlayer.WinGame( secondPlayer, DateTime.Now, 4);
firstPlayer.WinGame(secondPlayer, DateTime.Now, 1);

secondPlayer.WinGame(firstPlayer, DateTime.Now, 3);
secondPlayer.WinGame(firstPlayer, DateTime.Now, 1);
secondPlayer.WinGame(firstPlayer, DateTime.Now, 6);
secondPlayer.LoseGame(firstPlayer, DateTime.Now, 4);
secondPlayer.LoseGame(firstPlayer, DateTime.Now, 8);

Console.WriteLine(firstPlayer.GetStats());
Console.WriteLine(secondPlayer.GetStats());
Console.WriteLine($"{firstPlayer.UserName}'s Rating: " + firstPlayer.CurrentRating);
Console.WriteLine($"{secondPlayer.UserName}'s Rating: " + secondPlayer.CurrentRating);
