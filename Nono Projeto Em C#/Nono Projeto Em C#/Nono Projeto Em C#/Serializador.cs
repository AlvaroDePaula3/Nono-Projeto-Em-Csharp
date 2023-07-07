﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using oitavo_projeto_C_;

namespace Nono_Projeto_Em_C_
{
    internal static class Serializador
    {
        static private DataContractSerializer serializador = new DataContractSerializer(typeof(dadosDoUsuario));

        public static void serializando(string localDoArquivo, dadosDoUsuario pdadosDoUsuario)
        {
            XmlWriterSettings configuracoes = new XmlWriterSettings { Indent = true };
            StringBuilder construtorDeStrings = new StringBuilder();
            XmlWriter escritor = XmlWriter.Create(construtorDeStrings, configuracoes);
            serializador.WriteObject(escritor, pdadosDoUsuario);
            escritor.Flush();
            string objetoSerializado = construtorDeStrings.ToString();
            escritor.Close();

            FileStream arquivoXML = File.Create(localDoArquivo);
            arquivoXML.Close();
            File.WriteAllText(localDoArquivo, objetoSerializado);

        }

        public static dadosDoUsuario desserializar(string localDoArquivo)
        {
            try
            {
                if (File.Exists(localDoArquivo))
                {
                    string conteudoDoObjetoSerializado = File.ReadAllText(localDoArquivo);
                    StringReader leitor = new StringReader(conteudoDoObjetoSerializado);
                    XmlReader xmlLeitor = XmlReader.Create(leitor);
                    dadosDoUsuario dadosTemporario = (dadosDoUsuario)serializador.ReadObject(xmlLeitor);
                    return dadosTemporario;
                }
                else
                    return null;

            }
            catch
            {
                return null;
            }
        }
    }
}
