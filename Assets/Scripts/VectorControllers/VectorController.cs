using UnityEngine;
using System.Collections;

public abstract class VectorController : MonoBehaviour {

	//
	// Vector behaviour
	// Should be put on the cylinder with cone on the top
	//
	
	public SimulationController simulationController;
	public GameObject cone;
	public float scale = 1.0f;
	
	public bool isShowed {
		get { return _isShowed; }
		set { _isShowed = value; }
	}

    public void SwitchIsShowed() {
        _isShowed = !_isShowed;
    }
	
	private bool _isShowed;
	
	public void Update () {
		
		if (!_isShowed || Utilities.isZero(simulationController.currentData.velocityVector.magnitude)) {
			GetComponent<Renderer>().enabled = false;
			cone.GetComponent<Renderer>().enabled = false;
		} else {
			GetComponent<Renderer>().enabled = true;
			cone.GetComponent<Renderer>().enabled = true;
		}

		transformVector();
	}

	public abstract void transformVector();
}
