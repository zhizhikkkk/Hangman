using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterChanges : MonoBehaviour
{
    public State state = State.NotChosen;
    public Image image;
    public static  string chosenWord;
    public WordsManager wordsManager;
    public WonLoseManager wonLoseManager;

    private void OnEnable()
    {
        wonLoseManager.Subscribe(this);
    }

    private void OnDisable()
    {
        wonLoseManager.Unsubscribe(this);
    }


    public void Start()
    {
        image = GetComponent<Image>();
    }
    public void UpdateColor()
    {
        if(state == State.NotChosen)
        {
            image.color = new Color(0.5943396f, 0.6274853f,1);
        }
        else if(state == State.Wrong)
        {
            image.color = Color.red;
        }
        else
        {
            image.color = Color.green;
        }
    }
    
    public void AddLetter(string letter)
    {
        if (state == State.NotChosen)
        {
            bool isContain = false;
            for (int i = 0; i < chosenWord.Length; i++)
            {
                Debug.Log(letter);
                if (chosenWord[i].ToString() == letter.ToLower())
                {

                    wordsManager.OpenLetter(i);
                    isContain = true;
                }
            }
            if (isContain)
            {
                state = State.Right;
            }
            else
            {
                state = State.Wrong;
                WonLoseManager.LoseCount++;
                wonLoseManager.UpdateHangmanSprite();
            }

            UpdateColor();
        }
    }
}
public enum State
{
    Wrong,
    Right,
    NotChosen
}
