using System;

var words = System.IO.File.ReadAllLines("szavak.txt");
var rnd = new Random();
var target = words[rnd.Next(words.Length)];
var targetLower = target.ToLower();
var mask = new string('.', target.Length).ToCharArray();
int attempts = 0;

while (true)
{
    Console.Write("Tipp: ");
    var line = Console.ReadLine();
    if (line == null) break;
    var guess = line.Trim();
    if (guess == "") continue;
    if (guess.ToLower() == "stop") break;

    attempts++;
    if (guess.ToLower() == targetLower)
    {
        Console.WriteLine(target);
        Console.WriteLine(attempts);
        break;
    }

    var g = guess.ToLower();
    for (int i = 0; i < target.Length && i < g.Length; i++)
        if (g[i] == targetLower[i]) mask[i] = target[i];

    Console.WriteLine(new string(mask));
}