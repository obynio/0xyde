﻿using UnityEngine;
using System.Collections;

public class ColliderPlay : MonoBehaviour {

    public AudioClip dialogueClip;
    private bool onWait = true;

    void OnTriggerEnter(Collider c)
    {
        if (onWait && c.tag == "Player")
        {
            OsdManager.Instance.BeginDialogue(dialogueClip, "fr");
            onWait = false;
        }
    }
}
