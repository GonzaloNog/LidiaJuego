using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Characters;

public class Goblin : NPC
{

    public override void Talk()
    {
        base.Talk();

        string randomPhrase = GetRandomPhrase();
        Debug.Log(randomPhrase);

        if (phrases == null || phrases.Count == 0)
        {
            phrases = new List<string>
            {
                "Greetings!",
                "Welcome!",
                "Be careful out there!"
            };
        }
    }

    private string GetRandomPhrase()
    {
        int randomIntex = Random.Range(0, phrases.Count);
        return phrases[randomIntex];
    }
}


