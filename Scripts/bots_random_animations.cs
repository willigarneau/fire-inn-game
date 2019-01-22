using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bots_random_animations : MonoBehaviour
{
    private Animator[] m_bots;
    [SerializeField] private int m_nb_animations;

    // Start is called before the first frame update
    void Start()
    {
        m_bots = GetComponentsInChildren<Animator>();

        InvokeRepeating("Bot_Animation", 1f, 2f);  //1s delay, repeat every 1s
    }

    // Update is called once per frame
    void Update()
    {      

    }

    void Bot_Animation()
    {
        for (int i = 0; i < m_nb_animations; i++)
        {
            int index = Random.Range(0, m_bots.Length);

            // bot is doing no animation
            if (m_bots[index].GetCurrentAnimatorStateInfo(0).IsName("sit"))
            {
                //Debug.Log(index);
                //// cant implicitly convert int to bool.. fckn compiler             
                int action = Random.Range(0, 2);

                if (action == 0)
                {
                    m_bots[index].SetBool("Laught", true);
                }
                else if (action == 1)
                {
                    m_bots[index].SetBool("Talk", true);
                }
            }

        }
    }

}

