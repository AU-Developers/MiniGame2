using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Chickens
{
    public class NetController : MonoBehaviour
    {
        public float speed;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Controller();
        }

        void Controller()
        {
            if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -6.5f)
                transform.Translate(Vector2.left * Time.deltaTime * speed);
            else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 6.5f)
                transform.Translate(Vector2.right * Time.deltaTime * speed);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Chicken")
            {
                collision.gameObject.SetActive(false);
            }

            if (collision.gameObject.tag == "Hazard")
            {
                collision.gameObject.SetActive(false);
            }
        }
    }
}

