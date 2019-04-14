using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace PasqualiniLibrary.games
{
    public class RockPaperScissors
    {

        public string[] Rps_player_winner(Array[] players)
        {
            if (players.Length > 2)
            {
                throw new WrongNumberOfPlayersError();
            }
            foreach (string[] player in players)
            {
                Options o;
                if (!Enum.TryParse<Options>(player[1], true, out o))
                {
                    throw new NoSuchStrategyError();
                }
            }

            return CompareTo(players);
        }

        private string[] CompareTo(Array[] toCompare)
        {
            string[] playerOne = (string[])toCompare[0];
            Options moveOfPlayerOne;
            Enum.TryParse<Options>(playerOne[1], true, out moveOfPlayerOne);

            string[] playerTwo = (string[])toCompare[1];
            Options moveOfPlayerTwo;
            Enum.TryParse<Options>(playerTwo[1], true, out moveOfPlayerTwo);
            switch (moveOfPlayerOne)
            {
                case Options.r:
                    switch (moveOfPlayerTwo)
                    {
                        case Options.r: return playerOne;
                        case Options.p: return playerTwo;
                        case Options.s: return playerOne;
                    }
                    break;
                case Options.p:
                    switch (moveOfPlayerTwo)
                    {
                        case Options.r: return playerOne;
                        case Options.p: return playerOne;
                        case Options.s: return playerTwo;
                    }
                    break;
                case Options.s:
                    switch (moveOfPlayerTwo)
                    {
                        case Options.r: return playerTwo;
                        case Options.p: return playerOne;
                        case Options.s: return playerOne;
                    }
                    break;
            }
            return null;
        }

        public string[] Rps_tournament_winner(string script)
        {
            IList<Array[]> matches = parseMatches(script);

            int i = 0;
            Array[] nextMatch = new Array[2];
            string[] winner = new string[2];
            while (i < matches.Count)
            {
                Array[] match = matches[i];
                winner = Rps_player_winner(match);

                if (nextMatch[0] == null)
                {
                    nextMatch[0] = winner;
                }
                else if (nextMatch[1] == null)
                {
                    nextMatch[1] = winner;
                    matches.Add(nextMatch);
                    nextMatch = new Array[2];
                }
                i++;
            }
            return winner;
        }

        private IList<Array[]> parseMatches(String script)
        {
            IList<Array[]> ret = new List<Array[]>();

            //vai direto para o array de games (assume que sempre em um unico item de tournament
            JArray game = (JArray)JArray.Parse(script)[0];

            for (int i = 0; i < game.Count; i++)
            {
                JArray jsonGroup = (JArray)game[i];
                Array[] players = new Array[2];
                for (int j = 0; j < jsonGroup.Count; j++)
                {
                    JArray matches = (JArray)jsonGroup[j];

                    //JArray jsonPlayer = (JArray)matches[k];
                    string[] player = new string[] { matches[0].ToObject<String>(), matches[1].ToObject<String>() };
                    players[j] = player;
                }
                ret.Add(players);

            }
            return ret;
        }



        enum Options
        {
            r = 0,
            p = 1,
            s = 2
        }

    }
}
