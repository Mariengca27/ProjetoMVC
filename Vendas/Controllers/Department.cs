using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendas.Models;

namespace Vendas.Controllers
{
    public class Department : Controller
    {
        public IActionResult Index()
        {
            //Instanciando os objetos criados  do Department1 
            List<Department1> list = new List<Department1>();
            list.Add(new Department1 {Id = 1, Name = "Eletrônicos." });
            list.Add(new Department1 { Id = 2, Name = "Mecânicos" });
            list.Add(new Department1 { Id = 3, Name = "Jogos PS5" });

            return View(list); //Enviando dados do Controller para o View
        }
    }
}
