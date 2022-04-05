using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto2.Data;
using Projeto2.Models;

namespace Projeto2.Controllers
{
    public class VetsController : Controller
    {

        /// <summary>
        /// Este atributo refere a base de dados do nosso projeto
        /// </summary>
        /// 
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public VetsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Vets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Veterinarios.ToListAsync());
        }

        // GET: Vets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vets = await _context.Veterinarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vets == null)
            {
                return NotFound();
            }

            return View(vets);
        }

        // GET: Vets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// usa dados dados peo browser quando um novo veterinário é criado
        /// </summary>
        /// <param name="vets"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,NLicencaProfissional,Photo")] Vets vets, IFormFile newPhotoVet)
        {

            /*
             * temos de processar a imagem 
             * 
             * if file == null
             *    add predefined image
             * else 
             *    if file != image
             *       error message asking for an image
             *    else
             *      - define the name that the image must have
             *      - add the file name to vet data
             *      - save the file on the disk
             */

            if (newPhotoVet == null)
            {
                vets.Photo = "noVet.png";
            }
            else
            {
                //write the error message
                if (!(newPhotoVet.ContentType == "image/jpeg" || newPhotoVet.ContentType == "image/png"))
                {
                    ModelState.AddModelError("", "Please, if you want to send a file, choose an image");
                }
                else
                {
                    Guid g;
                    g = Guid.NewGuid();
                    string imageName = vets.NLicencaProfissional + "_" + g.ToString();
                    string extensionOfImage = Path.GetExtension(newPhotoVet.FileName).ToLower();
                    imageName += extensionOfImage;
                    //add image name to vet data
                    vets.Photo = imageName;

                }
                //resend control to view, with data provided by user
                return View(vets);

            }

            //validate if data provided by user is good....
            if (ModelState.IsValid)
            {
                //add vet data ro dabase
                _context.Add(vets);
                //commit
                await _context.SaveChangesAsync();

                string addressToStoreFile = _webHostEnvironment.WebRootPath;
                string newImageLocalization =Path.Combine(addressToStoreFile,"Photos",vets.Photo);

                //save image file to disk

                using var stream = new FileStream(newImageLocalization, FileMode.Create);
                newPhotoVet.CopyToAsync(stream);

                return RedirectToAction(nameof(Index));

            }
            return View(vets);
        }

        // GET: Vets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vets = await _context.Veterinarios.FindAsync(id);
            if (vets == null)
            {
                return NotFound();
            }
            return View(vets);
        }

        // POST: Vets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,NLicencaProfissional,Photo")] Vets vets)
        {
            if (id != vets.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VetsExists(vets.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vets);
        }

        // GET: Vets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vets = await _context.Veterinarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vets == null)
            {
                return NotFound();
            }

            return View(vets);
        }

        // POST: Vets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vets = await _context.Veterinarios.FindAsync(id);
            _context.Veterinarios.Remove(vets);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VetsExists(int id)
        {
            return _context.Veterinarios.Any(e => e.Id == id);
        }
    }
}
