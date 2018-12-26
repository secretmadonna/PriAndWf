using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PriAndWf.Infrastructure.Helper
{
    /// <summary>
    /// 注意：1、KEY 必须是XML的行式，返回的是字符串；2、该加密方式有长度限制的。
    /// </summary>
    public class RsaHelper
    {
        #region RSA 加密 解密

        #region RSA 生成秘钥
        /// <summary>
        /// RSA 生成秘钥
        /// </summary>
        /// <param name="xmlPrivateKey">私钥</param>
        /// <param name="xmlPublicKey">公钥</param>
        public void GenerateKey(out string xmlPrivateKey, out string xmlPublicKey)
        {
            var rsaCsp = new RSACryptoServiceProvider();
            xmlPrivateKey = rsaCsp.ToXmlString(true);
            xmlPublicKey = rsaCsp.ToXmlString(false);
        }
        #endregion

        #region RSA 加密
        public string Encrypt(string plaintext, string xmlPublicKey)
        {
            RSACryptoServiceProvider rsaCsp = new RSACryptoServiceProvider();
            rsaCsp.FromXmlString(xmlPublicKey);
            var plaintextBa = Encoding.Default.GetBytes(plaintext);
            var ciphertextBa = rsaCsp.Encrypt(plaintextBa, false);
            var ciphertext = Convert.ToBase64String(ciphertextBa);//Encoding.Default.GetString(ciphertextBa);
            return ciphertext;
        }
        public string Encrypt(byte[] plaintextBa, string xmlPublicKey)
        {
            RSACryptoServiceProvider rsaCsp = new RSACryptoServiceProvider();
            rsaCsp.FromXmlString(xmlPublicKey);
            var ciphertextBa = rsaCsp.Encrypt(plaintextBa, false);
            var ciphertext = Convert.ToBase64String(ciphertextBa);//Encoding.Default.GetString(ciphertextBa);
            return ciphertext;
        }
        #endregion

        #region RSA 解密
        public string Decrypt(string ciphertext, string xmlPrivateKey)
        {
            RSACryptoServiceProvider rsaCsp = new RSACryptoServiceProvider();
            rsaCsp.FromXmlString(xmlPrivateKey);
            var ciphertextBa = Convert.FromBase64String(ciphertext);
            var plaintextBa = rsaCsp.Encrypt(ciphertextBa, false);
            var plaintext = Encoding.Default.GetString(ciphertextBa);
            return plaintext;
        }
        public string Decrypt(byte[] ciphertextBa, string xmlPrivateKey)
        {
            RSACryptoServiceProvider rsaCsp = new RSACryptoServiceProvider();
            rsaCsp.FromXmlString(xmlPrivateKey);
            var plaintextBa = rsaCsp.Encrypt(ciphertextBa, false);
            var plaintext = Encoding.Default.GetString(ciphertextBa);
            return plaintext;
        }
        #endregion

        #endregion

        #region RSA 签名 验签

        #region 生成摘要
        public byte[] GetByteDigest(string plaintext)
        {
            var md5 = HashAlgorithm.Create("MD5");
            var plaintextBa = Encoding.Default.GetBytes(plaintext);
            var plaintextDigestBa = md5.ComputeHash(plaintextBa);
            return plaintextDigestBa;
        }
        public string GetStringDigest(string plaintext)
        {
            var plaintextDigestBa = GetByteDigest(plaintext);
            var plaintextDigest = Convert.ToBase64String(plaintextDigestBa);
            return plaintextDigest;
        }
        public byte[] GetByteDigest(Stream stream)
        {
            var md5 = HashAlgorithm.Create("MD5");
            var plaintextDigestBa = md5.ComputeHash(stream);
            stream.Close();
            return plaintextDigestBa;
        }
        public string GetStringDigest(Stream stream)
        {
            var plaintextDigestBa = GetByteDigest(stream);
            var plaintextDigest = Convert.ToBase64String(plaintextDigestBa);
            return plaintextDigest;
        }
        #endregion

        #region RSA 签名
        public byte[] SignToByte(byte[] digest, string xmlPrivateKey)
        {
            var rsaCsp = new RSACryptoServiceProvider();
            rsaCsp.FromXmlString(xmlPrivateKey);
            var rsaPsf = new RSAPKCS1SignatureFormatter(rsaCsp);
            rsaPsf.SetHashAlgorithm("MD5");
            var signatureBa = rsaPsf.CreateSignature(digest);
            return signatureBa;
        }
        public string SignToString(byte[] digest, string xmlPrivateKey)
        {
            var signatureBa = SignToByte(digest, xmlPrivateKey);
            var signature = Convert.ToBase64String(signatureBa);
            return signature;
        }
        public byte[] SignToByte(string digest, string xmlPrivateKey)
        {
            var digestBa = Convert.FromBase64String(digest);
            var signatureBa = SignToByte(digestBa, xmlPrivateKey);
            return signatureBa;
        }
        public string SignToString(string digest, string xmlPrivateKey)
        {
            var digestBa = Convert.FromBase64String(digest);
            var signatureBa = SignToByte(digestBa, xmlPrivateKey);
            var signature = Convert.ToBase64String(signatureBa);
            return signature;
        }
        #endregion

        #region RSA 验签
        public bool ValidSignature(byte[] digest, byte[] signature, string xmlPublicKey)
        {
            var rsaCsp = new RSACryptoServiceProvider();
            rsaCsp.FromXmlString(xmlPublicKey);
            var rsaPsd = new RSAPKCS1SignatureDeformatter(rsaCsp);
            rsaPsd.SetHashAlgorithm("MD5");
            var isValid = rsaPsd.VerifySignature(digest, signature);
            return isValid;
        }
        public bool ValidSignature(byte[] digest, string signature, string xmlPublicKey)
        {
            var signatureBa = Convert.FromBase64String(signature);
            return ValidSignature(digest, signatureBa, xmlPublicKey);
        }
        public bool ValidSignature(string digest, byte[] signature, string xmlPublicKey)
        {
            var digestBa = Convert.FromBase64String(digest);
            return ValidSignature(digestBa, signature, xmlPublicKey);
        }
        public bool ValidSignature(string digest, string signature, string xmlPublicKey)
        {
            var digestBa = Convert.FromBase64String(digest);
            var signatureBa = Convert.FromBase64String(signature);
            return ValidSignature(digestBa, signatureBa, xmlPublicKey);
        }
        #endregion

        #endregion
    }
}
