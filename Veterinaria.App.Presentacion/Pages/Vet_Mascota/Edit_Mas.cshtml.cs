using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veterinaria.App.Persistencia.AppRepositorios;
using Veterinaria.App.Dominio;


namespace Veterinaria.App.Presentacion.Pages
{
    public class Edit_MasModel : PageModel
    {
        private readonly IRepositorioMascota RepositorioMascota;
        [BindProperty]
        public Mascota Mascota {get;set;}

        public Edit_MasModel()
        {
            this.RepositorioMascota = new RepositorioMascota(new Veterinaria.App.Persistencia.AppContext());

        }  
        public IActionResult OnGet(int? Mascotaid)
        {
            if (Mascotaid.HasValue)
            {
                Mascota = RepositorioMascota.GetMascota(Mascotaid.Value);
            }
            else
            {
                Mascota = new Mascota();
            }
            if (Mascota == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();

        }
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(Mascota.id>0)
            {
            Mascota = RepositorioMascota.UpdateMascota(Mascota);
            }
            else
            {
             RepositorioMascota.AddMascota(Mascota);
            }
            return Page();
        }

    }
}
