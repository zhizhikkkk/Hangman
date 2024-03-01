using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WonLoseManager : MonoBehaviour
{
    public static int Level = 0;
    public GameObject winPanel;
    public GameObject losePanel;
    public WordsManager wordsManager;
    private List<LetterChanges> letterChangesSubscribers = new List<LetterChanges>();
    public static int LoseCount = 0;
    public  Image hangman;
    public  List<Sprite> hangmanSprites = new List<Sprite>();

    public void Subscribe(LetterChanges subscriber)
    {
        if (!letterChangesSubscribers.Contains(subscriber))
        {
            letterChangesSubscribers.Add(subscriber);
        }
    }

    public void Unsubscribe(LetterChanges subscriber)
    {
        if (letterChangesSubscribers.Contains(subscriber))
        {
            letterChangesSubscribers.Remove(subscriber);
        }
    }
    public void Win()
    {
        winPanel.SetActive(true);
        Level++;
    }
    public void Lose()
    {
        losePanel.SetActive(true);
    }

    public void StartGame()
    {
        LoseCount = 0;
        hangman.sprite = null;
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        wordsManager.AwakeGame();

        foreach (var subscriber in letterChangesSubscribers)
        {
            subscriber.state = State.NotChosen;
            subscriber.UpdateColor();
        }
    }
    public  void UpdateHangmanSprite()
    {
        hangman.sprite = hangmanSprites[LoseCount];
        if (LoseCount == 7)
        {
            Lose();
        }
    }
}
