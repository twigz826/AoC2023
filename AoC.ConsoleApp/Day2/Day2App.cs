﻿using AoC.Core.Day2;
using System.Text.RegularExpressions;

namespace AoC.ConsoleApp.Day2
{
    public class Day2App
    {
        public List<string?> GameHistory = new();

        public List<CubeConundrumGame> CubeConundrumGames = new();

        public void RunFirstChallenge()
        {
            Console.WriteLine("Puzzle input values. Enter 'end' when all values have been entered\nValues: ");

            while (true)
            {
                var puzzleInput = Console.ReadLine();

                if (IsInputComplete(puzzleInput))
                {
                    break;
                }

                GameHistory.Add(puzzleInput);
            }

            var mappedGameInputData = ParseInput(GameHistory);

            var validGames = CubeConundrumPlayer.PlayGames(mappedGameInputData);

            Console.WriteLine($"Valid games: {validGames}");
        }

        private List<CubeConundrumGame> ParseInput(List<string?> puzzleInput)
        {
            foreach (var game in puzzleInput)
            {
                var ccGame = new CubeConundrumGame();
                var gameString = SplitIntoGames(game);

                var gameId = RetrieveGameId(gameString);
                ccGame.Id = gameId;

                var separateCubeDraws = SplitGameDrawsBySemiColon(gameString);
                foreach (var cubeDraw in separateCubeDraws)
                {
                    AddDrawToCubeConundrumGame(cubeDraw, ccGame);
                }
                CubeConundrumGames.Add(ccGame);
            }

            return CubeConundrumGames;
        }

        private void AddDrawToCubeConundrumGame(string cubeDraw, CubeConundrumGame ccGame)
        {
            var cubeDrawRecord = new Dictionary<string, int>();
            var matches = Regex.Matches(cubeDraw, "(\\d+)\\s(\\w+)");
            foreach (var match in matches.Cast<Match>())
            {
                cubeDrawRecord[match.Groups[2].Value] = int.Parse(match.Groups[1].Value);
            }
            ccGame.CubeDraws.Add(cubeDrawRecord);
        }

        private IEnumerable<string> SplitGameDrawsBySemiColon(List<string> gameString)
        {
            return gameString[1].Split(';');
        }

        private int RetrieveGameId(List<string> gameString)
        {
            _ = int.TryParse(Regex.Match(gameString[0], "\\d+").Value, out var gameId);
            return gameId;
        }

        private List<string> SplitIntoGames(string? game)
        {
            return Regex.Split(game, "(Game\\s\\d+:)")
                        .Where(s => !string.IsNullOrWhiteSpace(s))
                        .ToList();
        }

        private static bool IsInputComplete(string? input)
        {
            return input?.ToLower() == "end";
        }
    }
}
