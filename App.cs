using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace MarkDownPad2
{
    class App
    {
        public  const string pem = "-----BEGIN RSA PRIVATE KEY-----\r\nProc-Type: 4,ENCRYPTED\r\nDEK-Info: DES-EDE3-CBC,CCE015B0820B9A3F\r\n \r\n4BiGKVEzt+cLBdilEZR+8Y0YHrarjNX4bT5XbQ5BgTcJwMYnARCKib+BgwX9wPUB\r\n3D7PUwt4m4OGemXXcC4ELUFyMqHIT6SILFSdTTIvnQbsWutx44zyJK9SlP/2uhG8\r\nJIUDdLWVv5kS8J/UcInC5bomKZ5SX3+0ziRpLWkgXoHJ5gjQ+fDNzAKLcNn7Bubq\r\nznjoSH8XuGnORp7d4FiRT5Vl9WpnBqyyFSkYwzDOK//iFgHyhYZ5BCInfQMX66Cj\r\nwk3Pax/ujSDzYalkkJe8o8VAcEisMoYhSTS9BnRpROn6V4UyAugWMPnEOgiBmO42\r\nHwLoqK7WXCe+wS1UiDnECU2wIU5Z8qL5oKEKFGukakK+mYXh8MHTkYq2ZQZBo8Vy\r\nvenhBaolrViCWdkJ5MsuqarBJjyCeAS38GAJURxsKnd+Bp7gGAlNI/0OWIcrjIi4\r\n4o/0CaYRHR+PdeuJup5rUKPgGfMW0iOwmMncSM19hIiaU4/hHGYeXrL1aKfZX4ML\r\nYxWJ/i6u8U3gcJo/bOvjirxUZOLTfv3n5aDTcxU70ejgmmYLBaxKt32Ib9oLwnL8\r\nAUnWNRPZaNJ/X853ybsGu73vA/6HPw63g0EaNharg21Q1IhuggMvHJiN6Z9d4KGg\r\nVio6++15SVcsyQEGZx+jjv95IEfgwUQXBmkNRZ/KJQQLkKuOuXuvakI5sWdNJLRo\r\nxY9W2lHMnY/Yi82V4P5odxFZOmAYK5DHCQ47gw9IzqGjCyxATAYgkoZR+PCP5y9n\r\nIZ8oRYbNpykXVvQC0JALgixIZaAjj30wXb1CcD3layQNkrp0O4qVzuqyT7e2aKEq\r\nXNeoB0uDNvn10L60QAOG5630uIIFRyXphZgrzScp97ABq7STQ7t4zTZhbmiwnPHq\r\n8xft+mO2rW3puYEHoEkQKwJcPUTpR/s67IIXQMs1y93WpJoOw7doumyNtAoR8EfK\r\nm/H4UoJhoiXL755n4CGnET+LEtuFO/0UwdWxj+u503ovWL021DAnKhrGPMpo73ga\r\naL/OBSFSFyxY92qGqfMWNQOaoK5hCRhzp/8Pd+B1tjhnxUNOl1ulytmhJBigU5nV\r\narkgJYmG+Ox15f1YWxmD1EhLOQLUgBruG04cjRnG4LXV+UBKRdcS3bECArFutlTw\r\n6ogbi8cbDJNBbGpnlfIbEgGEe423rCTuoLJcIZfIDvPDsMobd9lCgn2o95N3Ey4U\r\n+UT1PEDEhXW0nggdvZGy8y4T0ZIJ6Tn4asWHTsqH1fQYEz3H51pMehfCbxbc6Bbh\r\nnuNyrjv0NSNJvOAn71tFPRf6vgO83h5EFS0ov5ASbWchuf7BFpebmOO04aVMXPBe\r\n3nfE1L5in5ApK7AyhfdSPpELCxBUQ0av4k/0yw/P2TRllybgjdoXjlsJqBn7rkqr\r\n4u1H7pytlEWt0mSgZenlGXrOOEaknUe40z9BHNxliA7ET1MQk6veFVfbSFjeVUDk\r\nfsFAVE88/KHyMMfGwwcuLdnQnOBHNJ8iJjJF+RZy93QzveZB22+m5cl9SNXIMcEA\r\nmOm4Q8CaLwwzZmF9NKV2CjlmUTqOszJv5abS5YdrPavAR6QxGjZfya3nA2ASd6HN\r\n-----END RSA PRIVATE KEY-----\r\n";
        public  const string password= "Blink182";

        public static string GetJson(object o) {
            Type type = o.GetType();
            FieldInfo[] v = type.GetFields();
            StringBuilder sb = new StringBuilder();
            string json = string.Empty;
            foreach (var item in v)
            {
                sb.Append("\"" + item.Name + "\"");
                sb.Append( ":");
                if (item.FieldType==typeof(double)||item.FieldType==typeof(int) || item.FieldType == typeof(float) || item.FieldType == typeof(short)) {
                    sb.Append(item.GetValue(o));
                }
                else
                {
                    sb.Append("\"" + item.GetValue(o) + "\"");
                }
                sb.Append(",");
            }
            json = "{" + sb.ToString().Substring(0, sb.Length - 1) + "}";
            return json;
           
        }

    }
}
