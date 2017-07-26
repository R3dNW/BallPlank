using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour
{
    public Transform ballTransform;

    float score;

    public Text scoreText;
    
    void Update()
    {
        this.score = Mathf.Max(this.score, this.ballTransform.position.x);

        this.scoreText.text = string.Format("Your score is: {0}", Mathf.Max(Mathf.RoundToInt(this.score), 0));
    }
}
