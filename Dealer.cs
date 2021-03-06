﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    public class Dealer
    {
        private readonly Random _random = new Random();

        public List<Card> ShuffleDeck(List<Card> deck)
        {
            var shuffledDeck = new List<Card>();

            while (shuffledDeck.Count < deck.Count)
            {
                int _randomIndex = _random.Next(0, deck.Count);
                if (!shuffledDeck.Contains(deck[_randomIndex]))
                {
                    shuffledDeck.Add(deck[_randomIndex]);
                }
            }
            return shuffledDeck;
        }
        
        public List<Player> DistributeCards(List<Card> deck, List<Player> players)
        {
            var shuffledDeck = ShuffleDeck(deck);

            while (shuffledDeck.Count != 0)
            {
                foreach (var player in players)
                {
                    var card = shuffledDeck.FirstOrDefault();
                    player.TakeCards(card);
                    shuffledDeck.Remove(card);
                    
                    if (shuffledDeck.Count == 0)
                    {
                        break;
                    }
                }
            }
            return players;
        }
    }
}
