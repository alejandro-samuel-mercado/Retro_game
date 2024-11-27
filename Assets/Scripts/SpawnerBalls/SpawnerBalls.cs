using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBalls : MonoBehaviour
{ 
    [SerializeField] private float velocidadY = -7f;  // Velocidad de ca�da
    [SerializeField] private float intervaloDeGeneracion = 3f;
   
    // Rango para la posici�n aleatoria en X
    [SerializeField] private float rangoMinX = -10f;
    [SerializeField] private float rangoMaxX = 10f;

    void Start()
    {
        InvokeRepeating(nameof(GenerarPelota), 0, intervaloDeGeneracion);
    }

    private void GenerarPelota()
    { if (BallPool.Instance != null)
        {
            // Generar una posici�n aleatoria en X dentro del rango especificado
            Vector3 posicionAleatoria = new Vector3(
                Random.Range(rangoMinX, rangoMaxX),
                transform.position.y,
                transform.position.z
            );

            GameObject ball = BallPool.Instance.GetBall(posicionAleatoria);  // Obtener una pelota del pool
            BallMover ballMover = ball.GetComponent<BallMover>();
            if (ballMover != null)
            {
                ballMover.Configurar(velocidadY);  // Configurar velocidad de ca�da
            }
        }
        else
        {
            Debug.LogError("BallPool.Instance es nulo. Aseg�rate de que BallPool est� en la escena.");
        }
    }
}
