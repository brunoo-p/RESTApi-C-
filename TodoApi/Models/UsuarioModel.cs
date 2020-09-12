using System;
using System.ComponentModel.DataAnnotations;
using TodoApi.Models;

public class UsuarioModel
{
    public long Id {get; set;}
    public string Nome {get; set;}
    public Cadastro cadastro { get; set; }

}
    //public bool IsCompleted { get; set; }
   
    /*[Display(Name = "Descrição")]
    public string Descricao { get; set; }*/
   