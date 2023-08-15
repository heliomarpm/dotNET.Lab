using System;

namespace Proxy
{

    //Proxy    
    public class UsuarioProxy : IUsuario
    {
        //ISubject        
        Usuario u;

        //Request        
        public String Consultar()
        {
            if (this.u == null)
                this.u = new Usuario();

            return u.Consultar();
        }
    }


    //Proxy    
    public class UsuarioProxy2 : IUsuario
    {
        //ISubject        
        Usuario u;

        String senha = "53NH4";

        //Request 
        public String Consultar()
        {
            String retorno = "autentique-se";
            if (this.u != null)
                retorno = u.Consultar();

            return retorno;
        }

        public String Autenticar(String s)
        {
            String retorno = "sem acesso";
            if (s == this.senha)
            {
                this.u = new Usuario();
                retorno = "usuário autenticado";
            }

            return retorno;
        }
    }
}
