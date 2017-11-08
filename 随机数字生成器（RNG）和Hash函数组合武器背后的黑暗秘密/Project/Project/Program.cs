using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "E:\\文档库\\GDC\\随机数字生成器（RNG）和哈希函数组合武器背后的黑暗秘密\\data6.txt";
            FileStream fs = new FileStream(path, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            for (int i=0;i<100000;i++)
            {
                //Random ra = new Random(MD5_Hash(i.ToString()));
                Random ra = new Random(SHA1_Hash(i.ToString()));
                ////开始写入
                sw.Write(ra.Next(1000000).ToString() + "\r\n");
                //清空缓冲区
                sw.Flush();
            }
            //关闭流
            sw.Close();
            fs.Close();
            return;
        }

        //MD5
        static public int MD5_Hash(string str_md5_in)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes_md5_in = UTF8Encoding.Default.GetBytes(str_md5_in);
            byte[] bytes_md5_out = md5.ComputeHash(bytes_md5_in);
            //string str_md5_out = BitConverter.ToString(bytes_md5_out);         
            ////str_md5_out = str_md5_out.Replace("-", "");
            //return str_md5_out;
            return BitConverter.ToInt32(bytes_md5_out,0);
        }

        //SHA1

        static public int SHA1_Hash(string str_sha1_in)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] bytes_sha1_in = UTF8Encoding.Default.GetBytes(str_sha1_in);
            byte[] bytes_sha1_out = sha1.ComputeHash(bytes_sha1_in);
            //string str_sha1_out = BitConverter.ToString(bytes_sha1_out);
            ////str_sha1_out = str_sha1_out.Replace("-", "");
            //return str_sha1_out;
            return BitConverter.ToInt32(bytes_sha1_out, 0);
        }
    }
}
