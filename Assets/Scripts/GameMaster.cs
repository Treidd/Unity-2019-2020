using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMaster : MonoBehaviour
{
    public IEnumerator ResetScene(int index, int tiempo) {
        yield return new WaitForSeconds(tiempo);
        SceneManager.LoadScene(index);
    }
    public void PlayAudio() {
        GetComponent<AudioSource>().Play();
    }
}
