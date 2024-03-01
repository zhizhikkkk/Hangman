using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordsManager : MonoBehaviour
{
    public List<string> Words = new List<string>() { "bakhtiyar", "cola", "pepsi", "bakha", "seksi" };
    public TextMeshProUGUI chosenWordTxt;
    private string closedWord;
    private List<int> openIndexes = new List<int>();
    public WonLoseManager wonLoseManager;
    void Awake()
    {
        AwakeGame();
    }
    public void AwakeGame()
    {
        closedWord = "";
        openIndexes= new List<int>();
        LetterChanges.chosenWord = Words[WonLoseManager.Level];
        for (int i = 0; i < LetterChanges.chosenWord.Length; i++)
        {
            closedWord += "*";
        }
        chosenWordTxt.text = closedWord;
    }

    public void OpenLetter(int index)
    {
        int cntOfClosedLetters = 0;
        openIndexes.Add(index);
        closedWord = "";
        for (int i = 0; i < LetterChanges.chosenWord.Length; i++)
        {
            if (openIndexes.Contains(i))
            {

                closedWord += LetterChanges.chosenWord[i];
            }
            else
            {
                closedWord += "*";
                cntOfClosedLetters++;
            }
        }
        chosenWordTxt.text = closedWord;
        if (cntOfClosedLetters == 0)
        {
            wonLoseManager.Win();
        }
    }
}
