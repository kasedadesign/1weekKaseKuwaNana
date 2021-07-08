using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffTimeLine : MonoBehaviour
{
      public static bool notPlayTimeLine;

      private void Start()
      {
            notPlayTimeLine = false;
      }

      public void SetNotPlayTimeline()
      {
            notPlayTimeLine = true;
      }
}
