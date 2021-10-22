using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EyeTest
{
    // A Test behaves as an ordinary method
    private GameObject eye;
    private GameObject inputManager;
    [SetUp]
    public void Setup()
    {
        eye = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Eye"));
        inputManager = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(eye);
        Object.Destroy(inputManager);
    }
    
    [UnityTest]
    public IEnumerator EyeTestWithEnumeratorPasses()
    {
        Transform target = inputManager.transform.GetChild(0);
        var position = target.position;
        position= new Vector3(position.x+3,position.y);
        target.position = position;
        yield return new WaitForSeconds(0.1f);
        Vector2 center=eye.transform.Find("Iris").GetComponent<SpriteRenderer>().bounds.center;
        Vector2 pupil = eye.transform.Find("Pupil").position;
        var eyeDir = pupil - center;
        var targetDir = (Vector2)position - center;
        eyeDir.Normalize();
        targetDir.Normalize();
        bool result=false;
        if (eyeDir == targetDir)
            result = true;
        Assert.IsTrue(result);
    }
}
