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
public class ExposebleMethod
{
	static public bool GetInt(string fullName, ref int outValue)
	{
		string []typeNames = fullName.Split(new char[]{'/'}); 
		int typeNamesLength = typeNames.Length;
		if(typeNamesLength == 0)
		{
			Debug.LogError("NoFound Data => " + fullName);
			return false;
		}
		System.Type type = System.Type.GetType(typeNames[0]);
		if(type == null)
		{
			Debug.LogError("NoFound Data => " + fullName);
			return false;
		}

		bool returnValue = false;
		for(int i = 1; i < typeNamesLength; ++i)
		{ 
			MethodInfo mInfo = type.GetMethod(typeNames[i]);
			if(i == typeNamesLength-1)
			{
				object value = mInfo.Invoke(null, null);
				if(value != null)
				{
					if(value.GetType().Name == "int")
					{
						outValue = (int)value;
					}
					if(value.GetType().Name == "float")
					{
						outValue = (int)((float)value);
					}
					if(value.GetType().Name == "string")
					{
						string value as string;

						outValue = (int)((float)value);
					}
				} 
			}
		}
		return returnValue;
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
