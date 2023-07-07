using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Nono_Projeto_Em_C_;

namespace oitavo_projeto_C_
{
    [DataContract]
    internal class dadosDoUsuario
    {
        //atributos da aplicação
        [DataMember]
        private List<cadastroDoUsuario> cadastrarUsuario;
        private string localDosDados;

        public void adicionarIndividuo(cadastroDoUsuario cUsuario)
        {
            cadastrarUsuario.Add(cUsuario);
            Serializador.serializando(localDosDados, this);
        }
        public List<cadastroDoUsuario> procurarUsuarioTelefone(string pUsuario)
        {
            List<cadastroDoUsuario> listaUsuarioTemporaria = cadastrarUsuario.Where(x => x.usuarioTelefone == pUsuario).ToList();
            if (listaUsuarioTemporaria.Count > 0)
            {
                return listaUsuarioTemporaria;
            }
            else
            {
                return null;
            }
        }

        public List<cadastroDoUsuario> removerUsuarioTelefone(string pUsuario)
        {
            List<cadastroDoUsuario> listaUsuarioTemporaria = cadastrarUsuario.Where(x => x.usuarioTelefone == pUsuario).ToList();
            if (listaUsuarioTemporaria.Count > 0)
            {
                foreach (cadastroDoUsuario usuario in listaUsuarioTemporaria)
                {
                    cadastrarUsuario.Remove(usuario);
                }
                return listaUsuarioTemporaria;
            }
            else
                return null;
        }

        //construtor dos dados do usuário

        public dadosDoUsuario(string localDosDados)
        {
             this.localDosDados = localDosDados;
            dadosDoUsuario dadosDoUsuarioTemporaria = Serializador.desserializar(localDosDados);
            if (dadosDoUsuarioTemporaria != null)
                cadastrarUsuario = dadosDoUsuarioTemporaria.cadastrarUsuario;
            else
            cadastrarUsuario = new List<cadastroDoUsuario>();
        }
    }
}
