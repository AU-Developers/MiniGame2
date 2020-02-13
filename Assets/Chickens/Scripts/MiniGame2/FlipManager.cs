using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Chickens
{
    public class FlipManager : MonoBehaviour
    {
        [SerializeField] int _coins;
        [SerializeField] GameObject _coinObject;
        public int Coins { get { return _coins; } }

        int heads, tails;

        // Start is called before the first frame update
        void Start()
        {
            //Instantiate(Coins, transform.position);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void FlipCoins()
        {
            for (int x = 0; x < Coins; x++)
            {
                if (Random.value < .10f)
                {
                    heads++;
                }
                else
                {
                    tails++;
                }
            }

            print("Heads: " + heads + " Tails: " + tails);

            heads = 0;
            tails = 0;
        }
    }
}
