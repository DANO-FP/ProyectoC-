using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using Entidades;

namespace Logica
{
    internal class LFuncionarios:ILFuncionario
    {
        //singleton
        private static LFuncionarios instancia = null;

        private LFuncionarios() { }

        //operacion
        public static LFuncionarios GetInstancia()
        {
            if (instancia == null)
                instancia = new LFuncionarios();
            return instancia;
        }

        public void AgregarFuncionario(Funcionario F)
        {
            IFuncionario Funcionario = Persistencia.PFabrica.GetInstanciaFuncionario();
            Funcionario.AgregarFuncionario(F);
        }
        public void ModificarFuncionario(Funcionario F)
        {
            IFuncionario Funcionario = Persistencia.PFabrica.GetInstanciaFuncionario();
            Funcionario.ModificarFuncionario(F);
        }
        public void EliminarFuncionario(Funcionario F)
        {
            IFuncionario Funcionario = Persistencia.PFabrica.GetInstanciaFuncionario();
            Funcionario.EliminarFuncionario(F);
        }
        public Funcionario Logueo (string F,string P)
        {
            IFuncionario Funcionario =Persistencia.PFabrica.GetInstanciaFuncionario();
            return Funcionario.Logueo(F,P);
        }
        public Funcionario BuscarFuncionario(string F)
        {
            IFuncionario Funcionario = Persistencia.PFabrica.GetInstanciaFuncionario();
            return Funcionario.BuscarFuncionario(F);
        }
        public List<Funcionario> ListarFuncionario()
        {
            IFuncionario Funcionario = Persistencia.PFabrica.GetInstanciaFuncionario();
            return (Funcionario.ListarFuncionario());
        }
    }
}
