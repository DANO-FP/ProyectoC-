using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace Logica
{
    public interface ILFuncionario
    {
        void AgregarFuncionario(Funcionario F);
        void EliminarFuncionario(Funcionario F);
        void ModificarFuncionario(Funcionario F);
        Funcionario BuscarFuncionario(string F);
        List<Funcionario> ListarFuncionario();
        Funcionario Logueo(string F, string P);
    }
}
