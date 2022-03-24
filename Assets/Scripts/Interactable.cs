using UnityEngine;

public class Interactable : MonoBehaviour
{
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LeftMouseInteract();
        }

        if(Input.GetMouseButtonDown(1))
        {
            RightMouseInteract();
        }
    }
    private void OnMouseEnter() {
        MouseEnterInteract();
    }

    public virtual void MouseEnterInteract(){
        
        Debug.Log("this is mouse enter interaction with" + gameObject.name);
        //overwrite this method for each object behaviour
    }

    public virtual void LeftMouseInteract()
    {
        Debug.Log("this is left mouse interaction with" + gameObject.name);
        //overwrite this method for each object behaviour
    }
    public virtual void RightMouseInteract()
    {
        Debug.Log("this is right mouse interaction with" + gameObject.name);
        //overwrite this method for each object behaviour
    }
}
