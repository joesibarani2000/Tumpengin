using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScoring : MonoBehaviour
{
    public static FoodScoring Instance;

    private void Start()
    {
        Instance = this;
    }

    public int GetScorePerkedel (int total)
    {
        return ((int)(total / 2)) * 5 + (total % 2);
    }

    public int GetScoreSambal(int ayam, int ikan, int telur, int sambal)
    {
        int special = (ayam > 0 ? 1 : 0) + (ikan > 0 ? 1 : 0) + (telur > 0 ? 1 : 0);

        if (sambal > 0)
        {
            switch (special)
            {
                case 1:
                    return 1;
                case 2:
                    return 4;
                case 3:
                    return 7;
                default:
                    return 0;
            }
        }
        else return 0;
    }

    public int GetScoreLalapan(List<CharacterBehaviour> characters, CharacterBehaviour character)
    {
        CharacterBehaviour highest = character, lowest = character;
        int resultHigh = character.GetScore().lalapan;
        int resultLow = character.GetScore().lalapan;

        foreach (CharacterBehaviour data in characters)
        {
            if (resultHigh < data.GetScore().lalapan)
            {
                resultHigh = data.GetScore().lalapan;
                highest = data;
            }

            if (resultLow > data.GetScore().lalapan)
            {
                resultLow = data.GetScore().lalapan;
                lowest = data;
            }
        }

        if (highest == character) return 4;
        if (lowest == character) return -4;
        return 0;
    }

    public int GetScoreUrap(List<CharacterBehaviour> characters, CharacterBehaviour character)
    {
        CharacterBehaviour highest = character, lowest = character;
        int resultHigh = character.GetScore().urap;
        int resultLow = character.GetScore().urap;

        foreach (CharacterBehaviour data in characters)
        {
            if (resultHigh < data.GetScore().urap)
            {
                resultHigh = data.GetScore().urap;
                highest = data;
            }

            if (resultLow > data.GetScore().urap)
            {
                resultLow = data.GetScore().urap;
                lowest = data;
            }
        }

        if (highest == character) return 6;
        if (lowest == character) return -4;
        return 2;
    }

    public int GetScoreNasiKuning(int total)
    {
        switch (total)
        {
            case 0:
                return -2;
            case 1:
                return 4;
            case 2:
                return 6;
            default:
                return 4;
        }
    }

    public int GetScoreLauk(string name, int total)
    {
        switch (name)
        {
            case "Telur":
                return total * 1;
            case "Ayam":
                return total * 2;
            case "Ikan":
                return total * 3;
            default:
                return 0;
        }
    }

    public int GetScoreTelurIris(int total)
    {
        switch (total)
        {
            case 0:
                return 0;
            case 1:
                return 1;
            case 2:
                return 3;
            case 3:
                return 6;
            case 4:
                return 10;
            default:
                return 15;
        }
    }
}

[System.Serializable]
public class Score
{
    public int ayam, telur, nasiKuning, sambal, lalapan, urap, perkedel, ikan, telurIris;
}