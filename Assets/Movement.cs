using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private GameObject target;

    void Start()
    {
        print("start");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = GetClickedObject();
                   }
        if (target!=null && target.Equals(gameObject))  //선택된게 나라면
        {
            MoveBacknForth(target);
        }
    }

    private GameObject GetClickedObject()
    {
        RaycastHit hit;
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (true == (Physics.Raycast(ray.origin, ray.direction * 12, out hit)))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }
    void MoveBacknForth(GameObject target)
    {
        print("3. 앞뒤 움직임 시작");

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            target.transform.Translate(Vector3.right*2);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            target.transform.Translate(Vector3.left*2);
        }

        print("4. 앞뒤 움직임 완료");
    }
}