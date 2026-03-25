//using System.Drawing;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public SpriteRenderer sr;
    //public Color powerUpColor;
    protected PlayerController player;
    private bool effectsApplied = false;
    public float effectDuration;
    private float timeElapsedSinceEffect;

    

    void Start()
    {
        player = GameObject.Find("player").GetComponent<PlayerController>();
        sr = GetComponent<SpriteRenderer>();
        


    }
    public virtual void ApplyEffect()
    {
        //Destroy(gameObject);
        sr.enabled = false;
        effectsApplied = true;
    }
    private void Update()
    {
        if (effectsApplied)
        {
            if (timeElapsedSinceEffect < effectDuration)
            {
                timeElapsedSinceEffect += Time.deltaTime;
            }
            else
            {
                timeElapsedSinceEffect = 0;
                NegateEffect();
                effectsApplied = false;
                Destroy(gameObject);
            }
        }

    }
    protected virtual void NegateEffect()
    {
        
    }
    
  
}
