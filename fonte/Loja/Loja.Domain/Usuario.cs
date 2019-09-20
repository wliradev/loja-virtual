using System;
using System.ComponentModel.DataAnnotations;

namespace Loja.Domain
{
    public class Usuario : EntityKey
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        public string Email { get; set; }

        public bool Ativo { get; set; }

        [Required]
        public string Senha { get; set; }

        public bool SolicitarNovaSenha { get; set; }

        public DateTime? DataUltimoAcesso { get; set; }

        public DateTime DataCadastro { get; set; }

        public Usuario()
        {
            DataCadastro = DateTime.Now;
            Ativo = true;
            SolicitarNovaSenha = true;
        }

        public void CriptografarSenha()
        {
            Senha = GetMD5Hash(Senha);
        }

        protected string GetMD5Hash(string input)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }

    }
}