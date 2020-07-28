using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirAnim : MonoBehaviour
{
    [Header("Sprites")]
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    [Header("Components")]
    public SpriteRenderer spriteRend;
    public Transform par;
    public Animator anim;

    [Header("Calculations")]
    public float headingAngle;
    public Vector3 prevLoc;
    enum Directions {down,left,right,up};

    // Start is called before the first frame update
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        prevLoc = transform.position;
        //par = GetComponentInParent<Transform>();
    }

    

    // Update is called once per frame
    void Update()
    {

        Vector3 curVel = (transform.position - prevLoc) / Time.deltaTime;
        float mag = (curVel.x * curVel.x) + (curVel.z * curVel.z);
        prevLoc = transform.position;
        anim.SetFloat("Velocity", mag);

        Vector3 forward = par.forward;
        forward.y = 0;
        headingAngle = Quaternion.LookRotation(forward).eulerAngles.y;

        if (!(mag <= .1 && mag >= -.1))
        {
            //Debug.Log("MOVING " + mag);
            anim.enabled = true;

            
            if ((headingAngle <= 45) || (headingAngle >= 315))
            {
                anim.SetInteger("Direction", (int)Directions.down);
            }
            else if ((headingAngle >= 45) && (headingAngle <= 135))
            {
                anim.SetInteger("Direction", (int)Directions.left);
            }
            else if ((headingAngle <= 315) && (headingAngle >= 225))
            {
                anim.SetInteger("Direction", (int)Directions.right);
            }
            else
            {
                anim.SetInteger("Direction", (int)Directions.up);
            }

        }
        else
        {
            anim.enabled = false;
            //Debug.Log("Still");
            if ((headingAngle <= 45) || (headingAngle >= 315))
            {
                spriteRend.sprite = downSprite;
            }
            else if ((headingAngle >= 45) && (headingAngle <= 135))
            {
                spriteRend.sprite = leftSprite;
            }
            else if ((headingAngle <= 315) && (headingAngle >= 225))
            {
                spriteRend.sprite = rightSprite;
            }
            else
            {
                spriteRend.sprite = upSprite;
            }
        }
        


        //

        

        

    }
    
}
