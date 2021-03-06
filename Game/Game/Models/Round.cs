﻿using System;

namespace Game.Models
{
    // Enum for the types of round state.
    public enum RoundEnum
    {
        Unknown = 0,
        NextTurn = 1,
        NewRound = 2,
        GameOver = 3,
    }

    // Types of players in a round
    public enum PlayerTypeEnum
    {
        Unknown = 0,
        Character = 1,
        Monster = 2,
    }

    // The information about a Player, this allows players and monsters to be together in a single list.
    public class PlayerInfo
    {
        // TurnOrder
        public int Order { get; set; }

        // guid of the original data it links back to
        public string Guid { get; set; }

        // alive status, !alive will be removed from the list
        public bool Alive { get; set; }

        // Sorting Order is :  Speed, Level, ExperiencePoints, PlayerType, Name, ListOrder

        // Total speed, including level and items
        public int Speed { get; set; }

        // Level of character or monster
        public int Level { get; set; }

        // The experience points the player has used in sorting ties...
        public int ExperiencePoints { get; set; }

        // The type of player, character comes before monster
        public PlayerTypeEnum PlayerType { get; set; }

        // Sorting on the alpha name if needed
        public string Name { get; set; }

        public string MaxHP { get; set; }

        public string CurrentHP { get; set; }

        // Finally if all of the above are the same, sort based on who was loaded first into the list...
        public int ListOrder;

        // Need because of the instantiation below
        public PlayerInfo()
        {

        }

        // Take a character and add it to the Player
        public PlayerInfo(Character data)
        {
            PlayerType = PlayerTypeEnum.Character;
            Guid = data.Guid;
            Alive = data.Alive;
            ExperiencePoints = data.ExperienceTotal;
            Level = data.Level;
            Name = data.Name;
            CurrentHP = data.GetHealthCurrent().ToString();
            MaxHP = data.GetHealthMax().ToString();
            Speed = data.GetSpeed();
        }

        // Take a monster and add it to the player
        public PlayerInfo(Monster data)
        {
            PlayerType = PlayerTypeEnum.Monster;
            Guid = data.Guid;
            Alive = data.Alive;
            ExperiencePoints = data.ExperienceTotal;
            Level = data.Level;
            Name = data.Name;
            CurrentHP = data.GetHealthCurrent().ToString();
            MaxHP = data.GetHealthMax().ToString();
            Speed = data.GetSpeed();
        }
    }
}
