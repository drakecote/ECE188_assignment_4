using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.Input;
// using TMPro;

public class TouchDetection : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private Transform fingertip;
    [SerializeField] AudioSource buttonup;
    [SerializeField] AudioSource buttondown;
    private float distance = Mathf.Infinity;
    private float touch_threshold;
    [SerializeField] private float distance_threshold = 0.05f;
    private bool isEnter = false;
    private bool isExit = false;
    private bool isHit = false;
    private bool wasHit = false;

    // Update is called once per frame
    void Update()
    {
        touch_threshold = distance_threshold + 0.5f*cube.transform.localScale.y;
        distance = DistanceCalculator(cube,fingertip);
        isHit = (distance < touch_threshold); //false if in the proximity
        isEnter = isHit && !wasHit;
        isExit = !isHit && wasHit;

        if (isEnter){
            buttonup.Play();
        }
        Debug.Log(isExit);
        Debug.Log(distance);
        if (isExit){
            buttonup.Play();
            ChangeColor(cube);
        }
        wasHit = isHit;
    }

    private void ChangeColor(GameObject cube){
        //Get the Renderer component from the new cube
        var cubeRenderer = cube.GetComponent<Renderer>();
        //Call SetColor using the shader property name "_Color" and setting the color randomly
        Color newColor = new Color( Random.value, Random.value, Random.value, 1.0f);
        cubeRenderer.material.SetColor("_Color", newColor);
    }

    // Calculate distance between two GameObjects
    private float DistanceCalculator(GameObject target, Transform fingertip)
    {
        float distance = 0;
        distance = Vector3.Distance(target.transform.position,fingertip.position);
        return distance;
    }
}
