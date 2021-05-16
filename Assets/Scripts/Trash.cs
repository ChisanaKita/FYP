using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRF.Driver;

public class Trash : MonoBehaviour
{
    public Rigidbody GrabbingBody;

    private GameObject Bait;
    private bool IsPlayerGrabed;

    private void Awake()
    {
        EntityDriver.Instance.OnPlayerGrabedTrash += PlayerGrabed;
    }

    private void OnDestroy()
    {
        EntityDriver.Instance.OnPlayerGrabedTrash -= PlayerGrabed;
    }

    public void PlayerGrabed()
    {
        IsPlayerGrabed = true;
        Bait = null;
    }

    private void Start()
    {
        IsPlayerGrabed = false;
    }

    private void FixedUpdate()
    {
        if (Bait != null && !IsPlayerGrabed)
        {
            GrabbingBody.MovePosition(Bait.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsPlayerGrabed)
        {
            if (other.tag.Equals("Water"))
            {
                Destroy(gameObject.transform.root.gameObject, 1000);
            }
        } 
        else if (other.tag.Equals("Bait"))
        {
            Bait = other.gameObject;
        }
    }
}
