using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animObj : MonoBehaviour
{
    private Animation anim;
    public string anim_walk;
    public string anim_idle;
    public string anim_name;
    public int size;
    private int s = 1;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void animate_start()
    {
        anim.Play(anim_walk);
    }

    public void animate_stop()
    {
        anim.Play(anim_idle);
    }

    public void switch_anim()
    {
        s = (s + 1) % (size + 1); 
        if (s == 0) s++;
        string a = anim_name;
        if (s < 10) a += "0";
        a += s.ToString();
        anim.Play(a);
    }
}
