using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using System;

namespace TodoApi.Controllers
{
    [Route(template: "api/[controller]")]
    public class UsuarioController : Controller
    {
        private static List<UsuarioModel> _listaUsuarios;
        private TodoContext sql = new TodoContext();
        static UsuarioController()
        {
            _listaUsuarios = new List<UsuarioModel>();
        }
        

        [HttpGet]
        public IEnumerable<UsuarioModel> GetAll()
    {
        return _listaUsuarios.AsReadOnly();
    }
        
        [HttpGet("{id}", Name = "GetUsuario")]
        public IActionResult GetById(long id)
        {
            var item = _listaUsuarios.Find(x => x.Id == id);
            if(item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }


        [HttpPost]
        public string CadastrarUsuario(UsuarioModel usuario)
        {
            _listaUsuarios.Add(usuario);
            sql.SaveChanges();

            return "Usuário Cadastrado com Sucesso!";
        }


        [HttpPut("{id}")]
        public string AlterarUsuario(long id, UsuarioModel usuario)
        {
            if(!ModelState.IsValid)
            {
                return "ERRO";
            }

            sql.Entry(usuario).State = EntityState.Modified;
            
            try
            {
                sql.SaveChanges();
                return "Usuário Alterado com Sucesso!";
            }
            catch (DbUpdateException)
            {
                return "Houve um ERRO ao salvar no Banco de Dados."; 
            }
        }

        
        [HttpPost]
        public string NovoUsuario(UsuarioModel usuario)
        {
            try
            { 
                sql.usuarioModel.Add(usuario);
                usuario.Id = (_listaUsuarios.Count + 1);
                sql.SaveChanges();
                return "Usuário Cadastrado com Sucesso!";
            }
            catch(Exception e)
            {
                return(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            _listaUsuarios.RemoveAll(n => n.Id == id);
            sql.SaveChanges();
            return "Usuário Excluído com sucesso.";
        }

        protected override void Dispose(bool disposing)
        {
            sql.Dispose();
            base.Dispose(disposing);
        } 
    }
}