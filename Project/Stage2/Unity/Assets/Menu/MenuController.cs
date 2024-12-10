using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] Animator _playText;
    [SerializeField] Animator _optionsText;

    bool _isPlaying = true;

    // Start is called before the first frame update
    void Start()
    {
        _playText.SetBool("isPlay", _isPlaying);
        _optionsText.SetBool("isOptions", !_isPlaying);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            _isPlaying = !_isPlaying;
            _playText.SetBool("isPlay", _isPlaying);
            _optionsText.SetBool("isOptions", !_isPlaying);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            _isPlaying = true;
            _playText.SetBool("isPlay", _isPlaying);
            _optionsText.SetBool("isOptions", !_isPlaying);
        }

        if (_isPlaying && Input.GetKeyDown(KeyCode.Return)) 
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
