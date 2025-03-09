﻿using FronEnd.ApiModels;
using FronEnd.Helpers.Interfaces;
using FronEnd.Models;
using Newtonsoft.Json;


namespace FronEnd.Helpers.Implementations
{
    public class CategoriaHelper : ICategoriaHelper
    {
        IServiceRepository _ServiceRepository;

        CategoriaViewModel Convertir(CategoriaAPI categoria)
        {
            CategoriaViewModel categoriaViewModel = new CategoriaViewModel
            {
                IdCategoria = categoria.IdCategoria,
                NombreCategoria = categoria.NombreCategoria,
                Descripcion = categoria.Descripcion

            };
            return categoriaViewModel;
        }


        public CategoriaHelper(IServiceRepository serviceRepository)
        {
            _ServiceRepository = serviceRepository;
        }

        public CategoriaViewModel Add(CategoriaViewModel categoria)
        {
            HttpResponseMessage response = _ServiceRepository.PostResponse("api/Categoria", categoria);
            if (response.IsSuccessStatusCode)
            {

                var content = response.Content.ReadAsStringAsync().Result;
            }
            return categoria;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<CategoriaViewModel> GetCategorias()
        {
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Categoria");
            List<CategoriaAPI> categorias = new List<CategoriaAPI>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                categorias = JsonConvert.DeserializeObject<List<CategoriaAPI>>(content);
            }
            List<CategoriaViewModel> lista = new List<CategoriaViewModel>();
            foreach (var categoria in categorias)
            {
                lista.Add(Convertir(categoria));
            }   
            return lista;
        }

        public CategoriaViewModel GetCategoria(int? id)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Categoria/" + id.ToString());
            CategoriaAPI categoria = new CategoriaAPI();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                categoria = JsonConvert.DeserializeObject<CategoriaAPI>(content);
            }

            CategoriaViewModel resultado = Convertir(categoria);


            return resultado;
        }

        public CategoriaViewModel Update(CategoriaViewModel categoria)
        {
            throw new NotImplementedException();
        }
    }
}
