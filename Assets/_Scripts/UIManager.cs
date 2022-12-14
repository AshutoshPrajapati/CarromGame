using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;  // Create instance of the class
    public Text blackCoin;
    public Text whiteCoin;
    public Text redCoin;
    public Text total;
    public int blackScore=0;
    public int whiteScore=0;
    public int redScore=0;
    public int totalScore=0;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
    private void Update()
    {
        TotalCoin();
    }
    // Function for Count Total Coin 
    public void TotalCoin()   
    {
        totalScore = blackScore + whiteScore + redScore;
        total.text = totalScore.ToString();
    }
}
