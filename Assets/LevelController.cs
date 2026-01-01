using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public List<Wood> layer1;
    public List<Wood> layer2;
    public List<Wood> layer3;

    public List<GameObject> screw;
    
    [SerializeField] private BoxCollider2D _myTriggerCollider;

    [SerializeField] private GameObject _vfx;

    private int countWood;

    public void Start()
    {
        countWood = layer1.Count + layer2.Count + layer3.Count;
        LevelSetupAsync().Forget();
    }
    
    private async UniTaskVoid LevelSetupAsync()
    {
        if (layer1.Count != 0)
        {
            foreach (var wood in layer1)
            {
                wood.gameObject.SetActive(true);
            }
            await UniTask.Delay(350);
        }
        if (layer2.Count != 0)
        {
            foreach (var wood in layer2)
            {
                wood.gameObject.SetActive(true);
            }
            await UniTask.Delay(350);
        }
        if (layer3.Count != 0)
        {
            foreach (var wood in layer3)
            {
                wood.gameObject.SetActive(true);
            }
            await UniTask.Delay(350);
        }
        foreach (var obj in screw)
        {
            obj.SetActive(true);
        }
        
        if (layer1.Count != 0)
        {
            foreach (var wood in layer1)
            {
                wood.AddCollider();
            }
        }
        if (layer2.Count != 0)
        {
            foreach (var wood in layer2)
            {
                wood.AddCollider();
            }
        }
        if (layer3.Count != 0)
        {
            foreach (var wood in layer3)
            {
                wood.AddCollider();
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Wood"))
        {
            countWood -= 1;
            Vector2 otherPosition = other.transform.position;
        
            Vector2 exitPoint = _myTriggerCollider.ClosestPoint(otherPosition);

            Instantiate(_vfx, exitPoint, Quaternion.identity);
            
            if(countWood == 0) Debug.Log("hi");
        }
    }
}
