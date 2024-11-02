using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform player;

    private UnityEngine.AI.NavMeshAgent agent;

    public int HP = 100;

    private bool canAttack = true;

    public float delay = 0;

    // Положение точки назначения
    public Transform goal;

    private void Start()
    {
        agent
            = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        delay -= Time.deltaTime;
        // Получение компонента агента

        // Указаие точки назначения
        agent.destination = player.position;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && Math.Abs(delay) >= 2 && !GameObject.Find("GameManager").GetComponent<GameManager>().haveUnreal)
        {
            delay = 0;
            OpenScene.OpenSceneVoid(GameObject.FindGameObjectWithTag("Player").GetComponent<Building>().indexScene);
Debug.Log("DAMAGEEE");
        }
    }



    private void OnCollisionExit(Collision other)
    {
        
    }



}