using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using System;

[Serializable] 
public class Data { 
   public bool execute;
   public int puzzleLines;

   [Serializable] 
   public struct Arraypuzzle {
      public string action;
      public int number1;
      public int number2;
   }

   public Arraypuzzle[] puzzle;
}


public class UseDLL : MonoBehaviour
{

   [DllImport("TestCPPLibrary")]
   private static extern IntPtr testStringPassing(string toEcho, int size);
   public Data data = new Data();

   public static UseDLL instance = null;

   void Awake() {
       instance = this;
   }
   
   // Use this for initialization
   void Start()
   {

      using (StreamWriter writer = new StreamWriter("debug.txt", true))
      {
         string testEchoString = "test test test test test                                          "
            + "                                                                 "
            + "                                                                 ";

         writer.WriteLine("before:" + testEchoString);

         IntPtr echoedStringPtr = testStringPassing(testEchoString, testEchoString.Length);

          String echoed = Marshal.PtrToStringAnsi(echoedStringPtr);

         // writer.WriteLine("after:"+ echoed);

		 /*string echoed = @"{
            ""execute"": false,
            ""puzzleLines"": 2,
            ""puzzle"": [
               {
                  ""action"": ""start"",
                  ""number1"": ""0"",
                  ""number2"": ""0""
               },
               {
                  ""action"": ""start"",
                  ""number1"": ""0"",
                  ""number2"": ""0""
               }
            ]
         }";*/

		 data = JsonUtility.FromJson<Data>(echoed);
      }
      /* */

   }

   // Update is called once per frame
   void Update()
   {
      //using (StreamWriter writer = new StreamWriter("debug.txt", true))
      //{


         //string testEchoString = "test test test test test                                          "
         //   + "                                                                 "
         //   + "                                                                 ";

         // writer.WriteLine("before:" + testEchoString);

        // IntPtr echoedStringPtr = testStringPassing(testEchoString, testEchoString.Length);

         // String echoed = Marshal.PtrToStringAnsi(echoedStringPtr);

         // writer.WriteLine("after:" + echoed);

         /*string echoed = @"{
            ""execute"": true,
            ""puzzleLines"": 2,
            ""puzzle"": [
               {
                  ""action"": ""add"",
                  ""number1"": ""4"",
                  ""number2"": ""5""
               },
               {
                  ""action"": ""sub"",
                  ""number1"": ""1"",
                  ""number2"": ""2""
               }
            ]
         }";*/

		 //JsonUtility.FromJsonOverwrite(echoed, data);

      //}

   }
}