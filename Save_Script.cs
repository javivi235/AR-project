using UnityEngine;
using System.IO;


class MyClass
{
    [RuntimeInitializeOnLoadMethod]
	 static void OnRuntimeMethodLoad()
    {
		
     GameObject[] c =   GameObject.FindGameObjectsWithTag("Obj");  
	Debug.Log(c.Length);
	string path = "Assets/Resources/save.txt";	
	if(System.IO.File.Exists(path))
        {
		 System.IO.File.Delete(path);
	}
	StreamWriter writer = new StreamWriter(path, true);

        
	foreach(GameObject go in c) {
	
	writer.WriteLine(go.transform.name + "|" + go.transform.position.x + "|" + go.transform.position.y + "|" +
	go.transform.position.z + "|" + go.transform.rotation.eulerAngles.x + "|" + go.transform.rotation.eulerAngles.y + "|" + go.transform.rotation.eulerAngles.z + "|" +
	go.transform.lossyScale.x + "|" + go.transform.lossyScale.y + "|" + go.transform.lossyScale.z + "\n");
	
		
	}
	writer.Close();
	
    }

}