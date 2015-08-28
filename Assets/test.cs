using UnityEngine;
using System.Collections;
using System.Reflection;
using System;

public class Abc
{
	[Attr_moon()]
	public float Moon()
	{
		//return "5678";
		return 5.2135f;
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

	static string TypeName_int 		= int.MaxValue.GetType().Name;
	static string TypeName_long 	= long.MaxValue.GetType().Name;
	static string TypeName_float 	= float.MaxValue.GetType().Name;
	static string TypeName_double 	= double.MaxValue.GetType().Name;
	static string TypeName_string 	= string.Empty.GetType().Name;

	static public bool GetHookingObject(ref string fullName, ref object outValue)
	{
		string[]	typeNames 		= fullName.Split(new char[]{'/'}); 
		int 		typeNamesLength = typeNames.Length;

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
		
		object 	currentObject 		= null;
		bool 	isSuccess 			= false;

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
	
				outValue = currentObject; 
				isSuccess = true;
			}
			else
			{
				type = currentObject.GetType();
			} 
		}
		return isSuccess;
	}
	


	static public bool GetInt(string fullName, ref int outValue)
	{
		bool 	isSuccess 	= false;
		object 	getObj 		= null;

		if(GetHookingObject(ref fullName, ref getObj))
		{ 
			System.Type objType 	= getObj.GetType();
			string  	objTypeName = getObj.GetType().Name;

			if(objTypeName == TypeName_int)
			{
				outValue 	= (int)((int)getObj);
				isSuccess 	= true;
			}
			else if(objTypeName == TypeName_long)
			{
				outValue 	= (int)((long)getObj);
				isSuccess 	= true;
			}
			else if(objTypeName == TypeName_float)
			{ 
				outValue 	= (int)((float)(getObj));
				isSuccess 	= true;
			}  
			else if(objTypeName == TypeName_double)
			{ 
				outValue 	= (int)((double)(getObj));
				isSuccess 	= true;
			}   
			else if(objTypeName == TypeName_string)
			{ 
				if(int.TryParse((string)getObj, out outValue))
				{
					isSuccess 	= true;
				}
				else
				{
					Debug.LogError("else if(objTypeName == TypeName_string)");
				} 
			}  
			else
			{
				Debug.LogError(string.Format("Get Type Convert Faile type is({0}) full name {1}", objTypeName, fullName));
			}
		} 
 
		return isSuccess;
	}

	static public bool GetFloat(string fullName, ref float outValue)
	{
		bool 	isSuccess 	= false;
		object 	getObj 		= null;
		
		if(GetHookingObject(ref fullName, ref getObj))
		{ 
			System.Type objType 	= getObj.GetType();
			string  	objTypeName = getObj.GetType().Name;

			if(objTypeName == TypeName_int)
			{
				outValue 	= (float)((int)getObj);
				isSuccess 	= true;
			}
			else if(objTypeName == TypeName_long)
			{
				outValue 	= (float)((long)getObj);
				isSuccess 	= true;
			}
			else if(objTypeName == TypeName_float)
			{ 
				outValue 	= (float)((float)(getObj));
				isSuccess 	= true;
			}  
			else if(objTypeName == TypeName_double)
			{ 
				outValue 	= (float)((double)(getObj));
				isSuccess 	= true;
			}  
			else if(objTypeName == TypeName_string)
			{ 
				if(float.TryParse((string)getObj, out outValue))
				{
					isSuccess 	= true;
				}
				else
				{
					Debug.LogError("else if(objTypeName == TypeName_string)");
				} 
			}  
			else
			{
				Debug.LogError(string.Format("Get Type Convert Faile type is({0}) full name {1}", objTypeName, fullName));
			}
		} 
		
		return isSuccess;
	}

	static public bool GetString(string fullName, ref string outValue)
	{
		bool 	isSuccess 	= false;
		object 	getObj 		= null;
		
		if(GetHookingObject(ref fullName, ref getObj))
		{  
			System.Type objType 	= getObj.GetType();
			string  	objTypeName = getObj.GetType().Name;
			 
			if(objTypeName == TypeName_string)
			{ 
				outValue = (string)getObj; 
			}  
			else
			{
				IFormattable iFormattable = getObj as IFormattable;
				
				if(iFormattable != null)
				{
					outValue = iFormattable.ToString();
					isSuccess 	= true;
				}
				else
				{
					Debug.LogError(string.Format("Get Type Convert Faile type is({0}) full name {1}", objTypeName, fullName));
				} 
			}
		} 
		
		return isSuccess;
	}

	//	bool  0
	//	
	//	byte  0
	//	
	//	char  0
	//	
	//	DateTime 0
	//	
	//	decimal  0
	//	
	//	double  0
	//	
	//	short  0
	//	
	//	int  0
	//	
	//	long  0
	//	
	//	sbyte 0
	//	
	//	float  0
	//	
	//	string  0
	//	
	//	object  0
	//	
	//	ushort  0
	//	
	//	uint  0
	//	
	//	ulong 0 
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

		string valueString = "";
		if(ExposebleMethod.GetString("Exposeble/get_Ex/Moon", ref valueString))
		{
			Debug.Log("Success valueString  => " + valueString);
		}

		int value = 0; 
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
