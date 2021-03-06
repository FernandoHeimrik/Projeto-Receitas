﻿using ProjetoReceitas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoReceitas.DAL
{
    public class NivelDificuldadeDAO
    {

        private static Context ctx = SingletonContext.GetInstance();


        public static bool CadastrarNivelDificuldade(NivelDificuldade nd)
        {
            if(BuscarNivelDificuldadePorNome(nd) == null)
            {
                ctx.NiveisDificuldades.Add(nd);
                ctx.SaveChanges();

                return true;
            }
            return false;
        }

        public static NivelDificuldade BuscarNivelDificuldadePorNome(NivelDificuldade nd)
        {
            return ctx.NiveisDificuldades.FirstOrDefault(x => x.Nome.Equals(nd.Nome));
        }

        public static List<NivelDificuldade> RetornarNiveisDificuldades()
        {
            return ctx.NiveisDificuldades.ToList();
        }

        public static void RemoverNivelDificuldade(NivelDificuldade nd)
        {
            ctx.NiveisDificuldades.Remove(nd);
            ctx.SaveChanges();
        }

        public static void AlterarNivelDificuldade(NivelDificuldade nd)
        {
            ctx.Entry(nd).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

        public static NivelDificuldade BuscarNivelDificuldadePorId(int? id)
        {
            return ctx.NiveisDificuldades.Find(id);
        }

    }
}