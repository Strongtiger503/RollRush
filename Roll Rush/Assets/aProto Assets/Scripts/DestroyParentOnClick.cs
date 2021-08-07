using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParentOnClick : MonoBehaviour
{

    #region Main 

    private void OnMouseDown()
    {
        Destroy(transform.parent.gameObject);
    }

    #endregion

}
