using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Movement
{
    [HideInInspector] public bool attackMode;
    [HideInInspector] public bool escapeMode;
    [HideInInspector] public bool attacking;
    protected Transform player;
    protected Animator animator;
    protected override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponentInChildren<Animator>();
    }
}
