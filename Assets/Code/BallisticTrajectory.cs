using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))] //wymaga komponentu Linerenderer
public class BallisticTrajectory : MonoBehaviour //Klasa do rysowania trajektorii balistycznej
{
    LineRenderer _trajectoryRenderer;
    [SerializeField] float _maxDistance = 20; //maksymalna długość trajektorii
    [SerializeField] float _stepSize = 0.1f; //krok rysowania krzywej trajektorii

    private void Start()
    {
        _trajectoryRenderer = GetComponent<LineRenderer>(); //na start pobierz komponent do rysowania linii
    }

    public void DrawTrajectory(Vector3 startPosition, Vector3 direction, float velocityMagnitude) //rysuje trajektorię balistyczną z podanej pozycji i o podanym kierunku oraz sile
    {
        var curvePoints = new List<Vector3>();

        var currentPosition = startPosition;
        var currentVelocity = direction * velocityMagnitude;
        float timeStep = 0;

        RaycastHit hit;
        Ray obstructionCheck = new Ray();

        do
        {
            currentVelocity += timeStep * Physics.gravity;
            currentPosition += timeStep * currentVelocity;

            curvePoints.Add(currentPosition);

            obstructionCheck.direction = currentVelocity.normalized;
            obstructionCheck.origin = currentPosition;

            timeStep = _stepSize / currentVelocity.magnitude;
        } while (!Physics.Raycast(obstructionCheck, out hit, _stepSize) && Vector3.Distance(startPosition, currentPosition) < _maxDistance);

        if (hit.transform)
        {
            curvePoints.Add(hit.point);
        }

        _trajectoryRenderer.positionCount = curvePoints.Count;
        _trajectoryRenderer.SetPositions(curvePoints.ToArray());
    }

    public void ClearTrajectory()
    {
        _trajectoryRenderer.positionCount = 0;
    }
}
