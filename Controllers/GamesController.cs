using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TEST_CRUD.Context;
using TEST_CRUD.Entities;
using TEST_CRUD.Models;

namespace TEST_CRUD.Controllers
{
    public class GamesController : Controller
    {
        public IActionResult Index()
        {
            //return View(_Data.Games.ToList()); = SELECT * FROM GAMES
            return View(_Data.Games.ToList()); //Se pone el servicio, seguido del nombre de la tabla, y la propiedad ToList
        }

        private readonly GamesContext _Data;


        //Constructor
        public GamesController(GamesContext Data)
        {
            _Data = Data;
        } //Se lama el servicio y se le aplica lo que venga en el contexto


        [HttpPost] //Esto indica que la siguiente acción es de method POST
        public IActionResult Nuevo(Games g)
        {

            bool status = false;
            var result = new { status = status };

            try
            {

                Games ga = new Games
                {
                    gameName = g.gameName,
                    launchDate = g.launchDate,
                    genre = g.genre,
                    price = Convert.ToDecimal(g.price)
                };

                _Data.Games.Add(ga);
                if (_Data.SaveChanges() > 0)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            result = new { status };
            return Json(result);
        }

        public IActionResult NuevoDrop()
        {
            var gen = new DropdownModels();
            gen.ListGenre = new List<SelectListItem>
            {
                new SelectListItem { Text = "Acción", Value = "1"},
                new SelectListItem { Text = "Deporte", Value = "2"}
            };
            return PartialView("~/Views/Games/NuevoDrop.cshtml", gen);
        }
        public IActionResult Editar(int gameID)
        {

            try
            {

                if (gameID >= 0)
                {
                    Games Model = _Data.Games.Find(gameID);
                    return PartialView("~/Views/Games/Editar.cshtml", Model);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return null;
        }

        [HttpPost]
        public JsonResult EditarJuego(Games cosas)
        {

            bool status = false;
            var result = new { status = status };

            try
            {

                Games model = new Games();
                model = _Data.Games.Find(cosas.gameId);

                model.gameName = cosas.gameName;
                model.launchDate = cosas.launchDate;
                model.genre = cosas.genre;
                model.price = cosas.price;

                _Data.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                if (_Data.SaveChanges() > 0)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }


                result = new { status = status };
                return Json(result);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            {


            }

            return null;
        }

        public JsonResult Eliminar(int gameID)
        {

            bool status = false;
            var result = new { status = status };

            var theGame = _Data.Games.Find(gameID);


            try
            {

                if (theGame != null)
                {
                    _Data.Games.Remove(theGame);
                    if (_Data.SaveChanges() > 0)
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            result = new { status = status };
            return Json(result);
        }

        public JsonResult GetCategorias()
        {
            List<Listados> cat = new List<Listados>();
            cat = _Data.Dropdown.Select(p => new Listados()
            {
                genreID = p.genreID,
                genre = p.genre,
            }).ToList();


            return Json(cat);
        }

        public JsonResult GetPlatforms()
        {
            List<Listados2> pla = new List<Listados2>();
            pla = _Data.Dropdown2.Select(p => new Listados2()
            {
                platformID = p.platformID,
                platform = p.platform,
            }).ToList();

            return Json(pla);
        }
    }
}
