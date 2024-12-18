using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FloatingHealthbar : MonoBehaviour
{
   [SerializeField] private Slider slider;
   [SerializeField] private Camera camera;
   [SerializeField] private Transform target;
  [SerializeField] private Vector3 offset;

  private void Start()
  {
    camera = Camera.main;
  }
   public void UpdateHealthBar(float currentValue, float maxValue)
   {
     slider.value = currentValue / maxValue;
   }
    void Update()
    {
        transform.rotation = camera.transform.rotation;
        transform.position = target.position + offset;
    }
}
