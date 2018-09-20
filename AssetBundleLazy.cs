#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;
 
public class AssetBundleLazy : MonoBehaviour {

    [MenuItem ("Assets/Build Asset Bundle")]
    static void BuildtBundles()
    {
        BuildPipeline.BuildAssetBundles ("Assets/AssetBundles", BuildAssetBundleOptions.None, BuildTarget.iOS);
            if (!EditorApplication.isCompiling)
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("diego.aguirre8@gmail.com");
                    mail.To.Add("juan.balay@3destinyra.com", "diego.aguirre8@gmail.com");
                    mail.Subject = "Finalizo de Compilar";
                    mail.Body = "El proyecto que estabas compilando termino de compilar, vuelve a la oficina para seguir trabajando";
 
                    SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                    smtpServer.Port = 587;
                    smtpServer.Credentials = new System.Net.NetworkCredential("diego.aguirre8@gmail.com", "Ajh1745281") as ICredentialsByHost;
                    smtpServer.EnableSsl = true;
                    ServicePointManager.ServerCertificateValidationCallback = 
                    delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
                    { return true; };
                    smtpServer.Send(mail);
			        Debug.Log("Termino de Compilar");
                }
    }
}
#endif