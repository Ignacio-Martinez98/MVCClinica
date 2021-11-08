using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCClinica.Data;
using System.Web.Mvc;

namespace MVCClinica.Admin
{
    public static class AdmMedico
    {
        private static DbMedicoContext context = new DbMedicoContext();

        public static List<Medico> Listar()
        {
            var medicos = context.Medicos.ToList();
            return medicos;
        }
        public static List<Medico>ListarPorEspecialidad(string especialidad)
        {
            var medicos = (from m in context.Medicos
                           where m.Especialidad == especialidad
                           select m).ToList();
            return medicos;
        }
        public static void Crear(Medico medico)
        {
            context.Medicos.Add(medico);
            context.SaveChanges();           
        }
        public static Medico BuscarPorId(int id)
        {
           Medico medico= context.Medicos.Find(id);
           context.Entry(medico).State = EntityState.Detached;
            return medico;
        }
        public static void Eliminar(Medico medico)
        {
            context.Medicos.Remove(medico);
            context.SaveChanges();           
        }
        public static void Modificar(Medico medico)
        {
            context.Medicos.Attach(medico);
            context.SaveChanges();
        }
        public static List<Medico> ListarEspecialidad(string especialidad)
        {
            List<Medico> medicosEspecialidad = (from o in context.Medicos
                                                where o.Especialidad == especialidad
                                                select o).ToList();
            return medicosEspecialidad;
        }
    }
}