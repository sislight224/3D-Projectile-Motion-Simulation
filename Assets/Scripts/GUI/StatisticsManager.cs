using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatisticsManager : MonoBehaviour {

    public InputField timeInput;
    public InputField deltaTimeInput;
    public InputField xPosInput;
    public InputField yPosInput;
    public InputField angleInput;
    public InputField velocityInput;
    public InputField velocityXInput;
    public InputField velocityYInput;
    public InputField maxYInput;
    public InputField maxYTimeInput;

    public SimulationController simulationController;

    private ProjectileMotionData _data;

    public void OnEnable() {
        SimulationController.OnSimulationReset += UpdateStats;
        ProjectileMotion.OnNextStep += UpdateStats;
    }

    public void OnDisable() {
        SimulationController.OnSimulationReset -= UpdateStats;
        ProjectileMotion.OnNextStep -= UpdateStats;
    }

    public void UpdateStats() {
        _data = simulationController.currentData;
        if (_data == null) {
            Debug.LogError("StatisticsManager: _data is null");
            return;
        }
        timeInput.text = Utilities.Round(_data.time);
        deltaTimeInput.text = Utilities.Round(_data.deltaTime);
        xPosInput.text = Utilities.Round(_data.xPos);
        yPosInput.text = Utilities.Round(_data.yPos);
        angleInput.text = Utilities.Round(_data.velocityVector.angle);
        velocityInput.text = Utilities.Round(_data.velocityVector.magnitude);
        velocityXInput.text = Utilities.Round(_data.velocityVector.horizontal);
        velocityYInput.text = Utilities.Round(_data.velocityVector.vertical);
        maxYInput.text = Utilities.Round(_data.maxY);
        maxYTimeInput.text = Utilities.Round(_data.maxYTime);
    }
}
