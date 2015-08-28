using UnityEngine;
using System.Collections;
using System.Reflection;
public class Abc
{
	[Attr_moon()]
	public string Moon()
	{
		return "5678";
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
	static string TypeName_int =  int.MaxValue.GetType().Name;
	static string TypeName_float = float.MaxValue.GetType().Name;
	static string TypeName_string = string.Empty.GetType().Name;
	static public void InitTypeName()
	{

	}

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

		object currentObject = null;
		bool isSuccess = false;
		for(int i = 1; i < typeNamesLength; ++i)
		{  
			if(type == null)
			{
				return false;
			}

			MethodInfo mInfo = type.GetMethod(typeNames[i], BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
			if(mInfo == null)
			{
				Debug.LogError("Error NoFound Method => " + fullName);
				return false;
			}

			currentObject = mInfo.Invoke(currentObject, null);
			if(currentObject == null)
			{
				Debug.LogError("Error NoFound Method => " + fullName);
				return false;
			}

			if(i == typeNamesLength-1)
			{ 
				Debug.Log(currentObject.GetType().Name);
				if(currentObject.GetType().Name == TypeName_int)
				{
					outValue = (int)currentObject;
					isSuccess = true;
				}
				else if(currentObject.GetType().Name == TypeName_float)
				{
					outValue = (int)((float)currentObject);
					isSuccess = true;
				}
				else if(currentObject.GetType().Name == TypeName_string)
				{   
					if(int.TryParse(((string)currentObject), out outValue) == true)
					{
						isSuccess = true;
					}
					else
					{
						Debug.LogError("Error if(int.TryParse(((string)currentObject), out outValue) == true) NoFound Method => " + fullName);
					} 
				}
			}
			else
			{
				type = currentObject.GetType();
			} 
		}
		return isSuccess;
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
		int value = 0;
		ExposebleMethod.InitTypeName();
		if(ExposebleMethod.GetInt("Exposeble/get_Ex/Moon", ref value))
		{
			Debug.Log("Success =>" + value);
		}
		else
		{
			Debug.Log("Fail@@@");
		}
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
