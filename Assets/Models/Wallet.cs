﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Models
{
    public class Wallet : MonoBehaviour
    {
        public float CashAmount;

        public void changeAmount(float by) {
            CashAmount += by;
        }
    }
}
