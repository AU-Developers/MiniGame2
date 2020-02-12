using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Chickens
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] Text _score;
        [SerializeField] Text _timeLimit;
        [SerializeField] Text _textInMiddle;

        float timer = 60;

        // Start is called before the first frame update
        void Start()    
        {
            StartCoroutine(CounterToStart());
        }

        // Update is called once per frame
        void Update()
        {
            
            if (GamePlayManager.Instance._Model._timer % 60 >= 10)
            {
                _timeLimit.text = (int)(GamePlayManager.Instance._Model._timer / 60) + ":" + (int)(GamePlayManager.Instance._Model._timer % 60);
            }
            else
            {
                _timeLimit.text = (int)(GamePlayManager.Instance._Model._timer / 60) + ":0" + (int)(GamePlayManager.Instance._Model._timer % 60);
            }

            if(GamePlayManager.Instance._gameStart)
                GamePlayManager.Instance._Model._timer -= Time.deltaTime;

            _score.text = "Score: "+GamePlayManager.Instance._Model._points;
        }

        IEnumerator CounterToStart()
        {
            int counter = 3;
            while (counter > 0)
            {
                _textInMiddle.gameObject.SetActive(true);
                _textInMiddle.text = "Get Ready " + counter;
                yield return new WaitForSeconds(1);
                _textInMiddle.gameObject.SetActive(false);
                counter--;
            }

            if (counter == 0)
                GamePlayManager.Instance._gameStart = true;
        }
    }
}
