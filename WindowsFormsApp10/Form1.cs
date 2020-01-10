using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace WindowsFormsApp10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(Environment.CurrentDirectory + "\\bin"))
                   Directory.CreateDirectory(Environment.CurrentDirectory + "\\bin");

           FileStream f = File.Create(Environment.CurrentDirectory + "\\bin\\mydata.bin");
            f.Close();
           f.Dispose();

            //if (!File.Exists(Environment.CurrentDirectory + "\\bin\\mydata.bin"))
            //File.Create(Environment.CurrentDirectory + "\\bin\\mydata.bin");

        }
        private void writerFile(byte[] array, string strPath)
        {
            //string content = this.txtContent.Text.ToString();

            if (string.IsNullOrEmpty(strPath))
            {
                return;
            }

            //将string转为byte数组
            //byte[] array = Encoding.UTF8.GetBytes(content);

            //string path = Server.MapPath("/test.txt");
            //创建一个文件流
        
                FileStream fs = new FileStream(strPath, FileMode.Create);

                //将byte数组写入文件中
                fs.Write(array, 0, array.Length);
                //所有流类型都要关闭流，否则会出现内存泄露问题
                fs.Close();
                //Response.Write("保存文件成功");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Byte[] recv = new Byte[] { 0x01, 0x02, 0x03 };
            writerFile(recv, Environment.CurrentDirectory + "\\bin\\mydata.bin");
            MessageBox.Show("数据写入完成！");
        }
    }
}
