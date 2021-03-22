using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] private GameObject particlePrefab;
    [SerializeField] private int maxHits;
   
    [SerializeField] private Sprite[] hitsSprites;
    private int timesHit;//block number we hit
    Level level;
    
    
    GameStatus gameStatus;
    private void Start()
    {

        level = FindObjectOfType<Level>();//find level script object,and rotate that object
        gameStatus=FindObjectOfType<GameStatus>();
        Destroy(gameStatus.highScore);
        if (tag == "Breakable")
        {
            level.CountBreakableBlock();//level script method
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        AudioClipPlay();
        if (tag=="Breakable")
        {
            timesHit++;
            if (timesHit>=maxHits)//Destroy when exceeding the maximum number of hits
            {
                Score();
                DestroyBlock();
            }
            else
            {
               
                GetComponent<SpriteRenderer>().sprite = hitsSprites[timesHit-1];
                
            }
           
        }
        
    }
    private void DestroyBlock()
    {
        GameObject particle=Instantiate(particlePrefab, transform.position, transform.rotation);//product
        Destroy(particle, 1f);//1 second destroy
        Destroy(gameObject);
    }
    private void AudioClipPlay()
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }
    private void Score()
    {
        level.BlockDestroyed();
        gameStatus.AddToScore();
    }
}
