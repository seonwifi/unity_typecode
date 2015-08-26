using UnityEngine;
using System.Collections;
using System.Reflection;
public class Abc
{
	[Attr_moon()]
	public void Moon()
	{
		
	}
	static public void Moon_static()
	{
		
	}
}
public class Attr_moon : System.Attribute
{
	
	public Attr_moon()
	{
		
	} 
}
 

public class Exposeble
{
	static Abc a = new Abc();
	[Attr_moon()]
	public static Abc Ex
	{
		get
		{
			return a;
		} 
	}
}

public class test : MonoBehaviour 
{
	public Transform target;
	public float speed;

	//		Default = 0,
	//		IgnoreCase = 1,
	//		DeclaredOnly = 2,
	//		Instance = 4,
	//		Static = 8,
	//		Public = 16,
	//		NonPublic = 32,
	//		FlattenHierarchy = 64,
	//		InvokeMethod = 256,
	//		CreateInstance = 512,
	//		GetField = 1024,
	//		SetField = 2048,
	//		GetProperty = 4096,
	//		SetProperty = 8192,
	//		PutDispProperty = 16384,
	//		PutRefDispProperty = 32768,
	//		ExactBinding = 65536,
	//		SuppressChangeType = 131072,
	//		OptionalParamBinding = 262144,
	//		IgnoreReturn = 16777216

	void Start() 
	{
		Abc a = new Abc();
		System.Type t = System.Type.GetType("Abc");
		MethodInfo mm = t.GetMethod("Moon");
		MethodInfo[] methodInfo = t.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
		//methodInfo[0].
		object [] aaaa = mm.GetCustomAttributes(true);
	


		System.Type TExposeble = System.Type.GetType("Exposeble");

		MethodInfo[] TExposebleMethodInfo = TExposeble.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
		//MethodInfo []methodInfoTExposeble = TExposeble.GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
		

	}

	void Update() 
	{
//		Vector3 targetDir = target.position - transform.position;
//		float step = speed * Time.deltaTime;
//		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
//		Debug.DrawRay(transform.position, newDir, Color.red);
//		transform.rotation = Quaternion.LookRotation(newDir) * Quaternion.Euler(0,0, 30);
//

	}
	 
}
