using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class SandwichController : MonoBehaviour
    {
    /*
     TO DO:
        Obligatory GAMEPLAY
            >Game Over Screen
                >freeze model
            >sandwich police (can't run when watched by police)
        JUICE
            >Sandwich Model
            >Funny Background
            >Screams
        Polish
            >adjust difficulty curve for buildup
         */

    /// <summary>
    /// Sandwich Controller
    /// </summary>
    /// 
    /*when player "catches" sandwich (Z-coordinate matches player or reaches -10), sandwich is "eaten" (Reset) and a "new" sandwich is spawned (same sandwich, except reset) and difficulty increases (sandwich counter goes up, speed increases)
         */
    //note: sandwich #6 is attainable with extreme concentration, 6 will be the win condition

    public Text scoreText;

        float playerSpeed = 0.5F;
        float sandwichSpeed = 0.001f;
        int playerscore = 0;
        float difficulty = 1;
        public bool gameOver = false, gameWon = false;

    public GameObject[] gameOverScreen;
    [SerializeField]
    public GameObject[] winScreen; //Set in editor
        // Start is called before the first frame update
        void Start()
        {
        //if (this.gameObject.tag == "Player") { Debug.Log("I AM SANDVICH"); }
        updateScore();
    }

    void updateScore() {
        scoreText.text = "Sandwiches Eaten: " + playerscore.ToString();
    }
    void winner() {
        sandwichSpeed = 0;
        transform.Translate(0, 20, 0);
        Debug.Log("Game won");
        foreach (GameObject won in winScreen)
        {
            won.SetActive(true);
        }
    }
        void loser() {
            
            sandwichSpeed = 0;
            print("LOSER");
            gameOver = true;

        foreach (GameObject gameOver in gameOverScreen) {
            gameOver.SetActive(true); }
            //Destroy(gameObject);
        }

        // Update is called once per frame
        void Update()
        {
        if (Input.GetKeyDown("r")) { SceneManager.LoadScene("SampleScene"); }
        

            
            if (gameObject.transform.position.z >= 10)
            {//sandwich escapes from player,player loses
                loser();
            }

            if (gameOver == false && gameWon==false ){

            if (playerscore >= 5) { winner(); }
            //sandwich "runs" away from the player
            transform.Translate(0, 0, sandwichSpeed);
                //development tool: Insta-Lose
                if (Input.GetKeyDown("p")) {loser();}
                if (Input.GetKeyDown("w")) { winner();
                
            }
            

            if (Input.GetKeyDown("space"))
                {
                    transform.Translate(0, 0, -playerSpeed);
                }

                //Player Catches Sandwich
                if (gameObject.transform.position.z <= -10)
                {
                    //reset sandwich
                    playerscore++;
                updateScore();
                //vector because the engine demands it
                Vector3 TP = new Vector3(0, 0, 0);
                    transform.position = TP;
                    print(playerscore);
                    difficulty++;
                    sandwichSpeed *= (difficulty / 2);
                    print("Speed:" + sandwichSpeed);
                }

                }
            }
    }

