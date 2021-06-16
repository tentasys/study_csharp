using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_SealedMethod
{
    class Base
    {
        public virtual void SealMe()
        {

        }
    }
    class Derived : Base
    {
        public sealed override void SealMe()
        {
            
        }
    }
    class WantToOverride : Derived
    {
        //public override void SealMe()
        //{

       // }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
