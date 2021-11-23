using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    [Header("Skilss")]
    public GameObject skillOne;
    public GameObject skillTwo;
    public GameObject skillThree;
    public GameObject skillFour;
    public GameObject skillFive;
    [Header("Objects")]
    public GameObject blacksmith;
    public GameObject blacksmith_kick;
    public GameObject fullMoonSword;
    public GameObject poisonSword;

    [Header("Sounds")]
    public AudioClip skillOneSound;
    public AudioClip skillTwoSound;
    public AudioClip skillThreeSound;
    public AudioClip skillFourSound;
    public AudioClip skillFiveSound;

    
    bool clicked = false;
    public float waitTime = 3f;
    AnimationClip ninjaAnim;
    AudioSource mySounds;

    private void Start()
    {
        mySounds = GetComponent<AudioSource>();
    }

    public void skillOneButton()
    {  
       skillSystem(skillOne, skillOneSound,fullMoonSword,blacksmith);           
    }
    public void skillTwoButton()
    {
       skillSystem(skillTwo, skillTwoSound,null,null);                           
    }
    public void skillThreeButton()
    {               
       skillSystem(skillThree, skillThreeSound,null,null);           
    }

    public void skillFourButton()
    {      
       skillSystem(skillFour, skillFourSound,poisonSword,blacksmith);
    }

    public void skillFiveButton()
    {
        if (clicked == false )
        {
            mySounds.PlayOneShot(skillFiveSound, 1f);
            skillFive.SetActive(true);
            var timeChange = waitTime;
            timeChange = 5f;
            StartCoroutine(wait_Until(skillFive, timeChange));
            clicked = true;
        }
    }

    IEnumerator wait_Until(GameObject skill,float wait_Time)
    {
        
        yield return new WaitForSeconds(wait_Time);
        skill.SetActive(false);
        blacksmith.SetActive(true);
        clicked = false;
        blacksmith.GetComponent<SpriteRenderer>().color = Color.white;
        blacksmith_kick.SetActive(false);
        fullMoonSword.SetActive(false);
        poisonSword.SetActive(false);

    }
    void skillSystem(GameObject skill, AudioClip skillSound, GameObject a,GameObject b)
    {
        if(clicked == false)
        {
            if (a != null && b != null) { a.SetActive(true); b.SetActive(false); }

            mySounds.PlayOneShot(skillSound, 1f);
            skill.SetActive(true);
            StartCoroutine(wait_Until(skill, waitTime));
            clicked = true;
        }
        
    }
    private void Update()
    {
        if (skillTwo.transform.position.x == 3.05f)
            blacksmith.GetComponent<SpriteRenderer>().color = Color.green;
        if (skillThree.transform.position.x == 2.85f)
        {
            blacksmith.SetActive(false);
            blacksmith_kick.SetActive(true);
        }
    }

}
