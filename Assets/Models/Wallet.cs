using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Models
{
    public class Wallet : MonoBehaviour
    {
        public int CashAmount;

        public void ChangeAmount(int by) {
            CashAmount += by;
        }
    }
}
