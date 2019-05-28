using System;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace MarkDownPad2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!check())
            {
                MessageBox.Show("请检查 UserName(姓名) 和 Mail(邮箱) 是否填写完整");
                return;
            }

            Assembly assembly = Assembly.Load(Properties.Resources.ManagedOpenSsl);
            Type CryptoKeyType = assembly.GetType("OpenSSL.Crypto.CryptoKey");
            Type RsaType = assembly.GetType("OpenSSL.Crypto.RSA");
            UserInfo u = new UserInfo();
            object _t = CryptoKeyType.GetMethod("GetRSA").Invoke(CryptoKeyType.GetMethod("FromPrivateKey", new Type[] { typeof(string), typeof(string) }).Invoke(null, new object[] { App.pem, App.password }),null);        
            u.Product = "MarkdownPad2";
            u.Name = textBox1.Text;
            u.Email = textBox2.Text;
            u.CreationDate = DateTime.Now;
            u.LicenseTypeId = 1;
            string json = App.GetJson(u);
            byte[] bytes = Encoding.Default.GetBytes(json);
          textBox3.Text=Convert.ToBase64String(RsaType.GetMethod("PrivateEncrypt").Invoke(_t, new object[] {bytes,1 })as byte[]);
        
           
        }
        private bool check() {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox2.Text.IndexOf("@") != -1)
            {
                return true;
            }
            else {
                return false;
            }
        }
    }



}
