using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Threading.Tasks;

namespace MaisEventosVsCode.Utils
{

    //Singleton ->Static
    public static class  Upload
    {
        // Upload.
        public static string UploadFile(IFormFile arquivo, string[] extencoesPermitidas, string diretorio)
        {
            try
            {
                // Determinamos onde sera salvo o arquivo
               var pasta   = Path.Combine("StaticFiles", diretorio);
               var caminho = Path.Combine(Directory.GetCurrentDirectory(), pasta); 

                // Verificamos se existe um arquivo para ser salvo
               if(arquivo.Length > 0)
               {
                    // Pegamos o nome do arquivo
                    string nomeArquivo = ContentDispositionHeaderValue.Parse(arquivo.ContentDisposition).FileName.Trim('"');
                    
                    // Validamos se a extencao é permitida
                    if(ValidarExensao(extencoesPermitidas, nomeArquivo))
                    {
                        var extencao = RetornarExtencao(nomeArquivo);
                        var novoNome = $"{Guid.NewGuid()}.{extencao}";
                        var caminhoCompleto = Path.Combine(caminho, novoNome);

                        //salvamos efetivamente o arquivo na aplicação

                        using(var stream = new FileStream(caminhoCompleto, FileMode.Create))
                        {
                            arquivo.CopyTo(stream);
                        }
                        return novoNome;

                    }
               }            
                    return "";
            }
            catch (System.Exception ex)
            {
                
                return ex.Message;
            }
        }
        //Remover arquivo.
        //Validar Extenções de arquivo.
        public static bool ValidarExensao(string[] extencoesPermitidas, string nomeArquivo)
        {   
   
            string extencao = RetornarExtencao(nomeArquivo);
            foreach (string ext in extencoesPermitidas)
            {
                if(ext == extencao)
                {
                    return true;
                }
            }

            return false;
        }
        // Retornar extenção.
        public static string RetornarExtencao(string nomeArquivo)
        {
            //artuivo.jpeg
            string[] dados = nomeArquivo.Split('.');
            return dados[dados.Length -1];
        }

        internal static string UploadFile(IFormFile arquivo, object extencoesPermitidas)
        {
            throw new NotImplementedException();
        }
    }
}