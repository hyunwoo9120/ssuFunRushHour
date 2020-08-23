using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSound : MonoBehaviour
{
    int[] level = new int[4] { 1, 2, 3, 4 };
    static int stage = 1;
    Vector3 pos;
    public AudioSource endSound;
    bool playOnce = false;

    private void Start()
    {

        endSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (CheckDestination(playOnce))
        {
            endSound.Play();
            playOnce = true;
            Invoke("ChangeScene", 3);
        }
    }

    private bool CheckDestination(bool playOnce)
    {
        if (playOnce) return false;
        pos = this.gameObject.transform.position;
        if ((pos.x >= -1.1 && pos.x <= -0.9) && (pos.z >= 5.9 && pos.z <= 8.1))
        {
            print("도착");
            return true;
        }
        else return false;
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("Level" + level[stage++]);
        if (stage == 5) { EndGame(); }
    }

    private void EndGame() {
        Application.Quit();
    }
}
