using UnityEngine;
using System.Collections;

public interface Portal {

    void OnTriggerEnter2D(Collider2D player);
    void OnTriggerExit2D(Collider2D player);
}
