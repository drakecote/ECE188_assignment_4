using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Oculus.Interaction.Samples
{
    public class GestureDetection : MonoBehaviour
    {

        [SerializeField] private ActiveStateSelector thumbup;
        [SerializeField] private ActiveStateSelector thumbdown;
        [SerializeField] private GameObject cube;
        private bool isthumbup = false;
        private bool isthumbdown = false;

        private Vector3 scaleChange = new Vector3(0.01f, 0.01f, 0.01f);
        // Start is called before the first frame update
        void Start()
        {
            
            thumbup.WhenSelected += () => {isthumbup = true;};
            thumbup.WhenUnselected += () => {isthumbup = false;};
            thumbdown.WhenSelected += () => {isthumbdown = true;};
            thumbdown.WhenUnselected += () => {isthumbdown = false;};
        }

        private void Sizeup(){
            cube.transform.localScale += scaleChange;
            Debug.Log("thumb up detected"); 
        }
        private void Sizedown(){
            if (cube.transform.localScale.y > 0){
                cube.transform.localScale -= scaleChange;
                Debug.Log("thumb down detected"); 
            }
            
            Debug.Log("thumb down detected but I am too small to shrink :("); 
            
        }
        
        void Update(){
            // Debug.Log(isthumbup);
            if(isthumbup) Sizeup();
            if(isthumbdown) Sizedown();

        }
    }
}

