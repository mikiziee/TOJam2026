using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class FootstepSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] footstepClips;
    public float stepInterval = 0.5f;
    private bool isWalking;

    public InputSystem_Actions controls;
    private InputAction move;

    private void Awake()
    {
        controls = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        move = controls.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    void Update()
    {

        // Check movement (standard Input example)
        Vector2 input = move.ReadValue<Vector2>();
        float moveMagnitude = new Vector3(input.x, 0, input.y).magnitude;

        if (moveMagnitude > 0.1f && !isWalking)
        {
            StartCoroutine(PlayFootsteps());
        }
        else if (moveMagnitude <= 0.1f)
        {
            isWalking = false;
            StopAllCoroutines();
        }

        //Debug.Log(input);
    }

    IEnumerator PlayFootsteps()
    {
        isWalking = true;
        while (isWalking)
        {
            // Pick a random sound for variety
            AudioClip clip = footstepClips[Random.Range(0, footstepClips.Length)];
            audioSource.PlayOneShot(clip);
            yield return new WaitForSeconds(stepInterval);
        }
    }
}
