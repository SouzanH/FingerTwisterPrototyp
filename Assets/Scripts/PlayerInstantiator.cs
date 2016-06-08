using UnityEngine;
using System.Collections;

public class PlayerInstantiator : MonoBehaviour
{

	public static Color[] Colors = { new Color(0.85F, 0.36F, 0.59F), new Color(0.17F, 0.62F, 0.87F), new Color(0.0F, 0.88F, 0.78F), new Color(0.96F, 0.93F, 0.64F) };
	public static Color[] PointColors = { new Color(0.85F, 0.07F, 0.59F), new Color(0.0F, 0.1F, 0.78F), new Color(0.0F, 0.88F, 0.78F), new Color(0.96F, 0.87F, 0.1F) };

    public static GameObject[] InstantiateStarts(GameObject startPrefab, Material materialPrefab, int count, GameController gameController)
    {
        var starts = new GameObject[count];
        for (int i = 0; i < count; i++)
            starts[i] = InstantiateStart(startPrefab, materialPrefab, i, gameController);
        return starts;
    }

    private static GameObject InstantiateStart(GameObject startPrefab, Material materialPrefab, int number, GameController gameController)
    {
        var startObject = (GameObject) Instantiate(startPrefab, GetPlayerPosition(number, gameController), Quaternion.identity);
        startObject.GetComponent<MeshRenderer>().material = InstantiateMaterial(materialPrefab, number);
        StartController startController = startObject.GetComponent<StartController>();
        startController.PlayerNumber = number;
        startController.MainGameController = gameController;
        return startObject;
    }
    
    private static Material InstantiateMaterial(Material materialPrefab, int number)
    {
        var startMaterial = Instantiate<Material>(materialPrefab);
        startMaterial.color = Colors[number];
        return startMaterial;
    }
    
    private static Vector3 GetPlayerPosition(int number, GameController gameController)
    {
        number %= 4;
        float x = 0;
        float z = 0;
        switch (number) {
        case 0:
            x = gameController.GetRandomX();
            z = gameController.HalfFrustumHeight;
            break;
        case 1:
            x = gameController.GetRandomX();
            z = -gameController.HalfFrustumHeight;
            break;
        case 2:
            x = gameController.HalfFrustumWidht;
            z = gameController.GetRandomZ();
            break;
        case 3:
            x = -gameController.HalfFrustumWidht;
            z = gameController.GetRandomZ();
            break;
        }
        return new Vector3(x, 0, z);
    }
}
