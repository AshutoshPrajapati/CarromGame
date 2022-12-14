using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    //Collision For Goal
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Red" || collision.gameObject.tag == "black" || collision.gameObject.tag == "White")
        {
            Destroy(collision.gameObject);
            if (collision.gameObject.tag == "black")
            {
                UIManager.instance.blackScore += 5;
                UIManager.instance.blackCoin.text = UIManager.instance.blackScore.ToString();
            }
            else if (collision.gameObject.tag == "White")
            {
                UIManager.instance.whiteScore += 10;
                UIManager.instance.whiteCoin.text = UIManager.instance.whiteScore.ToString();
            }
            else if (collision.gameObject.tag == "Red")
            {
                UIManager.instance.redScore += 50;
                UIManager.instance.redCoin.text = UIManager.instance.redScore.ToString();
            }
        }


    }
}