using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heater_delegate_event_82
{
    public class Heater
    {
        public delegate void delegate1(object s, MyEventArgs e);
        public event delegate1 event1;

        private int tem;
        public string type = "奔浦";
        public string area = "广东";
        public class MyEventArgs : EventArgs
        {
            public readonly int tem;
            public MyEventArgs(int t)
            {
                this.tem = t;

            }
        }
        //甲方，可以供继承自 Heater 的子类重写，以便子类拒绝其他对象对它的监视
        protected virtual void boiling(MyEventArgs e)
        {
            if (event1 != null)
            {
              //  MyEventArgs e = new MyEventArgs(5);
                event1(this, e);
            }

        }
        public void BoilingWater()
        {
            for (int i = 0; i <= 100; i++)
            {
                tem = i;
                if (tem > 95)
                {
                    MyEventArgs e = new MyEventArgs(tem);
                    boiling(e);
                }


            }

        }
    }
        public class Alarm {
            public void MakeAlert(object s,Heater.MyEventArgs e) {
                Heater he = (Heater)s;
                Console.WriteLine("alarm:{0}-{1}:",he.type,he.area); 
                Console.WriteLine("alarm:嘀嘀嘀，水已经{0}度了：",e.tem);
                Console.WriteLine();
            }
        
        }
    public class Display{
        public static void ShowMsg(object s,Heater.MyEventArgs e) {
            Heater he = (Heater)s;
            Console.WriteLine("Display:{0}-{1}：",he.type,he.area);
            Console.WriteLine("Display:水快烧开了，当前水温为：{0}",e.tem);
            Console.WriteLine();


        } 
    
    }



        class Program
        {
            static void Main(string[] args)
            {
                Heater h = new Heater();
                Alarm a=new Alarm();
                h.event1 += a.MakeAlert;
                h.event1 += Display.ShowMsg;
                h.BoilingWater();
                Console.ReadKey();

            }
        }
    }

