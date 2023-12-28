using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [Header("Dependencies")]
    [SerializeField] private Rigidbody _cubeRigidbody;
    [SerializeField] private TextMeshProUGUI _pointsText;
    [SerializeField] private GameObject _initialText;
    [SerializeField] private GameObject _lostGameText;

    [Header("Values")] 
    [SerializeField] private float _jumpForce;
    private bool isPlaying;
    private int points;
    
    public void Start()
    {
        Time.timeScale = 0f;
    }

    public void PlayerJump(InputAction.CallbackContext value)
    {
        if (isPlaying)
        {
            _cubeRigidbody.velocity = Vector3.up * _jumpForce;
        } else {
            isPlaying = true;
            _initialText.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void RestartGame(InputAction.CallbackContext value)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void OnCollisionEnter(Collision other)
    {
        Time.timeScale = 0f;
        _lostGameText.SetActive(true);
    }

    public void AddPlayerPoints()
    {
        points++;
        _pointsText.text = points.ToString();
    }
}
