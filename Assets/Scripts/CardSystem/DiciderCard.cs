using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiciderCard : MonoBehaviour
{
    public string GetDeciderCard(CardSO playerCard, CardSO enemyCard)
    {
        if (playerCard == null || enemyCard == null)
            return null;

        string player = playerCard.cardName.ToLower();
        string enemy = enemyCard.cardName.ToLower();

        //player and enemy card same
        if (player == enemy)
        {
            return "draw";
        }

        //Rock beat scissors
        if (enemy  == "rock" && player == "scissors") return "rock";
        if (player == "rock" && enemy  == "scissors") return "rock";

        //Scissors beat paper
        if (enemy  == "paper" && player == "scissors") return "scissors";
        if (player == "paper" && enemy  == "scissors") return "scissors";

        //Rock beat paper
        if (enemy  == "paper" && player == "rock") return "paper";
        if (player == "paper" && enemy  == "rock") return "paper";

        return null;
    }
}
