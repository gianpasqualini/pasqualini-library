using PasqualiniLibrary.games;
using System;
using Xunit;

namespace XUnitTestProject
{
    public class RockPaperScissorsTest
    {
        [Fact]
        public void TestPlayerWinner1()
        {
            string[] p1 = new string[] { "ARMANDO", "P" };
            string[] p2 = new string[] { "DAVE", "S" };

            Array[] players = new Array[] { p1, p2 };
            RockPaperScissors rps = new RockPaperScissors();
            string[] ret = rps.Rps_player_winner(players);
            Assert.Equal("DAVE", ret[0]);
            
        }

        [Fact]
        public void TestPlayerWinner1InvertedPlayers()
        {
            string[] p1 = new string[] { "ARMANDO", "P" };
            string[] p2 = new string[] { "DAVE", "S" };

            Array[] players = new Array[] { p2,p1 };
            RockPaperScissors rps = new RockPaperScissors();
            string[] ret = rps.Rps_player_winner(players);
            Assert.Equal("DAVE", ret[0]);

        }

        [Fact]
        public void TestPlayerWinner2()
        {
            string[] p1 = new string[] { "ARMANDO", "R" };
            string[] p2 = new string[] { "DAVE", "S" };

            Array[] players = new Array[] { p2, p1 };
            RockPaperScissors rps = new RockPaperScissors();
            string[] ret = rps.Rps_player_winner(players);
            Assert.Equal("ARMANDO", ret[0]);

        }

        [Fact]
        public void TestEqualMoves()
        {
            string[] p1 = new string[] { "ARMANDO", "R" };
            string[] p2 = new string[] { "DAVE", "R" };

            Array[] players = new Array[] { p1, p2 };
            RockPaperScissors rps = new RockPaperScissors();
            string[] ret = rps.Rps_player_winner(players);
            Assert.Equal("ARMANDO", ret[0]);

        }

        
        [Fact]
        public void TestInvalidNumberOfPlayers()
        {
            string[] p1 = new string[] { "ARMANDO", "R" };
            string[] p2 = new string[] { "DAVE", "P" };
            string[] p3 = new string[] { "JOHN", "S" };

            Array[] players = new Array[] { p1, p2, p3 };
            RockPaperScissors rps = new RockPaperScissors();
            Assert.Throws<WrongNumberOfPlayersError>(() => rps.Rps_player_winner(players));

        }

        [Fact]
        public void TestInvalidStrategy()
        {
            string[] p1 = new string[] { "ARMANDO", "I" };
            string[] p2 = new string[] { "DAVE", "P" };
            
            Array[] players = new Array[] { p1, p2 };
            RockPaperScissors rps = new RockPaperScissors();
            Assert.Throws<NoSuchStrategyError>(() => rps.Rps_player_winner(players));

        }

        [Fact]
        public void TestTournament()
        {
            string tournament = @"[
            [
                [ ['Armando', 'P'], ['Dave', 'S'] ],
                [ ['Richard', 'R'], ['Michael', 'S'] ],
            ],
            [
                [ ['Allen', 'S'], ['Omer', 'P'] ],
                [ ['David E.', 'R'], ['Richard X.', 'P'] ]
            ]
            ]";

            
            RockPaperScissors rps = new RockPaperScissors();
            string[] winner = rps.Rps_tournament_winner(tournament);
            Assert.Equal("Richard", winner[0]);
        }


    }
}
