using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _56_60_bandienthoai
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmMAU());
            //Application.Run(new frmNHACUNGCAP());
            //Application.Run(new frmHOADONBAN());
            //Application.Run(new frmSANPHAM());
            //Application.Run(new frmHINH());
            //Application.Run(new frmHOADONNHAP());
            //Application.Run(new frmTimKiemNCC());
            //Application.Run(new frmLOAISP());
            //Application.Run(new frmKHACHHANG());
            //Application.Run(new frmTimKiemSP());
            //Application.Run(new frmTimKiemKhachHang());
            //Application.Run(new frmTimKiemNhanVien());
            //Application.Run(new frmTimHDBan());
            //Application.Run(new frmTimKiemHDNhap());
            //Application.Run(new frmThongKeSP());
            //Application.Run(new frmThongKeNCC());
            Application.Run(new frmMenu());
        }
    }
}
